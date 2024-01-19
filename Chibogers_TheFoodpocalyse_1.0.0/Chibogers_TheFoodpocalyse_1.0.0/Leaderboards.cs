using System.Collections.Generic;
using System.IO;

namespace Chibogers_TheFoodpocalyse_1._0._0
{
    internal class Leaderboards 
    {

        public static List<ScoreEntry> LoadScores()
        {
            if (File.Exists("Scores.txt"))
            {
                string[] scoreLines = File.ReadAllLines("Scores.txt");

                List<ScoreEntry> scores = new List<ScoreEntry>();
                for (int i = 0; i < scoreLines.Length; i += 2)
                {
                    if (i + 1 < scoreLines.Length)
                    {
                        if (scoreLines[i].StartsWith("Player Name:") && scoreLines[i + 1].StartsWith("Highest Floor Reached:"))
                        {
                            string playerName = scoreLines[i].Replace("Player Name: ", string.Empty);
                            if (int.TryParse(scoreLines[i + 1].Replace("Highest Floor Reached:", string.Empty), out int score))
                            {
                                scores.Add(new ScoreEntry(playerName, score));
                            }
                        }
                    }
                }
                return scores;
            }
            return new List<ScoreEntry>();
        }

    }

    public class ScoreEntry
    {
        private string playerName;
        private int score;

        public ScoreEntry(string playerName, int score)
        {
            PlayerName = playerName;
            Score = score;
        }
        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
