using PodMembersRecordData.Repositories.InMemoryImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodMembersRecordData.Repositories.DTO
{
    public static class FileOperations
    {
        public static void ErrorLogg(string msg, string filePath)
        {
            var fileName = new FileInfo(filePath);
            using (StreamWriter sw = new StreamWriter(fileName.Open(FileMode.Append, FileAccess.Write, FileShare.Write)))
            {
                sw.WriteLine(msg);
                sw.WriteLine();
                sw.Close();
            }
        }
        public static void Read(string targetFilePath)
        {
            var info = new FileInfo(targetFilePath);

            if (info.Exists || info.Length != 0)
            {
                List<string> lines = File.ReadAllLines(targetFilePath).ToList();
                foreach (var line in lines)
                {
                    var arrl = line.Split(",");
                    InMemoryDataStorage.fileData.Add(arrl);
                 }
            }
            else
             {
                throw new Exception();
             }
        }

        public static void Write(string targetFilePath)
        {
            var fileName = new FileInfo(targetFilePath);
            using (StreamWriter sw = new StreamWriter(fileName.Open(FileMode.Append, FileAccess.Write, FileShare.Write)))
            {
                foreach (var item in InMemoryDataStorage.membersRecord)
                {
                    sw.WriteLine($"{item.Id}, {item.Name}, {item.Email}, {item.PhoneNumber}, {item.GithubURL}");
                }
                sw.Close();
            }
        }

        public static void WriteTask(string targetFilePath)
        {
            var fileName = new FileInfo(targetFilePath);
            using (StreamWriter sw = new StreamWriter(fileName.Open(FileMode.Append, FileAccess.Write, FileShare.Write)))
            {
                foreach (var item in InMemoryDataStorage.fileData)
                {
                    sw.WriteLine($"{item[0]}, {item[1]}, {item[2]}, {item[3]}, {item[4]}");
                }
                sw.Close();
                return;
            }
            throw new Exception();
        }

        public static void Clear(string dataPath)
        {
            using (FileStream fileStream = File.Open(dataPath, FileMode.Open))
            {
                fileStream.SetLength(0);
                fileStream.Close();
            }
        }

        public static void Delete(string dataPath, string errPath)
        {
            try
            {
                if (File.Exists(dataPath))
                {
                    File.Delete(dataPath);
                }
            }
            catch (IOException e)
            {
                string err = $"Date: {DateTime.Now:dd-MM-yyyy}. Time: {DateTime.Now:HH: mm: ss: tt}. Error: {e.Message}";
                FileOperations.ErrorLogg(err, errPath);
            }
        }
        internal static void Write(List<string[]> members)
        {
            throw new NotImplementedException();
        }
    }
}
