using GeniusIdiotConsoleApp.Application;
using GeniusIdiotConsoleApp.Infrastructure;
using GeniusIdiotConsoleApp.UI;

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
            ConsoleMenu сonsoleScenarios = new ConsoleMenu(questionsRepository, quizEngine, resultRepo, diagnoseCalculator); // для запуска сценариев

            сonsoleScenarios.Run();
        }
    }
}