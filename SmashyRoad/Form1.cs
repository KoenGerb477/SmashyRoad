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
using System.Media;

namespace SmashyRoad
{
    public partial class Form1 : Form
    {
        public static int height;
        public static int width;
        public static int spawnSpeed = 5000;
        public static string carSelected = "car1";

        public static List<int> eHighScores = new List<int>();
        public static List<int> mHighScores = new List<int>();
        public static List<int> hHighScores = new List<int>();

        public static System.Windows.Media.MediaPlayer backSound = new System.Windows.Media.MediaPlayer();

        public Form1()
        {
            InitializeComponent();

            backSound.Open(new Uri(Application.StartupPath + "\\Resources\\Ragtime Piano _ SCOTT JOPLIN . The Entertainer (1902).wav"));
            backSound.MediaEnded += new EventHandler(backSoundEnded);
            backSound.Play();

            LoadScores();

            height = this.Height;
            width = this.Width;

            //open main screen
            ChangeScreen(this, new GameScreen());
        }

        private void backSoundEnded(object sender, EventArgs e)
        {
            backSound.Stop();
            backSound.Play();
        }

        public void LoadScores()
        {
            XmlReader reader = XmlReader.Create("HighScores.xml");

            int counter = 1;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    //reader.ReadToFollowing("Score");

                    int score = Convert.ToInt32(reader.ReadString());

                    if(counter <= 3)
                    {
                        Form1.eHighScores.Add(score);
                    }
                    else if(counter <= 6)
                    {
                        Form1.mHighScores.Add(score);
                    }
                    else if (counter <= 9)
                    {
                        Form1.hHighScores.Add(score);
                    }

                    counter++;
                }
            }

            reader.Close();
        }

        public static void SaveScores()
        {
            XmlWriter writer = XmlWriter.Create("HighScores.xml", null);

            writer.WriteStartElement("ScoreList");

            foreach (int s in eHighScores)
            {
                writer.WriteStartElement("Score");
                writer.WriteString(s.ToString());
                writer.WriteEndElement();
            }
            foreach (int s in mHighScores)
            {
                writer.WriteStartElement("Score");
                writer.WriteString(s.ToString());
                writer.WriteEndElement();
            }
            foreach (int s in hHighScores)
            {
                writer.WriteStartElement("Score");
                writer.WriteString(s.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();
        }


        //method to change screens
        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; // will either be the sender or parent of sender

            if (sender is Form)
            {
                f = (Form)sender;                          //f is sender
            }
            else
            {
                UserControl current = (UserControl)sender;  //create UserControl from sender
                f = current.FindForm();                     //find Form UserControl is on
                f.Controls.Remove(current);                 //remove current UserControl
            }

            // add the new UserControl to the middle of the screen and focus on it
            next.Location = new Point((f.ClientSize.Width - next.Width) / 2, (f.ClientSize.Height - next.Height) / 2);
            f.Controls.Add(next);
            next.Focus();
        }
    }
}
