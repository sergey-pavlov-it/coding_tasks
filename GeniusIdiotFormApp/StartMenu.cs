using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

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
            var startTest = new StartTest();
            startTest.FormClosed += (s, args) => this.Show();
            startTest.Show();
            this.Hide();
        }
    }
}
