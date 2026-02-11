using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using GeniusIdiotClassLibrary;
using GeniusIdiotConsoleApp.Application;
using GeniusIdiotConsoleApp.Domain;
using GeniusIdiotConsoleApp.Infrastructure;



namespace GeniusIdiotFormApp
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var userName = PromptName("Начать тест", "Введите имя:");
            if (string.IsNullOrWhiteSpace(userName))
                return;

            User currentUser = new User(userName);

            var startTest = new StartTest(currentUser);
            startTest.FormClosed += (s, args) => this.Show();
            startTest.Show();
            this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static string? PromptName(string title, string message)
        {
            using var form = new Form
            {
                Text = title,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false,
                Width = 360,
                Height = 160
            };

            var label = new Label { Left = 12, Top = 12, Width = 320, Text = message };
            var textBox = new TextBox { Left = 12, Top = 40, Width = 320 };
            var ok = new Button { Text = "OK", Left = 176, Width = 75, Top = 75, DialogResult = DialogResult.OK };
            var cancel = new Button { Text = "Отмена", Left = 257, Width = 75, Top = 75, DialogResult = DialogResult.Cancel };

            form.Controls.AddRange(new Control[] { label, textBox, ok, cancel });
            form.AcceptButton = ok;
            form.CancelButton = cancel;

            return form.ShowDialog() == DialogResult.OK
                ? textBox.Text.Trim()
                : null;
        }
    }
}
