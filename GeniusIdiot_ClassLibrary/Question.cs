using System;
using System.Collections.Generic;
using System.Text;
using GeniusIdiotConsoleApp.Infrastructure;

namespace GeniusIdiotConsoleApp.Domain
{
    public class Question
    {
        public string Text;
        public int Answer;

        public Question(string text, int answer) 
        {
            Text = text;
            Answer = answer;
        }

        public override string ToString() => $"{Text} (Ответ: {Answer})";
    }


}
