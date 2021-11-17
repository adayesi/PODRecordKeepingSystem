using APPLibrary;
using PodMembersRecordData.Repositories.DTO;
using PodMembersRecordData.Repositories.InMemoryImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodMembersRecordUI.Utilities
{
    public static class App
    {
        public static void Run()
        {
            MainPrompt();
        }

        private static void MainPrompt()
        {
            string choice;
            do
            {
                Console.Write(@"
Press....

1.  To view existing records.
2.  To add a member.
3.  To add multiple members.
4.  To update a member's details.
5.  To lookup a member.
6.  To get members by ID.
7.  To delete a member.
8.  To delete a list of members by IDs
9.  To clear members' record.
0.  To search for records by name.
Any other key to quit...
>>  ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    
                    case "1":
                        ConsoleOutPut.Show(InMemoryDataStorage.fileData);
                        Console.ReadKey();  
                        break;

                    case "2":
                        Tasks.Add();
                        break;

                    case "3":
                        Commons.AddMultipleMemberPrompt();
                        break;
                    case "4":
                        Tasks.Update();
                        break;
                    case "5":
                        Tasks.FetchOne();
                        break;
                    case "6":
                        Tasks.FetchById();
                        break;
                    case "7":
                        Tasks.DeleteOne();
                        break;
                    case "8": 
                        Tasks.DeleteById();
                        break;
                    case "9":
                        var deleteAll = GlobalConfig.MembersService;
                        deleteAll.DeleteMembers();
                        FileOperations.Clear(Commons.DataFilePath);
                        break;
                    case "0":
                        Tasks.FilterByName();
                        break;
                    default:
                        return;
                        break;
                }
                Console.Clear();
            } while (true);
        }

        
    }
}
