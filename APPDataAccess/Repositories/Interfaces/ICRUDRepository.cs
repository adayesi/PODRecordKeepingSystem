using AppModels;
using PodMembersRecordData.Repositories.DTO;

namespace APPDataAccess
{
    public interface ICRUDRepository
    {
        public bool CreateMember(Members members);
        public bool UpdateMember(string member, List<string> replacement);
        public bool DeleteMembers(string member);
        public bool DeleteMembers(List<string> ids);
        public bool DeleteMembers();
        public List<Members> GetMembers();
        public List<string> GetMembers(string phone);
        public List<string[]> GetMembers(List<string> ids);
        public List<string[]> FilterMembersByName(string names);
    }
}