namespace GeniusIdiotFormApp
{
    partial class StartTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            QuestionsLabel = new Label();
            TextQuestionsLable = new Label();
            AnswerLabel = new Label();
            AnswerUserTextBox = new TextBox();
            NextQuestionButton = new Button();
            SuspendLayout();
            // 
            // QuestionsLabel
            // 
            QuestionsLabel.Font = new Font("ISOCPEUR", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            QuestionsLabel.Location = new Point(22, 23);
            QuestionsLabel.Name = "QuestionsLabel";
            QuestionsLabel.Size = new Size(628, 21);
            QuestionsLabel.TabIndex = 0;
            QuestionsLabel.Text = "Вопрос №1";
            QuestionsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TextQuestionsLable
            // 
            TextQuestionsLable.BackColor = SystemColors.ButtonFace;
            TextQuestionsLable.Font = new Font("ISOCPEUR", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextQuestionsLable.Location = new Point(22, 62);
            TextQuestionsLable.Name = "TextQuestionsLable";
            TextQuestionsLable.Size = new Size(628, 23);
            TextQuestionsLable.TabIndex = 1;
            TextQuestionsLable.Text = "Текст вопроса";
            TextQuestionsLable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AnswerLabel
            // 
            AnswerLabel.AutoSize = true;
            AnswerLabel.Font = new Font("ISOCPEUR", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            AnswerLabel.Location = new Point(22, 108);
            AnswerLabel.Name = "AnswerLabel";
            AnswerLabel.Size = new Size(50, 21);
            AnswerLabel.TabIndex = 2;
            AnswerLabel.Text = "Ответ";
            // 
            // AnswerUserTextBox
            // 
            AnswerUserTextBox.Location = new Point(94, 108);
            AnswerUserTextBox.Name = "AnswerUserTextBox";
            AnswerUserTextBox.Size = new Size(51, 23);
            AnswerUserTextBox.TabIndex = 3;
            AnswerUserTextBox.TextChanged += AnswerUserTextBox_TextChanged;
            // 
            // NextQuestionButton
            // 
            NextQuestionButton.Font = new Font("ISOCPEUR", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            NextQuestionButton.Location = new Point(22, 148);
            NextQuestionButton.Name = "NextQuestionButton";
            NextQuestionButton.Size = new Size(628, 44);
            NextQuestionButton.TabIndex = 4;
            NextQuestionButton.Text = "Далее";
            NextQuestionButton.UseVisualStyleBackColor = true;
            NextQuestionButton.Click += NextQuestionButton_Click;
            // 
            // StartTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(671, 212);
            Controls.Add(NextQuestionButton);
            Controls.Add(AnswerUserTextBox);
            Controls.Add(AnswerLabel);
            Controls.Add(TextQuestionsLable);
            Controls.Add(QuestionsLabel);
            Name = "StartTest";
            Text = "Test";
            Load += StartTest_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label QuestionsLabel;
        private Label TextQuestionsLable;
        private Label AnswerLabel;
        private TextBox AnswerUserTextBox;
        private Button NextQuestionButton;
    }
}