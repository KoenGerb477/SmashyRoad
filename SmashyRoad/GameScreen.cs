using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SmashyRoad
{
    public partial class GameScreen : UserControl
    {
        List<Chunk> chunks = new List<Chunk>();
        Chunk prevChunk;
        Chunk currentChunk;

        public static bool wDown = false;
        public static bool aDown = false;
        public static bool sDown = false;
        public static bool dDown = false;

        bool gameStarted = false;
        public static bool playerDead = false;

        Car player;

        public static int playerSpeed = 10;

        List<Car> policeCars = new List<Car>();

        SolidBrush brush = new SolidBrush(Color.Green);

        SolidBrush textBrush = new SolidBrush(Color.Black);

        List<PointF> arrowPoints = new List<PointF>();

        //List<Car> obstacleCars = new List<PointF>();

        Rectangle settingsRectangle;
        Rectangle garageRectangle;

        Stopwatch scoreTimer = new Stopwatch();

        bool highScore;
        int playerScore;


        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        private void OnStart()
        {
            highScore = false;


            player = new Car(this.Width / 2 + 100, this.Height / 2 + 100, (float)(Math.PI / 4), "player", null);
            //policeCars.Add(new Car(700, 200, (float)(Math.PI / 4), "police", player));
            //policeCars.Add(new Car(900, 400, (float)(Math.PI / 4), "police"));

            currentChunk = new Chunk(-1500, Form1.height / 2, brush);
            //chunks[4] = currentChunk;
            prevChunk = currentChunk;

            MakeChunksAroundPlayer(currentChunk);

            this.Height = Form1.height; // Form1.height;
            this.Width = Form1.width;

            settingsRectangle = new Rectangle(this.Width - 200 - 50, this.Height - 200 - 50, 200, 200);
            garageRectangle = new Rectangle(50, this.Height - 200 - 50, 200, 200);

            policeTimer.Interval = Form1.spawnSpeed;
            gameTimer.Enabled = true;

            playerDead = false;
            gameStarted = false;
        }

        private void MakeChunksAroundPlayer(Chunk currentChunk)
        {
            chunks.Add(new Chunk(currentChunk.x - currentChunk.size, currentChunk.y, brush));
            chunks.Add(new Chunk(chunks[0].points[3].X, chunks[0].points[3].Y, brush));
            chunks.Add(new Chunk(currentChunk.x, currentChunk.y + currentChunk.size, brush));
            chunks.Add(new Chunk(chunks[0].points[1].X, chunks[0].points[1].Y, brush));
            chunks.Add(new Chunk(currentChunk.x, currentChunk.y, currentChunk.brush));
            chunks.Add(new Chunk(currentChunk.points[3].X, currentChunk.points[3].Y, brush));
            chunks.Add(new Chunk(currentChunk.x, currentChunk.y - currentChunk.size, brush));
            chunks.Add(new Chunk(currentChunk.points[1].X, currentChunk.points[1].Y, brush));
            chunks.Add(new Chunk(currentChunk.points[2].X, currentChunk.points[2].Y, brush));
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                if (aDown && dDown && player.speed > -player.maxSpeed)
                {
                    player.speed--;
                }
                else if (!aDown && !dDown && player.speed <
                    player.maxSpeed)
                {
                    player.speed++;
                }
                else if (aDown && !dDown)
                {
                    player.direction += 0.1f;
                }
                else if (dDown && !aDown)
                {
                    player.direction -= 0.1f;
                }

                foreach (Car c in policeCars)
                {
                    c.Move(player);
                }

                prevChunk = currentChunk;

                //collisions
                List<Car> allCars = new List<Car>();
                foreach (Car car in policeCars) { allCars.Add(car); }

                allCars.Add(player);

                for (int i = 0; i < allCars.Count; i++)
                {
                    for (int j = 0; j < allCars.Count; j++)
                    {
                        if (i == j) { break; }

                        if (allCars[i].CheckCollision(allCars[j]))
                        {

                            allCars[i].Collide();
                            allCars[j].Collide();
                        }
                    }
                }

                //remove dead cops off screen
                for(int i = 0; i < policeCars.Count; i++)
                {
                    if(!policeCars[i].living && (policeCars[i].drawPoints[0].X < -500 || policeCars[i].drawPoints[0].X > this.Width + 500) && (policeCars[i].drawPoints[0].Y < -500 || policeCars[i].drawPoints[0].Y > this.Height + 500))
                    {
                        policeCars.RemoveAt(i);
                    }
                }
            }

            foreach (Chunk c in chunks)
            {
                c.Move(player.direction, player.speed);
            }

            for (int i = 0; i < chunks.Count; i++)
            {
                if (chunks[i].IsPointInPolygon(chunks[i].points.ToArray(), new PointF(player.x, player.y)))
                {
                    currentChunk = chunks[i];

                    if (prevChunk.x != currentChunk.x && prevChunk.y != currentChunk.y)
                    {
                        chunks.Clear();
                        MakeChunksAroundPlayer(currentChunk);
                    }

                    break;
                }
            }

            if (playerDead)
            {
                playerScore = Convert.ToInt32(scoreTimer.ElapsedMilliseconds / 100);

                gameTimer.Stop();
                policeTimer.Stop();
                scoreTimer.Stop();

                //check for a highscore
                if (policeTimer.Interval == 5000)
                {
                    Form1.eHighScores.Add(playerScore);
                    Form1.eHighScores.Sort();
                    Form1.eHighScores.Reverse();

                    if (playerScore != Form1.eHighScores[Form1.eHighScores.Count - 1])
                    {
                        highScore = true;
                    }

                    Form1.eHighScores.RemoveAt(Form1.eHighScores.Count - 1);


                }
                else if (policeTimer.Interval == 2000)
                {
                    Form1.mHighScores.Add(playerScore);
                    Form1.mHighScores.Sort();
                    Form1.mHighScores.Reverse();

                    if (playerScore != Form1.mHighScores[Form1.mHighScores.Count - 1])
                    {
                        highScore = true;
                    }

                    Form1.mHighScores.RemoveAt(Form1.mHighScores.Count - 1);
                }
                else if (policeTimer.Interval == 150)
                {
                    Form1.hHighScores.Add(playerScore);
                    Form1.hHighScores.Sort();
                    Form1.hHighScores.Reverse();

                    if (playerScore != Form1.hHighScores[Form1.hHighScores.Count - 1])
                    {
                        highScore = true;
                    }

                    Form1.hHighScores.RemoveAt(Form1.hHighScores.Count - 1);
                }

                Form1.SaveScores();
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Chunk c in chunks)
            {
                e.Graphics.FillPolygon(c.brush, c.points);
                e.Graphics.FillPolygon(new SolidBrush(Color.Gray), c.roadPoints);
            }

            foreach (Car c in policeCars)
            {
                c.Draw(e);
            }

            player.Draw(e);

            SolidBrush orange = new SolidBrush(Color.Orange);
            Font font = new Font("Arial", 106);

            if (!gameStarted)
            {
                e.Graphics.DrawString("SMASHY ROAD", font, textBrush, new Point(200, 100));
                e.Graphics.FillRectangle(orange, 275, 375, 300, 300);
                e.Graphics.DrawString("A", font, textBrush, new Point(350, 450));
                e.Graphics.FillRectangle(orange, this.Width - 250 - 325, 375, 300, 300);
                e.Graphics.DrawString("D", font, textBrush, new Point(this.Width - 200 - 200 - 100, 450));

                e.Graphics.FillRectangle(orange, settingsRectangle);
                e.Graphics.DrawImage(Properties.Resources.gear, settingsRectangle);
                e.Graphics.FillRectangle(orange, garageRectangle);
                e.Graphics.DrawImage(Properties.Resources.Car_icon_alone, garageRectangle);
            }
            else
            {
                e.Graphics.DrawString($"{scoreTimer.ElapsedMilliseconds / 100}", new Font("Arial", 50), new SolidBrush(Color.White), new Point(50, 50));
            }

            if (playerDead)
            {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 255, 0, 0)), rect);

                e.Graphics.DrawString("WRECKED", font, textBrush, new Point(400, 200));
                if (highScore)
                {
                    e.Graphics.DrawString($"HIGH SCORE: {playerScore}", font, textBrush, new Point(100, 350));
                }

                e.Graphics.FillRectangle(orange, settingsRectangle);
                e.Graphics.DrawString(">", font, textBrush, settingsRectangle.X + 20, settingsRectangle.Y + 20);

                e.Graphics.FillRectangle(orange, garageRectangle);
                e.Graphics.DrawImage(Properties.Resources.Trophy, garageRectangle.X + 20, garageRectangle.Y + 20, garageRectangle.Width - 40, garageRectangle.Height - 40);
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    if (!gameStarted)
                    {
                        gameStarted = true;
                        policeTimer.Enabled = true;
                        scoreTimer.Reset();
                        scoreTimer.Start();

                    }
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    if (!gameStarted)
                    {
                        gameStarted = true;
                        policeTimer.Enabled = true;
                        scoreTimer.Reset();
                        scoreTimer.Start();
                    }
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                default:
                    break;
            }
        }

        private void policeTimer_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            Point point = new Point(rand.Next(-500, this.Width + 500), rand.Next(-500, this.Height + 500));
            Rectangle rect = new Rectangle(-200, -200, this.Width + 400, this.Height + 400);
            while (rect.Contains(point))
            {
                point = new Point(rand.Next(-500, this.Width + 500), rand.Next(-500, this.Height + 500));
            }

            policeCars.Add(new Car(point.X, point.Y, (float)(Math.PI / 4), "police", player));
        }

        private void GameScreen_MouseDown(object sender, MouseEventArgs e)
        {
            float mouseX = e.X;
            float mouseY = e.Y;

            if (mouseX < garageRectangle.X + garageRectangle.Width && mouseX > garageRectangle.X && mouseY < garageRectangle.Y + garageRectangle.Height && mouseY > garageRectangle.Y && !gameStarted)
            {
                //go to garage screen
                Form1.ChangeScreen(this, new GarageScreen());
            }
            else if (mouseX < garageRectangle.X + garageRectangle.Width && mouseX > garageRectangle.X && mouseY < garageRectangle.Y + garageRectangle.Height && mouseY > garageRectangle.Y && playerDead)
            {
                Form1.ChangeScreen(this, new HighScoreScreen());
            }
            else if (mouseX < settingsRectangle.X + settingsRectangle.Width && mouseX > settingsRectangle.X && mouseY < settingsRectangle.Y + settingsRectangle.Height && mouseY > settingsRectangle.Y && !gameStarted)
            {
                //go to settings screen
                Form1.ChangeScreen(this, new SettingsScreen());
            }
            else if (mouseX < settingsRectangle.X + settingsRectangle.Width && mouseX > settingsRectangle.X && mouseY < settingsRectangle.Y + settingsRectangle.Height && mouseY > settingsRectangle.Y && playerDead)
            {
                Form1.ChangeScreen(this, new GameScreen());
            }
        }
    }
}
