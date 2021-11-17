using APPDataAccess;
using AppModels;
using PodMembersRecordData.Repositories.DTO;
using PodMembersRecordData.Repositories.InMemoryImplementation;

namespace PodMembersRecordData.Repositories.Implementations.InMemoryImplementation
{
    public class MembersRepository : ICRUDRepository
    {
        public bool CreateMember(Members members)
        {
            InMemoryDataStorage.membersRecord.Add(members);
            return true;
        }

        public List<Members> GetMembers()
        {
            return InMemoryDataStorage.membersRecord;
        }

        public List<string> GetMembers(string phoneNumber)
        {
            var members = InMemoryDataStorage.fileData;
            var memberOfInterest = new List<string>();

            foreach (var member in members)
            {
                if (member[3].Trim() == phoneNumber.Trim())
                {
                    memberOfInterest.Add(member[1]);
                    memberOfInterest.Add(member[2]);
                    memberOfInterest.Add(member[3]);
                    memberOfInterest.Add(member[4]);
                    return memberOfInterest;
                }
            }
            throw new Exception("No result found for the search criteria");
        }

        public List<string[]> GetMembers(List<string> ids)
        {
            var membersOfInterest = new List<string[]>();
            var members = InMemoryDataStorage.fileData;

            foreach (var member in members)
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    if (member[0].Contains(ids[i]))
                    {
                        membersOfInterest.Add(member);
                    }
                }
            }
            if (membersOfInterest.Count > 0)
            {
                return membersOfInterest;
            }
            throw new Exception();
            
        }

        public List<string[]> FilterMembersByName(string name)
        {
            var members = InMemoryDataStorage.fileData;

            Func<string, bool> checkContains = s => s != null && s.Contains(name.ToLower());

            // Query.
            var query = from member in members where checkContains(member[1].ToLower()) select member;
            return query.ToList();
        }

        public bool UpdateMember(string name, List<string> replacement)
        {
            var members = InMemoryDataStorage.fileData;

            foreach (var member in members)
            {
                if (member[1].ToLower().Contains(name.ToLower()))
                {
                    member[1] = replacement[0];
                    member[2] = replacement[1];
                    member[3] = replacement[2];
                    member[4] = replacement[3];
                }
            }
            return true;
        }

        public bool DeleteMembers()
        {
            InMemoryDataStorage.fileData.Clear();
            InMemoryDataStorage.membersRecord.Clear();
            return true;
        }

        public bool DeleteMembers(List<string> ids)
        {
            string dataFilePath = @"..\..\..\Files\DataFile\dataStore.txt";
            string errorFilePath = $@"..\..\..\Files\RKSErrorLogs\{ DateTime.Now:yyyy-MM-dd}.txt";

            var members = InMemoryDataStorage.fileData;
            foreach (var d in ids)
            {
                var item = members.FirstOrDefault(x => x[0] == d);
                if (item != null)
                    members.Remove(item);
            }
            {

                FileOperations.Delete(dataFilePath, errorFilePath);



                try
                {
                    FileOperations.Write(members);
                }



                catch (Exception e)
                {
                    string err = $"Date: {DateTime.Now:dd-MM-yyyy}, Time: {DateTime.Now:HH: mm: ss: tt}. Error: {e.Message}";
                    FileOperations.ErrorLogg(err, errorFilePath);
                }



            }
            InMemoryDataStorage.membersRecord.Clear();
            return true;
        }

        public bool DeleteMembers(string name)
        {
            var members = InMemoryDataStorage.fileData;

            foreach ( var member in members)
            {
                if (member[1].ToLower().Contains(name.ToLower()))
                {
                    members.Remove(member);
                    return true;
                }
            }
            return false;
        }
    }
}
