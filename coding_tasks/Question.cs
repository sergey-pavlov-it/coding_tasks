using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusIdiotConsoleApp
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
    }
}
