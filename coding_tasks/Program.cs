using GeniusIdiotClassLibrary;
using GeniusIdiotConsoleApp.Application;
using GeniusIdiotConsoleApp.Domain;
using GeniusIdiotConsoleApp.Infrastructure;
using GeniusIdiotClassLibrary.Validation;

namespace GeniusIdiotConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            QuestionsRepository questionsRepository = new QuestionsRepository(); // для оперирования репозиторием вопросов
            QuizEngine quizEngine = new QuizEngine(); // для старта теста
            UserResultRepository resultRepo = new UserResultRepository(); // для оперирования сохранением/чтением результатов
            DiagnosisCalculator diagnoseCalculator = new DiagnosisCalculator(); // для получения диагноза

            while (true)
            {
                Console.WriteLine("1. Пройти тест");
                Console.WriteLine("2. Добавить вопрос");
                Console.WriteLine("3. Удалить вопрос");
                Console.WriteLine("4. Посмотреть результаты");
                Console.WriteLine("0. Выход");

                switch ((Console.ReadLine() ?? "").Trim())
                {
                    case "1":
                        RunQuizScenario(questionsRepository, quizEngine, resultRepo, diagnoseCalculator);
                        break;
                    case "2":
                        AddQuestionScenario(questionsRepository);
                        break;
                    case "3":
                        DeleteQuestionScenario(questionsRepository);
                        break;
                    case "4":
                        ShowResultsScenario(resultRepo);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Введи 1/2/3/4/0");
                        break;
                }
            }

            static void RunQuizScenario(QuestionsRepository questionsRepository, QuizEngine quizEngine, UserResultRepository resultRepo, DiagnosisCalculator diagnoseCalculator) 
            {
                Console.WriteLine("Здравствуйте! Как к Вам обращаться?"); // знакомство
                User currentUser = new User((Console.ReadLine() ?? "").Trim());
                Console.WriteLine($"Очень приятно, {currentUser.Name}. Начнем тест:");

                bool doTest = true;
                while (doTest)
                {
                    int correctAnswers = quizEngine.Run(questionsRepository.Questions); // запуск теста

                    Console.WriteLine($"Количество верных ответов: {correctAnswers}"); // итог теста

                    string userDiagnosis = diagnoseCalculator.CalculateDiagnos(correctAnswers, questionsRepository.Questions.Count);

                    Console.WriteLine($"{currentUser.Name}, Ваш диагноз - {userDiagnosis}");

                    resultRepo.SaveResult(currentUser.Name, correctAnswers, userDiagnosis); // сохранили результат

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
                string? question = Console.ReadLine();

                Console.WriteLine("Введите ответ:");
                string? answer = Console.ReadLine();



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

            static void DeleteQuestionScenario(QuestionsRepository questionsRepository)
            {
                for (int i = 1; i <  questionsRepository.Questions.Count + 1; i++)
                {
                    Console.WriteLine($"{i}. {questionsRepository.Questions[i - 1].Text}");
                }

                Console.WriteLine("Введите номер удаляемого вопроса");
                int indexDelete;
                while (true)
                {
                    if (InputValidation.TryParseIndex(Console.ReadLine(), out indexDelete))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введите число больше нуля");
                    }
                }
                bool ok = questionsRepository.DeleteQuestion(indexDelete, out string error);
                if (!ok)
                {
                    Console.WriteLine($"Вопрос не удален: {error}");
                    return;
                }
                else
                {
                    Console.WriteLine("Вопрос удален.");
                }
            }

            static void ShowResultsScenario(UserResultRepository resultRepo)
            {
                resultRepo.ShowResult();
            }
        }
    }
}