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
            QuestionsRepository questions = new QuestionsRepository(); // получили вопросы

            Console.WriteLine("Здравствуйте! Как к Вам обращаться?"); // знакомство
            User currentUser = new User((Console.ReadLine() ?? "").Trim());
            Console.WriteLine($"Очень приятно, {currentUser.Name}. Начнем тест:");

            QuizEngine startTest = new QuizEngine(); // создаем объект для старта теста
            UserResultRepository resultRepo = new UserResultRepository(); // для оперирование сохранением/чтением результатов

            bool doTest = true;
            while (doTest)
            {
                int correctAnswers = startTest.Run(questions.Questions); // запуск теста

                Console.WriteLine($"Количество верных ответов: {correctAnswers}"); // итог теста
                
                int numberDiagnos = GetIndexDiagnos(correctAnswers, questions.Questions.Count);
                string userDiagnos = GetDiagnos(numberDiagnos);
                Console.WriteLine($"{currentUser.Name}, Ваш диагноз - {userDiagnos}");

                resultRepo.SaveResult(currentUser.Name, correctAnswers, userDiagnos); // сохранили результат

                Console.WriteLine("Хотите пройти тест ещё раз? (Да/Нет)"); // повтор теста
                while (true)
                {
                    string answer = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

                    if (answer == "да")
                    {
                        Console.WriteLine("Отлично, перейдем к вопросам");
                        break; // выходим из цикла ввода, doTest остаётся true
                    }

                    if (answer == "нет")
                    {
                        doTest = false;
                        Console.WriteLine($"Всего хорошего, {currentUser.Name}");
                        break;
                    }

                    Console.WriteLine("Не понял ответа, повторите (да/нет)");
                }
            }
            resultRepo.ShowResult();
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
    }
}