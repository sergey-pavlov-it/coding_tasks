using GeniusIdiotConsoleApp;
using GeniusIdiotConsoleApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeniusIdiotFormApp
{
    public partial class AddDeleteQuestions : Form
    {
        private readonly QuestionsRepository _questionsRepo;
        private readonly UserResultRepository _userResultRepo;
        private readonly DiagnosisCalculator _diagnoseCalculator;

        public AddDeleteQuestions(QuestionsRepository questionsRepo, UserResultRepository userResultRepo, DiagnosisCalculator diagnoseResult)
        {
            InitializeComponent();
            _questionsRepo = questionsRepo;
            _userResultRepo = userResultRepo;
            _diagnoseCalculator = diagnoseResult;
        }

        private void listBoxQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshQuestionsList()
        {
            listBoxQuestions.Items.Clear();
            foreach (var q in _questionsRepo.Questions)
                listBoxQuestions.Items.Add(q);
        }

        private void AddDeleteQuestions_Load(object sender, EventArgs e)
        {
            RefreshQuestionsList();
        }
    }
}
