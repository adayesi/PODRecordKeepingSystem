using APPLibrary;
using PodMembersRecordData.Repositories.DTO;
using PodMembersRecordData.Repositories.InMemoryImplementation;

namespace PodMembersRecordUI.Utilities
{
    public static class Commons
    {
        public static string DataFilePath = @"..\..\..\Files\DataFile\dataStore.txt";
        public static string ErrorFilePath = $@"..\..\..\Files\RKSErrorLogs\{ DateTime.Now:yyyy-MM-dd}.txt";
        public static string Header = @"
    |--------------------------|----------------------------|-------------------------|------------------------|
    |         MEMBERS' NAME    |       EMAIL ADDRESS        |       PHONE NUMBER      |        GITHUB URL      |
    |--------------------------|----------------------------|-------------------------|------------------------|
 ";

        public static string Footer = $@"
    |--------------------------|----------------------------|-------------------------|------------------------|
            ";

        public static string GenerateId()
        {
            return Guid.NewGuid().ToString("n");
        }

        internal static void AddMultipleMemberPrompt()
        {
            string choice;
            do
            {
                var input = MembersForm.GetInput();
                var dto = new MembersDTO
                {
                    Id = Commons.GenerateId(),
                    Name = $"{Capitalize(input[0])} {Capitalize(input[1])}",
                    Email = $"{input[2]}",
                    PhoneNumber = $"{input[3]}",
                    GitHubURL = $"{input[4]}"
                };
                var membersService = GlobalConfig.MembersService;
                membersService.AddMember(dto);

                Console.Write("Want to add more members? press y/yes to add or any other key to continue: ");
                choice = Console.ReadLine();
            } while (choice == "y" || choice == "yes");
            var delete = GlobalConfig.MembersService;
            FileOperations.Write(DataFilePath);
            delete.DeleteMembers();
            FileOperations.Read(DataFilePath);
            FileOperations.Clear(DataFilePath);
            FileOperations.WriteTask(DataFilePath);
            ConsoleOutPut.Show(InMemoryDataStorage.fileData);
        }

        internal static string NamePrompt()
        {
            var name = "";
            if (name == null) throw new ArgumentNullException(nameof(name));
            do
            {
                Console.Write("Enter the name of the member: ");
                name = Console.ReadLine();
            } while (!Validator.IsAValidName(name));
            return name.ToLower();
        }

        internal static string PhoneNumberPrompt()
        {
            string phoneNumber = "";
            do
            {
                Console.Write("Enter the phone number of the member: ");
                phoneNumber = Console.ReadLine();
            } while (!Validator.IsAValidPhoneNumber(phoneNumber));
            return phoneNumber;
        }

        internal static List<string> IdPrompt()
        {
            List<string> ids = new List<string>();
            string id = "";
            string choice;

            do
            {
                do
                {
                    Console.Write("Enter the ID of members: ");
                    id = Console.ReadLine();

                    ids.Add(id);

                } while (Validator.IsNullEmptyOrWhiteSpace(id));

                Console.Write("Enter another ID?  press y/yes to add or any other key to continue: ");
                choice = Console.ReadLine();

            } while (choice == "y" || choice == "yes");
            
            return ids;
        }

        internal static string Capitalize(string val)
        {
            string v = val[0].ToString().ToUpper();
            string str = v;
            return (str += val.Substring(1));
        }
    }
}
