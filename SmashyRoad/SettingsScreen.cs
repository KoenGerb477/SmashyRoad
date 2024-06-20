using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmashyRoad
{
    public partial class SettingsScreen : UserControl
    {
        public SettingsScreen()
        {
            InitializeComponent();
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            Form1.spawnSpeed = 2000;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            Form1.spawnSpeed = 5000;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            Form1.spawnSpeed = 150;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void backOrangeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
