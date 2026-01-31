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

        public bool AddQuestion(string text, string answerText, out string error)
        {
            error = "";

            text = (text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(text) || text.Contains(';') || text.Contains('\n') || text.Contains('\r'))
            {
                error = "Некорректный текст вопроса (пусто, символ ;, перенос строки).";
                return false;
            }

            if (!int.TryParse((answerText ?? "").Trim(), out int answer))
            {
                error = "Ответ должен быть числом.";
                return false;
            }

            Questions.Add(new Question(text, answer));
            _fileService.AppendLine(_path, $"{text};{answer}");
            return true;
        }
    }
}