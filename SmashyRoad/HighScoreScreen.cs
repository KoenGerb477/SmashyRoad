using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SmashyRoad
{
    public partial class HighScoreScreen : UserControl
    {
        public HighScoreScreen()
        {
            InitializeComponent();
            DisplayScores();
        }

        public void DisplayScores()
        {
            for (int i = 0; i < Form1.eHighScores.Count; i++)
            {
                easyScoresLabel.Text += $"{i + 1}. {Form1.eHighScores[i]}\n";
            }
            for (int i = 0; i < Form1.mHighScores.Count; i++)
            {
                mediumScoresLabel.Text += $"{i + 1}. {Form1.mHighScores[i]}\n";
            }
            for (int i = 0; i < Form1.hHighScores.Count; i++)
            {
                hardScoresLabel.Text += $"{i + 1}. {Form1.hHighScores[i]}\n";
            }

            //easyScoresLabel.Text += $"1. {Form1.highScores[0].name} - {Form1.highScores[0].score}\n";
            //easyScoresLabel.Text += $"2. {Form1.highScores[1].name} - {Form1.highScores[1].score}\n";
            //easyScoresLabel.Text += $"3. {Form1.highScores[2].name} - {Form1.highScores[2].score}\n";
            //mediumScoresLabel.Text += $"1. {Form1.highScores[3].name} - {Form1.highScores[3].score}\n";
            //mediumScoresLabel.Text += $"2. {Form1.highScores[4].name} - {Form1.highScores[4].score}\n";
            //mediumScoresLabel.Text += $"3. {Form1.highScores[5].name} - {Form1.highScores[5].score}\n";
            //hardScoresLabel.Text += $"1. {Form1.highScores[6].name} - {Form1.highScores[6].score}\n";
            //hardScoresLabel.Text += $"2. {Form1.highScores[7].name} - {Form1.highScores[7].score}\n";
            //hardScoresLabel.Text += $"3. {Form1.highScores[8].name} - {Form1.highScores[8].score}\n";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
