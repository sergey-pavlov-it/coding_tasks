namespace GeniusIdiotFormApp
{
    partial class AddDeleteQuestions
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
            listBoxQuestions = new ListBox();
            SuspendLayout();
            // 
            // listBoxQuestions
            // 
            listBoxQuestions.FormattingEnabled = true;
            listBoxQuestions.Location = new Point(12, 12);
            listBoxQuestions.Name = "listBoxQuestions";
            listBoxQuestions.Size = new Size(681, 154);
            listBoxQuestions.TabIndex = 0;
            listBoxQuestions.SelectedIndexChanged += listBoxQuestions_SelectedIndexChanged;
            // 
            // AddDeleteQuestions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxQuestions);
            ForeColor = SystemColors.GrayText;
            Name = "AddDeleteQuestions";
            Text = "AddDeleteQuestionsForm";
            Load += AddDeleteQuestions_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxQuestions;
    }
}