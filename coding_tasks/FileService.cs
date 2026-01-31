using GeniusIdiotConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace GeniusIdiotConsoleApp.Infrastructure
{
    public class FileService
    {
        public void EnsureFileExists(string path)
        {
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate)) { }
        }

        public void AppendLine(string path, string line)
        {
            using (StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8))
            {
                writer.WriteLine(line);
            }
        }

        public string[] ReadLines(string path)
        {
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                List<string> lines = new List<string>();
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                string[] result = lines.ToArray();
                return result;
            }
        }
    }
}
