using System;
using System.Collections.Generic;
using System.Text;
using GeniusIdiotConsoleApp.Domain;

namespace GeniusIdiotConsoleApp.Infrastructure
{
    public class UserResultRepository
    {
        private readonly string _path;
        private readonly FileService _fileService;

        public UserResultRepository()
        {
            _path = "userResult.csv";
            _fileService = new FileService();
        }

        public void SaveResult(string userName, int correctAnswers, string userDiagnos)
        {
            string text = $"{userName};{correctAnswers};{userDiagnos}";
            _fileService.AppendLine(_path, text);
        }

        public void ShowResult()
        {
            string column1 = "ФИО";
            string column2 = "Кол-во верных ответов";
            string column3 = "Диагноз";
            Console.WriteLine($"| {column1.PadRight(10)} | {column2.PadRight(25)} | {column3.PadRight(10)} |");
            Console.WriteLine($"| {new string('-', 10)} | {new string('-', 25)} | {new string('-', 10)} |");
            string[] lines = _fileService.ReadLines(_path);
            for ( int i = 0; i < lines.Length; i++ )
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue; 
                }
                else
                {
                    string[] line = lines[i].Split(';');
                    Console.WriteLine($"| {line[0].PadRight(10)} | {line[1].PadRight(25)} | {line[2].PadRight(10)} |");
                }
            }
        }
    }
}
