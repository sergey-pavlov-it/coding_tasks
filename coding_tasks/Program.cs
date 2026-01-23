namespace geniusIdiotConsoleApp
{
    public class Program
    {
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

        public static string Diagnosis(int counterRightAnswer)
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
            return diagnosis[counterRightAnswer];
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Как к Вам обращаться?");
            string personName = Console.ReadLine();
            Console.WriteLine($"Очень приятно, {personName}. Начнем тест:");
            System.Threading.Thread.Sleep(1500);

            bool doTest = true;

            while (doTest)
            {
                int correctAnswer = 0;

                (string Question, int Answer)[] dataTest = GetDataTest();

                Random.Shared.Shuffle(dataTest);

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Вопрос №{i + 1}\n{dataTest[i].Question}"); 

                    int userAnswer = int.Parse(Console.ReadLine());
                    if (userAnswer == dataTest[i].Answer)
                    {
                        correctAnswer++;
                    }

                    System.Threading.Thread.Sleep(500);
                }

                Console.WriteLine($"Количество верных ответов: {correctAnswer}");
                Console.WriteLine($"{personName}, Ваш диагноз - {Diagnosis(correctAnswer)}");

                Console.WriteLine("Хотите пройти тест ещё раз? (Да/Нет)");

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
                            Console.WriteLine($"Всего хорошего, {personName}");
                            break;
                        default:
                            Console.WriteLine($"Не понял ответа, повторите (Да/Нет)");
                            break;
                    }
                }
            }
        }
    }
}