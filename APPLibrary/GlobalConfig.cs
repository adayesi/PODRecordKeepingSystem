using APPDataAccess;
using PodMembersRecordData.Repositories.Implementations.InMemoryImplementation;
using PodMembersRecordServices.Implementations;
using PodMembersRecordServices.Interfaces;

namespace APPLibrary
{
    public static class GlobalConfig
    {
        public static ICRUDRepository MembersRepository;
        public static IMembersService MembersService;

        static GlobalConfig()
        {
            MembersRepository = new MembersRepository();
            MembersService = new MembersService(MembersRepository);
        }

        public static void DestroyInstance()
        {
            MembersRepository = null;
            MembersService = null;
        }
    }
}