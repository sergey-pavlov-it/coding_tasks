using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusIdiotClassLibrary
{
    public class DiagnoseCalculator
    {
        public string CalculateDiagnos(int correctAnswers, int totalQuestions)
        {
            var indexDiagnos = GetIndexDiagnos(correctAnswers, totalQuestions);
            return GetDiagnos(indexDiagnos);
        }
                    
        public string GetDiagnos(int diagnosisIndex)
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

        public int GetIndexDiagnos(int correctAnswers, int totalQuestions)
        {
            int result = (int)Math.Floor(correctAnswers * 5.0 / totalQuestions);
            return result;
        }
    }
}
