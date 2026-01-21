using static System.Runtime.InteropServices.JavaScript.JSType;

namespace geniusIdiotConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] questions = new string [5];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";

            int[] answers = new int [5];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;

            string[] diagnosis = new string [6];
            diagnosis[0] = "Идиот";
            diagnosis[1] = "Кретин";
            diagnosis[2] = "Дурак";
            diagnosis[3] = "Нормальный";
            diagnosis[4] = "Талант";
            diagnosis[5] = "Гений";

            int counterRightAnswer = 0;

            for (int i = 0; i < 5; i++)
            {
                RandomQuestions(questions, answers);
                Console.WriteLine($"Вопрос №{i + 1}\n{questions[i]}");

                int user_answer = int.Parse(Console.ReadLine());
                if (user_answer == answers[i])
                {
                    counterRightAnswer++;   
                }
            }

            Console.WriteLine($"Количество верных ответов: {counterRightAnswer}");
            Console.WriteLine($"Ваш диагноз - {diagnosis[counterRightAnswer]}");
        }

        public static void RandomQuestions(string[] questions, int[] answers)
        {
            for (int i = questions.Length - 1; i > 0; i--)
            {
                int j = Random.Shared.Next(i + 1);

                (questions[i], questions[j]) = (questions[j], questions[i]);
                (answers[i], answers[j]) = (answers[j], answers[i]);
            }
        }
    }
}
