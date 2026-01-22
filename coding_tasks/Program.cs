namespace geniusIdiotConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int counterRightAnswer = 0;

            string[] questions = GetArrayQuestions();
            int[] answers = GetArrayAnswers();

            RandomQuestions(questions, answers);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Вопрос №{i + 1}\n{questions[i]}");

                int user_answer = int.Parse(Console.ReadLine());
                if (user_answer == answers[i])
                {
                    counterRightAnswer++;   
                }
            }

            Console.WriteLine($"Количество верных ответов: {counterRightAnswer}");
            Console.WriteLine($"Ваш диагноз - {Diagnosis(counterRightAnswer)}");
        }

        public static string[] GetArrayQuestions()
        {
            string[] questions = new string[5];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }

        public static int[] GetArrayAnswers()
        {
            int[] answers = new int[5];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }

        public static string Diagnosis(int counterRightAnswer)
        {
            string[] diagnosis = new string[6];
            diagnosis[0] = "идиот";
            diagnosis[1] = "кретин";
            diagnosis[2] = "дурак";
            diagnosis[3] = "нормальный";
            diagnosis[4] = "талант";
            diagnosis[5] = "гений";
            return diagnosis[counterRightAnswer];
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