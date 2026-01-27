using GeniusIdiotConsoleApp.Application;
using GeniusIdiotConsoleApp.Domain;
using GeniusIdiotConsoleApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusIdiotConsoleApp
{
    public class Program
    {
       static async Task Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Как к Вам обращаться?"); // начало теста
            User currentUser = new User((Console.ReadLine() ?? "").Trim());
            QuestionsRepository questions = new QuestionsRepository(); // получили воросы

            Console.WriteLine($"Очень приятно, {currentUser.Name}. Начнем тест:");


            QuizEngine startTest = new QuizEngine(); // создаем объект для старта теста
            bool doTest = true;
            while (doTest)
            {
                int correctAnswers = startTest.Run(questions.AllQuestions); // запуск теста

                Console.WriteLine($"Количество верных ответов: {correctAnswers}"); // итог теста
                
                int numberDiagnos = GetIndexDiagnos(correctAnswers, questions.AllQuestions.Count);
                string userDiagnos = GetDiagnos(numberDiagnos);
                Console.WriteLine($"{currentUser.Name}, Ваш диагноз - {userDiagnos}");


                //Console.WriteLine("Хотите пройти тест ещё раз? (Да/Нет)"); // повтор теста
                //string? newTest = null;
                //while ( newTest != "да" && newTest != "нет")
                //{
                //    newTest = Console.ReadLine().ToLower();
                //    switch (newTest)
                //    {
                //        case "да":
                //            Console.WriteLine("Отлично, перейдем к вопросам");
                //            break;
                //        case "нет":
                //            doTest = false;
                //            Console.WriteLine($"Всего хорошего, {userName}");
                //            break;
                //        default:
                //            Console.WriteLine($"Не понял ответа, повторите (Да/Нет)");
                //            break;
                //    }
                //}
                //await SaveResult(userName, correctAnswers, userDiagnos); // сохраняем результат
                //await ShowResult(); // выводим таблицу с результатами
            }
        }
        public static (string, int)[] GetDataTest()
        {
            (string Question, int Answer)[] TestData = new (string Question, int Answer)[5]
            {
                ("Сколько будет два плюс два умноженное на два?", 6),
                ("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9),
                ("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
                ("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60),
                ("Пять свечей горело, две потухли. Сколько свечей осталось?", 2)
            };
            return TestData;
        }

        public static string GetDiagnos(int diagnosisIndex)
        {
            string[] diagnosis = new string[6]
            {
                "идиот",
                "кретин",
                "дурак",
                "нормальный",
                "талант",
                "гений"
            };
            return diagnosis[diagnosisIndex];
        }

        public static int GetIndexDiagnos(int correctAnswers, int totalQuestions)
        {
            int result = (int)Math.Floor(correctAnswers * 5.0 / totalQuestions);
            return result;
        }

        public static async Task SaveResult(string userName, int correctAnswers, string userDiagnos)
        {
            string path = "userResult.csv";
            string text = $"{userName};{correctAnswers};{userDiagnos}";
            using (StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8))
            {
                await writer.WriteLineAsync(text);
            }
        }

        public static async Task ShowResult()
        {
            string path = "userResult.csv";
            using (StreamReader reader = new StreamReader(path))
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