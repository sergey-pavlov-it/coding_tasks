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
        static void Main(string[] args)
        {
            QuestionsRepository questionsRepository = new QuestionsRepository();

            while (true)
            {
                Console.WriteLine("1. Пройти тест");
                Console.WriteLine("2. Добавить вопрос");
                Console.WriteLine("3. Посмотреть результаты");
                Console.WriteLine("0. Выход");

                switch ((Console.ReadLine() ?? "").Trim())
                {
                    case "1":
                        RunQuizScenario(questionsRepository);
                        break;
                    case "2":
                        AddQuestionScenario(questionsRepository);
                        break;
                    case "3":
                        ShowResultsScenario();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Введи 1/2/3/0");
                        break;
                }
            }

            static void RunQuizScenario(QuestionsRepository questionsRepository) 
            {
                QuizEngine startTest = new QuizEngine(); // создаем объект для старта теста
                UserResultRepository resultRepo = new UserResultRepository(); // для оперирование сохранением/чтением результатов

                Console.WriteLine("Здравствуйте! Как к Вам обращаться?"); // знакомство
                User currentUser = new User((Console.ReadLine() ?? "").Trim());
                Console.WriteLine($"Очень приятно, {currentUser.Name}. Начнем тест:");

                bool doTest = true;
                while (doTest)
                {
                    int correctAnswers = startTest.Run(questionsRepository.Questions); // запуск теста

                    Console.WriteLine($"Количество верных ответов: {correctAnswers}"); // итог теста

                    int numberDiagnos = GetIndexDiagnos(correctAnswers, questionsRepository.Questions.Count);
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
            }

            static void AddQuestionScenario(QuestionsRepository questionsRepository)
            {
                Console.WriteLine("Введите вопрос:");
                string question = Console.ReadLine();

                Console.WriteLine("Введите ответ:");
                string answer = Console.ReadLine();

                bool ok = questionsRepository.AddQuestion(question, answer, out string error);

                if (!ok)
                {
                    Console.WriteLine($"Вопрос не добавлен: {error}");
                    return;
                }
                else
                {
                    Console.WriteLine("Вопрос добавлен.");
                }

            }

            static void ShowResultsScenario()
            {
                UserResultRepository resultRepo = new UserResultRepository();
                resultRepo.ShowResult();
            }

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