using PodMembersRecordData.Repositories.InMemoryImplementation;
using PodMembersRecordUI;
using PodMembersRecordUI.Utilities;
using System;

namespace DotNetPodMembersRecords
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Wait.Waiting();
            Tasks.Read();
            App.Run();
        }
    }
}