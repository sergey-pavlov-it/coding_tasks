using GeniusIdiotConsoleApp.Application;
using GeniusIdiotConsoleApp.Domain;
using GeniusIdiotConsoleApp.Infrastructure;

namespace GeniusIdiotFormApp
{
    public partial class StartTest : Form
    {
        QuizEngine startTest = new QuizEngine(); // для старта теста
        QuestionsRepository questionsRepository = new QuestionsRepository(); // для оперирования репозиторием вопросов
        UserResultRepository resultRepo = new UserResultRepository(); // для оперирования сохранением/чтением результатов

        private int _currentIndex = 0;
        private List<Question> _questions = new List<Question>();
        private int _correctAnswers = 0;




        public StartTest()
        {
            InitializeComponent();
        }

        private void AnswerUserTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartTest_Load(object sender, EventArgs e)
        {
            _currentIndex = 0;

            var arr = questionsRepository.Questions.ToArray();
            Random.Shared.Shuffle(arr);
            _questions = arr.ToList();

            ShowQuestion();
        }

        private void NextQuestionButton_Click(object sender, EventArgs e)
        {
            string userAnswer = AnswerUserTextBox.Text.Trim();
            if (!int.TryParse(userAnswer, out int userNumber))
            {
                MessageBox.Show("Нужно ввести число.", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                AnswerUserTextBox.Focus();
                AnswerUserTextBox.SelectAll();
                return;
            }

            if (userNumber == _questions[_currentIndex].Answer)
            {
                _correctAnswers++;
            }

            _currentIndex++;
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            if (_questions.Count == 0)
            {
                QuestionsLabel.Text = "В репозитории нет вопросов";
                return;
            }

            if (_currentIndex >= _questions.Count)
            {
                FinishQuiz();
            }
            else
            {
                QuestionsLabel.Text = $"Вопрос №{_currentIndex + 1}";
                TextQuestionsLable.Text = _questions[_currentIndex].Text;
            }

        }

        private void FinishQuiz()
        {
            MessageBox.Show($"Кол-во верных ответов: {_correctAnswers}\nВаш диагноз: ");
            this.Close();
        }



    }
}
