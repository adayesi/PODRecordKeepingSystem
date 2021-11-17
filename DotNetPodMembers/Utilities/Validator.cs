using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodMembersRecordUI.Utilities
{
    public static class Validator
    {
        public static bool IsValidEmail(string email)
        {
            if (IsNullEmptyOrWhiteSpace(email))
            {
                return false;
            }

            if (email.Trim().EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsAValidPhoneNumber(string number)
        {
            return !IsNullEmptyOrWhiteSpace(number) && number.All(i => int.TryParse(i.ToString(), out _));
        }

        public static bool IsAValidName(string name)
        {
            return !IsNullEmptyOrWhiteSpace(name) && name.All(i => !int.TryParse(i.ToString(), out _));
        }

        public static bool IsAvalidGitHubUrl(string url)
        {
            if (!url.StartsWith("https://www.github.com") && !url.StartsWith("http://www.github.com") &&
                !url.StartsWith("https://github.com") && !url.StartsWith("http://github.com") &&
                !url.StartsWith("www.github.com") && !url.StartsWith("github.com")) return false;
            return !url.EndsWith(".com");
        }

        public static bool IsNullEmptyOrWhiteSpace(string name)
        {
            return (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name));
        }
    }
}
