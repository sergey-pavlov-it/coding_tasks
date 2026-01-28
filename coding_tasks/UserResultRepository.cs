using System;
using System.Collections.Generic;
using System.Text;
using GeniusIdiotConsoleApp.Domain;

namespace GeniusIdiotConsoleApp.Infrastructure
{
    public class UserResultRepository
    {
        private readonly string _path;

        public UserResultRepository()
        {
            _path = "userResult.csv";
        }

        public async Task SaveResult(string userName, int correctAnswers, string userDiagnos)
        {
            string text = $"{userName};{correctAnswers};{userDiagnos}";
            using (StreamWriter writer = new StreamWriter(_path, true, Encoding.UTF8))
            {
                await writer.WriteLineAsync(text);
            }
        }

        public async Task ShowResult()
        {
            using (StreamReader reader = new StreamReader(_path))
            {
                string column1 = "ФИО";
                string column2 = "Кол-во верных ответов";
                string column3 = "Диагноз";
                Console.WriteLine($"| {column1.PadRight(10)} | {column2.PadRight(25)} | {column3.PadRight(10)} |");
                Console.WriteLine($"| {new string('-', 10)} | {new string('-', 25)} | {new string('-', 10)} |");
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    string[] parts = line.Split(';');
                    Console.WriteLine($"| {parts[0].PadRight(10)} | {parts[1].PadRight(25)} | {parts[2].PadRight(10)} |");
                }
            }
        }
    }
}
