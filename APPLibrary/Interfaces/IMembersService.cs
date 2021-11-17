using AppModels;
using PodMembersRecordData.Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodMembersRecordServices.Interfaces
{
    public interface IMembersService
    {
        public void AddMember(MembersDTO members);
        public void UpdateMember(string name, List<string> members);
        public void DeleteMembers(string name);
        public void DeleteMembers();
        public void DeleteMembers(List<string> ids);
        public List<Members> GetMembers();
        public List<string> GetMembers(string phone);
        public List<string[]> GetMembers(List<string> ids);
        public List<string[]> MembersListFilteredByName(string name);
    }
}
