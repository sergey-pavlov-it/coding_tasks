namespace GeniusIdiotFormApp
{
    partial class StartMenu
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
            textBox1 = new TextBox();
            StartButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ScrollBar;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("ISOCPEUR", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.ForeColor = SystemColors.HotTrack;
            textBox1.Location = new Point(252, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(292, 40);
            textBox1.TabIndex = 0;
            textBox1.Text = "GENIUS or IDIOT";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // StartButton
            // 
            StartButton.BackColor = SystemColors.Menu;
            StartButton.Font = new Font("ISOCPEUR", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            StartButton.ForeColor = SystemColors.ControlText;
            StartButton.Location = new Point(335, 90);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(135, 60);
            StartButton.TabIndex = 1;
            StartButton.Text = "Начать тест";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            // 
            // StartMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(800, 450);
            Controls.Add(StartButton);
            Controls.Add(textBox1);
            Name = "StartMenu";
            Text = "StartMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button StartButton;
    }
}