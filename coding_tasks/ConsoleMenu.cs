using GeniusIdiotConsoleApp.Application;
using GeniusIdiotConsoleApp.Domain;
using GeniusIdiotConsoleApp.Infrastructure;
using GeniusIdiotConsoleApp.Validation;

namespace GeniusIdiotConsoleApp.UI
{
    public class ConsoleMenu
    {
        private readonly QuestionsRepository _questionsRepository;
        private readonly QuizEngine _quizEngine;
        private readonly UserResultRepository _resultRepo;
        private readonly DiagnosisCalculator _diagnosisCalculator;

        public ConsoleMenu(QuestionsRepository questionsRepository, QuizEngine quizEngine, UserResultRepository resultRepo, DiagnosisCalculator diagnosisCalculator)
        {
            _questionsRepository = questionsRepository;
            _quizEngine = quizEngine;
            _resultRepo = resultRepo;
            _diagnosisCalculator = diagnosisCalculator;
        }

        public void Run()
        {
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
                        RunQuizScenario();
                        break;
                    case "2":
                        AddQuestionScenario();
                        break;
                    case "3":
                        DeleteQuestionScenario();
                        break;
                    case "4":
                        ShowResultsScenario();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Введи 1/2/3/4/0");
                        break;
                }
            }
        }


        public void RunQuizScenario()
        {
            Console.WriteLine("Здравствуйте! Как к Вам обращаться?"); // знакомство
            User currentUser = new User((Console.ReadLine() ?? "").Trim());
            Console.WriteLine($"Очень приятно, {currentUser.Name}. Начнем тест:");

            bool doTest = true;
            while (doTest)
            {
                int correctAnswers = _quizEngine.Run(_questionsRepository.Questions); // запуск теста

                Console.WriteLine($"Количество верных ответов: {correctAnswers}"); // итог теста

                string userDiagnosis = _diagnosisCalculator.CalculateDiagnosis(correctAnswers, _questionsRepository.Questions.Count);

                Console.WriteLine($"{currentUser.Name}, Ваш диагноз - {userDiagnosis}");

                _resultRepo.SaveResult(currentUser.Name, correctAnswers, userDiagnosis); // сохранили результат

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

        public void AddQuestionScenario()
        {
            Console.WriteLine("Введите вопрос:");
            string? question = Console.ReadLine();

            Console.WriteLine("Введите ответ:");
            string? answer = Console.ReadLine();

            bool ok = QuestionValidation.TryParseNewQuestion(question, answer, out string validText, out int validAnswer, out string error);

            if (!ok)
            {
                Console.WriteLine($"Вопрос не добавлен: {error}");
                return;
            }
            else
            {
                _questionsRepository.AddQuestion(validText, validAnswer);
                Console.WriteLine("Вопрос добавлен.");
            }

        }

        public void DeleteQuestionScenario()
        {
            for (int i = 1; i < _questionsRepository.Questions.Count + 1; i++)
            {
                Console.WriteLine($"{i}. {_questionsRepository.Questions[i - 1].Text}");
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
            bool ok = _questionsRepository.DeleteQuestion(indexDelete, out string error);
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

        public void ShowResultsScenario()
        {
            _resultRepo.ShowResult();
        }
    }
}
