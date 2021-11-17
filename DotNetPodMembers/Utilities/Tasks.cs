using APPLibrary;
using PodMembersRecordData.Repositories.DTO;
using PodMembersRecordData.Repositories.InMemoryImplementation;
using PodMembersRecordServices.Interfaces;

namespace PodMembersRecordUI.Utilities
{
    internal static class Tasks
    {
        private static  IMembersService _membersService = GlobalConfig.MembersService;


        public static void Add()
        {
            var input = MembersForm.GetInput();
            var dto = new MembersDTO
            {
                Id = Commons.GenerateId(),
                Name = $"{Commons.Capitalize(input[0])} {Commons.Capitalize(input[1])}",
                Email = $"{input[2]}",
                PhoneNumber = $"{input[3]}",
                GitHubURL = $"{input[4]}"
            };
            _membersService.AddMember(dto);

            FileOperations.Write(Commons.DataFilePath);
            var del = GlobalConfig.MembersService;
            del.DeleteMembers();
            FileOperations.Read(Commons.DataFilePath);
            FileOperations.Clear(Commons.DataFilePath);
            FileOperations.WriteTask(Commons.DataFilePath);
            Wait.Waiting();
            ConsoleOutPut.Show(InMemoryDataStorage.fileData);
        }

        public static void Update()
        { 
            var name = Commons.NamePrompt();
            var replacement = MembersForm.GetInput();
            var list = new List<string>
            {
                $"{replacement[0]} {replacement[1]}",
                $"{replacement[2]}",
                replacement[3],
                replacement[4]
            };
            _membersService.UpdateMember(name, list);
            FileOperations.Clear(Commons.DataFilePath);
            FileOperations.WriteTask(Commons.DataFilePath);
            Wait.Waiting();
            ConsoleOutPut.Show(InMemoryDataStorage.fileData);
        }

        public static void FetchOne()
        {
            var searchPhone = Commons.PhoneNumberPrompt();
            var searchResult = _membersService.GetMembers(searchPhone);
            Wait.Waiting();
            ConsoleOutPut.Show(searchResult);
        }

        public static void FetchById()
        {
            var resultList = Commons.IdPrompt();
            var idSearchResults = _membersService.GetMembers(resultList);
            Wait.Waiting();
            ConsoleOutPut.Show(idSearchResults); 
        }

        public static void DeleteOne()
        {
            var memberToDelete = Commons.NamePrompt();
            _membersService.DeleteMembers(memberToDelete);
            FileOperations.Clear(Commons.DataFilePath);
            try
            {
                FileOperations.WriteTask(Commons.DataFilePath);
            }
            catch (Exception e)
            {
                string err = $"Date: {DateTime.Now:dd-MM-yyyy}, Time: {DateTime.Now:HH: mm: ss: tt}. Error: {e.Message}";
                FileOperations.ErrorLogg(err, Commons.ErrorFilePath);
            }
            Wait.Waiting();
            ConsoleOutPut.Show(InMemoryDataStorage.fileData);
        }

        public static void DeleteById()
        {
            var membersToDelete = Commons.IdPrompt();
            _membersService.DeleteMembers(membersToDelete);
            FileOperations.Clear(Commons.DataFilePath);
            try
            {
                FileOperations.WriteTask(Commons.DataFilePath);
            }
            catch (Exception e)
            {
                var err = $"Date: {DateTime.Now:dd-MM-yyyy}, Time: {DateTime.Now:HH: mm: ss: tt}. Error: {e.Message}";
                FileOperations.ErrorLogg(err, Commons.ErrorFilePath);
            }
            
        }

        public static void FilterByName()
        {
            var queryName = Commons.NamePrompt();
            var flt = _membersService.MembersListFilteredByName(queryName);
            Wait.Waiting();
            ConsoleOutPut.Show(flt);
            
            Console.ReadKey();
        }

        public static void Read()
        {
            try
            {
                FileOperations.Read(Commons.DataFilePath);
            }
            catch (Exception e)
            {
                var err = $"Date: {DateTime.Now:dd-MM-yyyy}. Time: {DateTime.Now:HH: mm: ss: tt}. Error: {e.Message}";
                FileOperations.ErrorLogg(err, Commons.ErrorFilePath);
            }
            
        }
    }
}
