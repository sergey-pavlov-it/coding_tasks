using GeniusIdiotConsoleApp.Infrastructure;
using GeniusIdiotConsoleApp.Application;
using GeniusIdiotConsoleApp.Domain;

namespace GeniusIdiotFormApp
{
    public partial class mainForm : Form
    {
        List<Question> questionList;
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            QuestionsRepository questionsRepository = new QuestionsRepository(); // для оперирования репозиторием вопросов
            QuizEngine startTest = new QuizEngine(); // для старта теста
            UserResultRepository resultRepo = new UserResultRepository(); // для оперирования сохранением/чтением результатов
            questionTextLable.Text = questionsRepository.Questions[0].Text;
        }

        private void nextButtin_Click(object sender, EventArgs e)
        {

        }
    }
}
