using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Drawing;
using Storytelling;

namespace Chibogers_TheFoodpocalyse_1._0._0 {
    //frontend
    internal class Program {
        static void Main(string[] args) 
        {
            Application.EnableVisualStyles();
            Application.Run(new MainMenu());
        } //test test
    }
    class MainMenu : Form
    {
        public Button btnStartGame = new Button();
        public Button btnCheckHighscores = new Button();
        public Button btnCheckInv = new Button();
        public Button btnExitGame = new Button();

        public MainMenu()
        {
            Text = "Chibogers";
            ControlBox = false;

            Controls.Add(btnStartGame);
            btnStartGame.Text = "Start Game";
            btnStartGame.Dock = DockStyle.Bottom;
            btnStartGame.FlatStyle = FlatStyle.Popup;
            btnStartGame.Click += new EventHandler(btnStartGame_click);
            btnStartGame.MouseLeave += (s, e) => btnStartGame.BackColor = Color.WhiteSmoke;
            btnStartGame.MouseHover += (s, e) => btnStartGame.BackColor = Color.YellowGreen;
            //btnStartGame.Location = new Point(100, 100);

            Controls.Add(btnCheckHighscores);
            btnCheckHighscores.Text = "Check Highscores";
            btnCheckHighscores.Dock = DockStyle.Bottom;
            btnCheckHighscores.FlatStyle = FlatStyle.Popup;
            btnCheckHighscores.Click += new EventHandler(btnCheckHighscores_click);
            btnCheckHighscores.MouseLeave += (s, e) => btnCheckHighscores.BackColor = Color.WhiteSmoke;
            btnCheckHighscores.MouseHover += (s, e) => btnCheckHighscores.BackColor = Color.YellowGreen;
            //btnCheckHighscores.Location = new Point(85, 150); 

            Controls.Add(btnExitGame);
            btnExitGame.Text = "Exit Game";
            btnExitGame.Dock = DockStyle.Bottom;
            btnExitGame.FlatStyle = FlatStyle.Popup;
            btnExitGame.Click += new EventHandler(btnExitGame_click);
            btnExitGame.MouseLeave += (s, e) => btnExitGame.BackColor = Color.WhiteSmoke;
            btnExitGame.MouseHover += (s, e) => btnExitGame.BackColor = Color.YellowGreen;
            //btnExitGame.Location = new Point(100, 200);
        }

        void btnStartGame_click(object sender, EventArgs e)
        {
            Game game = new Game();
            //if clinose ang game window, return to main menu
            game.FormClosed += new FormClosedEventHandler(ReturnToMainMenu);
            //start game, hide main menu, show the game window
            this.Hide();
            game.Show();
        }

        void btnCheckHighscores_click(object sender, EventArgs e)
        {
            List<ScoreEntry> scores = Leaderboards.LoadScores();
            scores.Sort((a, b) => b.Score.CompareTo(a.Score));

            
            string highScoresText = "Top 10 Highest Scores:\n\n";

            // display upto only 10 highest scores
            for (int i = 0; i < Math.Min(scores.Count, 10); i++)
            {
                highScoresText += $"{i + 1}. {scores[i].PlayerName}: {scores[i].Score}\n";
            }
            MessageBox.Show(highScoresText, "Leaderboard");
        }

        void btnExitGame_click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ReturnToMainMenu(object sender, EventArgs e)
        {
            this.Show();
        }
    }

    //BackEnd
    
    class GamerWeather
    {
        Random randomVal = new Random();
        public string[] climate = { "Heat Wave", "Blizzard", "Heavy Rain", "Sluggish Bog" };
        public bool WeatherPresent()
        {
            int weatherChance = randomVal.Next(1, 10);
            if (weatherChance <= 5) return false;
            else return true;
        }

        public string GetWeather()
        {
            string weatherName = " ";
            int weather = randomVal.Next(1, 4);
            switch (weather)
            {
                case 1: weatherName = climate[0]; break;
                case 2: weatherName = climate[1]; break;
                case 3: weatherName = climate[2]; break;
                case 4: weatherName = climate[3]; break;
            }
            return weatherName;
        }
        public int weatherEffect(string weatherName)
        {
            int weatherEffect = 0;
            if (weatherName == climate[0]) { int hpReduction = 20; weatherEffect = hpReduction; }
            else if (weatherName == climate[1]) { int turnsToAttack = 2; weatherEffect = turnsToAttack; }
            else if (weatherName == climate[2]) { int accuracyReduc = 5; weatherEffect = accuracyReduc; }
            else if (weatherName == climate[3]) { int atkAndDefReduc = 10; weatherEffect = atkAndDefReduc; }
            return weatherEffect;
        }
    }
        //moved inventory to invetory file
}
