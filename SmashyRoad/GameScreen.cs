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

        public static bool aDown = false;
        public static bool dDown = false;

        bool gameStarted = false;
        public static bool playerDead = false;

        Car player;

        public static int playerSpeed = 10;

        List<Car> policeCars = new List<Car>();

        SolidBrush brush = new SolidBrush(Color.Green);

        SolidBrush textBrush = new SolidBrush(Color.Black);

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
            //set values
            highScore = false;
            this.Height = Form1.height;
            this.Width = Form1.width;
            settingsRectangle = new Rectangle(this.Width - 200 - 50, this.Height - 200 - 50, 200, 200);
            garageRectangle = new Rectangle(50, this.Height - 200 - 50, 200, 200);
            policeTimer.Interval = Form1.spawnSpeed;
            gameTimer.Enabled = true;
            playerDead = false;
            gameStarted = false;

            //make player
            player = new Car(this.Width / 2, this.Height / 2 + 50, (float)(Math.PI / 4), "player", null);
            

            //make 3x3 chunk grid with player in the middle
            currentChunk = new Chunk(-1500, Form1.height / 2, brush);
            prevChunk = currentChunk;
            MakeChunksAroundPlayer(currentChunk);
        }

        private void MakeChunksAroundPlayer(Chunk currentChunk)
        {
            //make chunks with player in the middle
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
            //if game has started allow turning, collisions
            if (gameStarted)
            {
                //back up if a and d
                if (aDown && dDown && player.speed > -player.maxSpeed)
                {
                    player.speed--;
                }
                //move forward if nothing
                else if (!aDown && !dDown && player.speed <
                    player.maxSpeed)
                {
                    player.speed++;
                }
                //turn left if a 
                else if (aDown && !dDown)
                {
                    player.direction += 0.1f;
                }
                //turn right if d
                else if (dDown && !aDown)
                {
                    player.direction -= 0.1f;
                }

                //move police cars
                foreach (Car c in policeCars)
                {
                    c.Move(player);
                }

                //record what the current chunk is
                prevChunk = currentChunk;

                //collisions
                List<Car> allCars = new List<Car>();

                //put all cars in one list
                foreach (Car car in policeCars) { allCars.Add(car); }
                allCars.Add(player);

                //check for collisions and do collisions
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

            //move chunks based on player velocity
            foreach (Chunk c in chunks)
            {
                c.Move(player.direction, player.speed);
            }

            //see what chunk player is on and make that the middle chunk
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

            //player dies so end game and record score
            if (playerDead)
            {
                gameTimer.Stop();
                policeTimer.Stop();
                scoreTimer.Stop();

                playerScore = Convert.ToInt32(scoreTimer.ElapsedMilliseconds / 100);

                //check for a highscore
                //ez mode
                if (policeTimer.Interval == 5000)
                {
                    //sort scores and remove the lowest to make high score list
                    Form1.eHighScores.Add(playerScore);
                    Form1.eHighScores.Sort();
                    Form1.eHighScores.Reverse();

                    //if player score is a highscore then display that
                    if (playerScore != Form1.eHighScores[Form1.eHighScores.Count - 1])
                    {
                        highScore = true;
                    }

                    Form1.eHighScores.RemoveAt(Form1.eHighScores.Count - 1);

                }
                //medium mode
                else if (policeTimer.Interval == 2000)
                {
                    //sort scores and remove the lowest to make high score list
                    Form1.mHighScores.Add(playerScore);
                    Form1.mHighScores.Sort();
                    Form1.mHighScores.Reverse();

                    //if player score is a highscore then display that
                    if (playerScore != Form1.mHighScores[Form1.mHighScores.Count - 1])
                    {
                        highScore = true;
                    }

                    Form1.mHighScores.RemoveAt(Form1.mHighScores.Count - 1);
                }
                //hard mode
                else if (policeTimer.Interval == 150)
                {
                    //sort scores and remove the lowest to make high score list
                    Form1.hHighScores.Add(playerScore);
                    Form1.hHighScores.Sort();
                    Form1.hHighScores.Reverse();

                    //if player score is a highscore then display that
                    if (playerScore != Form1.hHighScores[Form1.hHighScores.Count - 1])
                    {
                        highScore = true;
                    }

                    Form1.hHighScores.RemoveAt(Form1.hHighScores.Count - 1);
                }

                //save scores to xml after every game
                Form1.SaveScores();
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw chunks
            foreach (Chunk c in chunks)
            {
                e.Graphics.FillPolygon(c.brush, c.points);
                e.Graphics.FillPolygon(new SolidBrush(Color.Gray), c.roadPoints);
            }

            //draw police cars
            foreach (Car c in policeCars)
            {
                c.Draw(e);
            }

            //draw player
            player.Draw(e);

            //if game hasnt started yet display buttons and titles and whatnot
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
                //if game has started display score
                e.Graphics.DrawString($"{scoreTimer.ElapsedMilliseconds / 100}", new Font("Arial", 50), new SolidBrush(Color.White), new Point(50, 50));
            }

            //player is dead display titles and buttons
            if (playerDead)
            {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 255, 0, 0)), rect);

                e.Graphics.DrawString("WRECKED", font, textBrush, new Point(400, 200));

                //if its a high score display the high score
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
                case Keys.A:
                    //start game when a is pressed
                    aDown = true;
                    if (!gameStarted)
                    {
                        gameStarted = true;
                        policeTimer.Enabled = true;
                        scoreTimer.Reset();
                        scoreTimer.Start();

                    }
                    break;
                case Keys.D:
                    //start game when d is pressed
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
                case Keys.A:
                    aDown = false;
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
            //make new police randomly off screen
            Random rand = new Random();
            Point point = new Point(rand.Next(-500, this.Width + 500), rand.Next(-500, this.Height + 500));
            Rectangle rect = new Rectangle(-200, -200, this.Width + 400, this.Height + 400);

            //if police is on screen try again til isnt
            while (rect.Contains(point))
            {
                point = new Point(rand.Next(-500, this.Width + 500), rand.Next(-500, this.Height + 500));
            }

            policeCars.Add(new Car(point.X, point.Y, (float)(Math.PI / 4), "police", player));
        }

        //for button presses without using buttons
        private void GameScreen_MouseDown(object sender, MouseEventArgs e)
        {

            float mouseX = e.X;
            float mouseY = e.Y;

            //garage button click
            if (mouseX < garageRectangle.X + garageRectangle.Width && mouseX > garageRectangle.X && mouseY < garageRectangle.Y + garageRectangle.Height && mouseY > garageRectangle.Y && !gameStarted)
            {
                //go to garage screen
                Form1.ChangeScreen(this, new GarageScreen());
            }
            //high score screen click
            else if (mouseX < garageRectangle.X + garageRectangle.Width && mouseX > garageRectangle.X && mouseY < garageRectangle.Y + garageRectangle.Height && mouseY > garageRectangle.Y && playerDead)
            {
                Form1.ChangeScreen(this, new HighScoreScreen());
            }
            //
            else if (mouseX < settingsRectangle.X + settingsRectangle.Width && mouseX > settingsRectangle.X && mouseY < settingsRectangle.Y + settingsRectangle.Height && mouseY > settingsRectangle.Y && !gameStarted)
            {
                //go to settings screen
                Form1.ChangeScreen(this, new SettingsScreen());
            }
            //back to game screen button click
            else if (mouseX < settingsRectangle.X + settingsRectangle.Width && mouseX > settingsRectangle.X && mouseY < settingsRectangle.Y + settingsRectangle.Height && mouseY > settingsRectangle.Y && playerDead)
            {
                //go to game screen
                Form1.ChangeScreen(this, new GameScreen());
            }
        }
    }
}
