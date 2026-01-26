using System.Text;

namespace geniusIdiotConsoleApp
{
    public class Program
    {
       static async Task Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Как к Вам обращаться?"); // начало теста
            string userName = Console.ReadLine();
            Console.WriteLine($"Очень приятно, {userName}. Начнем тест:");
            System.Threading.Thread.Sleep(1000);

            bool doTest = true;
            while (doTest)
            {
                int correctAnswers = 0;

                (string Question, int Answer)[] dataTest = GetDataTest(); // получили воросы
                Random.Shared.Shuffle(dataTest); // перемешали вопросы

                for (int i = 0; i < dataTest.Length; i++) // вывод вопросов
                {
                    Console.WriteLine($"Вопрос №{i + 1}\n{dataTest[i].Question}");
                    int userAnswer = CheckInputAnswer();
                    if (userAnswer == dataTest[i].Answer)
                    {
                        correctAnswers++;
                    }

                    System.Threading.Thread.Sleep(500);
                }

                Console.WriteLine($"Количество верных ответов: {correctAnswers}"); // итог теста
                int numberDiagnos = GetIndexDiagnos(correctAnswers, dataTest.Length);
                string userDiagnos = GetDiagnos(numberDiagnos);
                Console.WriteLine($"{userName}, Ваш диагноз - {userDiagnos}");


                Console.WriteLine("Хотите пройти тест ещё раз? (Да/Нет)"); // повтор теста
                string? newTest = null;
                while ( newTest != "да" && newTest != "нет")
                {
                    newTest = Console.ReadLine().ToLower();
                    switch (newTest)
                    {
                        case "да":
                            Console.WriteLine("Отлично, перейдем к вопросам");
                            break;
                        case "нет":
                            doTest = false;
                            Console.WriteLine($"Всего хорошего, {userName}");
                            break;
                        default:
                            Console.WriteLine($"Не понял ответа, повторите (Да/Нет)");
                            break;
                    }
                }
                await SaveResult(userName, correctAnswers, userDiagnos); // сохраняем результат
                await ShowResult(); // выводим таблицу с результатами
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

        public static int CheckInputAnswer()
        {
            while (true)
            {
                string input = (Console.ReadLine() ?? "").Trim();
                if (int.TryParse(input, out int number))
                {
                    return number;
                }

                Console.WriteLine("Некорректный ввод. Введите целое число.");
            }
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