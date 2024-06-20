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
    public partial class GarageScreen : UserControl
    {
        public GarageScreen()
        {
            InitializeComponent();
        }

        //go back to game
        private void backButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }

        //select colour and go back to game
        private void car1_Click(object sender, EventArgs e)
        {
            Form1.carSelected = "car1";
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void car2Button_Click(object sender, EventArgs e)
        {
            Form1.carSelected = "car2";
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void car3Button_Click(object sender, EventArgs e)
        {
            Form1.carSelected = "car3";
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void car4Button_Click(object sender, EventArgs e)
        {
            Form1.carSelected = "car4";
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void car5Button_Click(object sender, EventArgs e)
        {
            Form1.carSelected = "car5";
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void car6Button_Click(object sender, EventArgs e)
        {
            Form1.carSelected = "car6";
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
