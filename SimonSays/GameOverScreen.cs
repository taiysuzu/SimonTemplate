using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        public static List<int> highscoreList = new List<int>();

        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            //show the length of the pattern
            lengthLabel.Text = $"{Form1.patternList.Count - 1}";
            Highscores();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //close this screen and open the MenuScreen
            Form f = this.FindForm();
            f.Controls.Clear();
            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);
        }

        public void Highscores()
        {   //record and display session high scores
            highscoreList.Add(Form1.patternList.Count - 1);
            highscoreList.Sort();
            highscoreList.Reverse();
            highscoreLabel.Text += $"\n{highscoreList[0]}";
            if (highscoreList.Count > 1)
            {
                highscoreLabel.Text += $"\n{highscoreList[1]}";
            }
            if (highscoreList.Count > 2)
            {
                highscoreLabel.Text += $"\n{highscoreList[2]}";
            }
            if (highscoreList.Count == 4)
            {
                highscoreList.RemoveAt(3);
            }
        }
    }
}
