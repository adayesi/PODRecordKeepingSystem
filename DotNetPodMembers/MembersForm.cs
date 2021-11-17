using PodMembersRecordUI.Utilities;

namespace PodMembersRecordUI
{
    public static class MembersForm
    {
        private static string _firstName;
        private static string _lastName;
        private static string _email;
        private static string _phoneNumber;
        private static string _gitUrl;

        public static List<string> GetInput()
        {
            
            do
            {
                Console.Write("Enter member's first name: ");
                _firstName = Console.ReadLine().Trim();
            } while (!Validator.IsAValidName(_firstName));

            do
            {
                Console.Write("Enter member's last name: ");
                _lastName = Console.ReadLine().Trim();
            } while (!Validator.IsAValidName(_lastName));

            do
            {
                Console.Write("Enter member's email address: ");
                _email = Console.ReadLine().Trim();
            } while (!Validator.IsValidEmail(_email));

            do
            {
                Console.Write("Enter member's phone number (only digits): ");
                _phoneNumber = Console.ReadLine().Trim();
            } while (!Validator.IsAValidPhoneNumber(_phoneNumber));

            do
            {
                Console.Write("Enter member's github URL: ");
                _gitUrl = Console.ReadLine().Trim();
            } while (!Validator.IsAvalidGitHubUrl(_gitUrl));

            List<string> result = new List<string>() { _firstName, _lastName, _email, _phoneNumber, _gitUrl };
            return result;
        }
    }
}
