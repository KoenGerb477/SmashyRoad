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
            //display high scores
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
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //go back to game screen
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
