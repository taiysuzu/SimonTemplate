using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        public static int guess = 0;                    //TODO: create guess variable to track what part of the pattern the user is at
        Random randGen = new Random();

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Form1.patternList.Clear();                              //TODO: clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            Refresh();
            Thread.Sleep(1000);
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            Form1.patternList.Add(randGen.Next(0, 3));              //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list

            for (int i = 0; i < Form1.patternList.Count(); i++)        //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            {
                if (Form1.patternList[i] == 0)
                {
                    greenButton.BackColor = Color.LimeGreen;
                    Refresh();
                    Thread.Sleep(1000);
                    greenButton.BackColor = Color.ForestGreen;
                    Refresh();
                    Thread.Sleep(1000);
                }
                if (Form1.patternList[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    Refresh();
                    Thread.Sleep(1000);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                    Thread.Sleep(1000);
                }
                if (Form1.patternList[i] == 2)
                {
                    yellowButton.BackColor = Color.Yellow;
                    Refresh();
                    Thread.Sleep(1000);
                    yellowButton.BackColor = Color.Goldenrod;
                    Refresh();
                    Thread.Sleep(1000);
                }
                if (Form1.patternList[i] == 3)
                {
                    blueButton.BackColor = Color.Blue;
                    Refresh();
                    Thread.Sleep(1000);
                    blueButton.BackColor = Color.DarkBlue;
                    Refresh();
                    Thread.Sleep(1000);
                }
            }

            guess = 0; //TODO: get guess index value back to 0
        }

        public void GameOver()
        {
            //TODO: Play a game over sound

            //TODO: close this screen and open the GameOverScreen
            Form f = this.FindForm();
            f.Controls.Clear();
            GameOverScreen gos = new GameOverScreen();
            f.Controls.Add(gos);
        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[guess] == 0)                          //TODO: is the value at current guess index equal to a green. If so:
            {
                greenButton.BackColor = Color.LimeGreen;                    // light up button, play sound, and pause

                Refresh();
                Thread.Sleep(1000);
                greenButton.BackColor = Color.ForestGreen;              // set button colour back to original
                Refresh();
                Thread.Sleep(1000);
                guess++;                                               // add one to the guess index
                
                if (Form1.patternList.Count == guess)                      // check to see if we are at the end of the pattern. If so:
                {
                    ComputerTurn();                     // call ComputerTurn() method
                }
            }
            else
            {
                GameOver();                             // else call GameOver method
            }
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[guess] == 1)
            {
                redButton.BackColor = Color.Red;

                Refresh();
                Thread.Sleep(1000);
                redButton.BackColor = Color.DarkRed;
                Refresh();
                Thread.Sleep(1000);
                guess++;
                if (Form1.patternList.Count == guess)
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[guess] == 2)
            {
                yellowButton.BackColor = Color.Yellow;

                Refresh();
                Thread.Sleep(1000);
                yellowButton.BackColor = Color.Goldenrod;
                Refresh();
                Thread.Sleep(1000);
                guess++;
                if (Form1.patternList.Count == guess)
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[guess] == 3)
            {
                blueButton.BackColor = Color.Blue;

                Refresh();
                Thread.Sleep(1000);
                blueButton.BackColor = Color.DarkBlue;
                Refresh();
                Thread.Sleep(1000);
                guess++;
                if (Form1.patternList.Count == guess)
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }
    }
}
