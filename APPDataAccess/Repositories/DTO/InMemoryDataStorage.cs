using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppModels;

namespace PodMembersRecordData.Repositories.InMemoryImplementation
{
    public static class InMemoryDataStorage
    {
        public static List<Members> membersRecord = new List<Members>();
        public static List<string[]> fileData = new List<string[]>();
        
    }
}
