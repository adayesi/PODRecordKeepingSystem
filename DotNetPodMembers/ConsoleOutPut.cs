using AppModels;
using PodMembersRecordData.Repositories.InMemoryImplementation;

namespace PodMembersRecordUI
{
    public static class ConsoleOutPut
    {
       public static void Show(List<string> member)
        {
            if (member.Equals(null))
            {
                throw new Exception("Report is empty!");
            }

            int widthOfTable = 90;
            Console.Clear();

            PrintLine(widthOfTable);
            PrintRow(widthOfTable, "MEMBERS' NAME", "EMAIL ADDRESS", "PHONE NUMBER", "GITHUB URL");
            PrintLine(widthOfTable);

            foreach (var rp in member)
            {
                Console.Write($@"   {rp}        ");
            }
            //PrintLine(widthOfTable);
            Console.ReadLine();
        }
        public static void Show(List<string[]> members)
        {
            if (members.Equals(null))
            {
                throw new Exception("Report is empty!");
            }

            int widthOfTable = 105;
            Console.Clear();

            PrintLine(widthOfTable);
            PrintRow(widthOfTable, "MEMBERS' NAME", "EMAIL ADDRESS", "PHONE NUMBER", "GITHUB URL");
            PrintLine(widthOfTable);

            foreach (var rp in members)
            {
                PrintRow(widthOfTable, rp[1], rp[2], rp[3], rp[4]);
            }
            PrintLine(widthOfTable);
            Console.ReadLine();
        }

        public static void PrintLine(int widthOfTable)
        {
            Console.WriteLine(new string('-', widthOfTable));
        }

        public static void PrintRow(int widthOfTable, params string[] columns)
        {
            int width = (widthOfTable - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += CenterText(column, width) + "|";
                
            }
            Console.WriteLine(row);
        }

        public static string CenterText(string column, int width)
        {
            column = column.Length > width ? column.Substring(0, width - 3) + "..." : column;

            if (!string.IsNullOrEmpty(column))
            {
                return column.PadRight(width - (width - column.Length) / 2).PadLeft(width);
            }
            else
            {
                return new string(' ', width);
            }
        }
    }
}
