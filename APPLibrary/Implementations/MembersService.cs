using APPDataAccess;
using AppModels;
using PodMembersRecordData.Repositories.DTO;
using PodMembersRecordServices.Interfaces;

namespace PodMembersRecordServices.Implementations
{
    public class MembersService : IMembersService
    {
        public readonly ICRUDRepository _memberRepository;

        public MembersService(ICRUDRepository membersRepository)
        {
            _memberRepository = membersRepository;
        }

        public void AddMember(MembersDTO members)
        {
            
            var member = new Members { Id = members.Id, Name = members.Name, Email = members.Email, PhoneNumber = members.PhoneNumber, GithubURL = members.GitHubURL };
      
            _memberRepository.CreateMember(member);
        }

        public List<Members> GetMembers()
        {
            var members = _memberRepository.GetMembers();
            return members;
        }

        public List<string[]> GetMembers(List<string> ids)
        {
            var members = _memberRepository.GetMembers(ids);
            return members;
        }

        public List<string> GetMembers(string phone)
        {
            var member = _memberRepository.GetMembers(phone);
            return member;
        }

        public List<string[]> MembersListFilteredByName(string name)
        {
            var members = _memberRepository.FilterMembersByName(name);
            return members;
        }

        public void UpdateMember(string name, List<string> replacement)
        {
            _memberRepository.UpdateMember(name, replacement);
        }

        public void DeleteMembers()
        {
            _memberRepository.DeleteMembers();
        }

        public void DeleteMembers(List<string> ids)
        {
            _memberRepository.DeleteMembers(ids);
        }

        public void DeleteMembers(string name)
        {
            _memberRepository.DeleteMembers(name);
        }
    }
}
