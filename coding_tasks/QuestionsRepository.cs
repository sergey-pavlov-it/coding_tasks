using System;
using System.Collections.Generic;
using System.Text;
using GeniusIdiotConsoleApp.Domain;

namespace GeniusIdiotConsoleApp.Infrastructure
{
    public class QuestionsRepository
    {
        private readonly string _path;
        private readonly FileService _fileService;
        public List<Question> Questions { get; private set; }

        public QuestionsRepository()
        {
            _path = "questions.csv";
            _fileService = new FileService();
            Questions = new List<Question>();
            _fileService.EnsureFileExists(_path);
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            Questions.Clear();
            string[] lines = _fileService.ReadLines(_path);
            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }
                else
                {
                    string[] line = lines[i].Split(';');
                    if (line.Length < 2)
                        continue;
                    if (!int.TryParse(line[1], out int answer))
                        continue;
                    Questions.Add(new Question(line[0], answer));
                }
            }
        }

        public bool AddQuestion(string text, int answer)
        {
            text = (text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(text) || text.Contains(';') || text.Contains('\n') || text.Contains('\r'))
            {
                return false;
            }
            Questions.Add(new Question(text, answer));
            _fileService.AppendLine(_path, $"{text};{answer}");
            return true;
        }
    }
}



//public readonly List<Question> AllQuestions = new List<Question>()
//{
//    new Question("Сколько будет два плюс два умноженное на два?", 6),
//    new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9),
//    new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
//    new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60),
//    new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2),
//};
