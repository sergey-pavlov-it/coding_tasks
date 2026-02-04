namespace GeniusIdiotFormApp
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nextButtin = new Button();
            questionNumberLabel = new Label();
            questionTextLable = new Label();
            userAnswerTextBox = new TextBox();
            SuspendLayout();
            // 
            // nextButtin
            // 
            nextButtin.Font = new Font("ISOCPEUR", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            nextButtin.Location = new Point(108, 257);
            nextButtin.Name = "nextButtin";
            nextButtin.Size = new Size(170, 104);
            nextButtin.TabIndex = 0;
            nextButtin.Text = "Далее";
            nextButtin.UseVisualStyleBackColor = true;
            nextButtin.Click += nextButtin_Click;
            // 
            // questionNumberLabel
            // 
            questionNumberLabel.AutoSize = true;
            questionNumberLabel.Font = new Font("ISOCPEUR", 12F);
            questionNumberLabel.Location = new Point(52, 48);
            questionNumberLabel.Name = "questionNumberLabel";
            questionNumberLabel.Size = new Size(76, 21);
            questionNumberLabel.TabIndex = 1;
            questionNumberLabel.Text = "Вопрос №1";
            // 
            // questionTextLable
            // 
            questionTextLable.AutoSize = true;
            questionTextLable.Font = new Font("ISOCPEUR", 12F);
            questionTextLable.Location = new Point(52, 95);
            questionTextLable.Name = "questionTextLable";
            questionTextLable.Size = new Size(102, 21);
            questionTextLable.TabIndex = 2;
            questionTextLable.Text = "Текст вопроса";
            // 
            // userAnswerTextBox
            // 
            userAnswerTextBox.Location = new Point(52, 139);
            userAnswerTextBox.Name = "userAnswerTextBox";
            userAnswerTextBox.Size = new Size(100, 23);
            userAnswerTextBox.TabIndex = 3;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(418, 419);
            Controls.Add(userAnswerTextBox);
            Controls.Add(questionTextLable);
            Controls.Add(questionNumberLabel);
            Controls.Add(nextButtin);
            ForeColor = SystemColors.ControlText;
            Name = "mainForm";
            Text = "Genius/Idiot";
            Load += mainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button nextButtin;
        private Label questionNumberLabel;
        private Label questionTextLable;
        private TextBox userAnswerTextBox;
    }
}
