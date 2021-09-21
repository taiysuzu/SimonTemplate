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
using System.IO;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        public static int guess = 0;                    //TODO: create guess variable to track what part of the pattern the user is at
        Random randGen = new Random();

        Color[] colorArray = new Color[8];
        SoundPlayer[] soundArray = new SoundPlayer[6];
        Button[] buttonArray = new Button[4];

        System.Windows.Media.MediaPlayer backgroundMusic = new System.Windows.Media.MediaPlayer();

        public GameScreen()
        {
            InitializeComponent();

            backgroundMusic.Open(new Uri(Application.StartupPath + "/Resources/Crazy Frog  Axel F.wav"));
            backgroundMusic.MediaEnded += new EventHandler(BackgroundMusicEnded);
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            colorArray[0] = Color.ForestGreen;
            colorArray[1] = Color.LimeGreen;
            colorArray[2] = Color.DarkRed;
            colorArray[3] = Color.Red;
            colorArray[4] = Color.Goldenrod;
            colorArray[5] = Color.Yellow;
            colorArray[6] = Color.DarkBlue;
            colorArray[7] = Color.Blue;

            soundArray[0] = new SoundPlayer(Properties.Resources.green);
            soundArray[1] = new SoundPlayer(Properties.Resources.red);
            soundArray[2] = new SoundPlayer(Properties.Resources.yellow);
            soundArray[3] = new SoundPlayer(Properties.Resources.blue);
            soundArray[4] = new SoundPlayer(Properties.Resources.mistake);
            soundArray[5] = new SoundPlayer(Properties.Resources.Crazy_Frog__Axel_F);

            buttonArray[0] = greenButton;
            buttonArray[1] = redButton;
            buttonArray[2] = yellowButton;
            buttonArray[3] = blueButton;

            Form1.patternList.Clear();                              //TODO: clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            Refresh();
            Thread.Sleep(1000);
            backgroundMusic.Play();
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            Form1.patternList.Add(randGen.Next(0, 3));              //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list

            for (int i = 0; i < Form1.patternList.Count(); i++)        //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            {
                if (Form1.patternList[i] == 0)
                {
                    ButtonColorChange(0, 1, 0, 0);
                }
                if (Form1.patternList[i] == 1)
                {
                    ButtonColorChange(1, 3, 2, 1);
                }
                if (Form1.patternList[i] == 2)
                {
                    ButtonColorChange(2, 5, 4, 2);
                }
                if (Form1.patternList[i] == 3)
                {
                    ButtonColorChange(3, 7, 6, 3);
                }
            }

            guess = 0; //TODO: get guess index value back to 0
        }

        public void GameOver()
        {
            soundArray[4].Play();                                       //TODO: Play a game over sound
            Form f = this.FindForm();                                   //TODO: close this screen and open the GameOverScreen
            f.Controls.Clear();
            GameOverScreen gos = new GameOverScreen();
            f.Controls.Add(gos);
        }

        public void ButtonColorChange(int button, int light, int dark, int sound)
        {
            buttonArray[button].BackColor = colorArray[light];
            soundArray[sound].Play();
            Refresh();
            Thread.Sleep(1000);
            buttonArray[button].BackColor = colorArray[dark];
            Refresh();
            Thread.Sleep(800);
        }
        public void EndOfPattern()
        {
            if (Form1.patternList.Count == guess)
            {
                ComputerTurn();
            }
        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[guess] == 0)                          //TODO: is the value at current guess index equal to a green. If so:
            {
                ButtonColorChange(0, 1, 0, 0);                    // light up button, play sound, and pause // set button colour back to original
                guess++;                                               // add one to the guess index
                EndOfPattern();                      // check to see if we are at the end of the pattern. If so call ComputerTurn() method
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
                ButtonColorChange(1, 3, 2, 1);
                guess++;
                EndOfPattern();
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
                ButtonColorChange(2, 5, 4, 2);
                guess++;
                EndOfPattern();
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
                ButtonColorChange(3, 7, 6, 3);
                guess++;
                EndOfPattern();
            }
            else
            {
                GameOver();
            }
        }

        private void BackgroundMusicEnded(object sender, EventArgs e)
        {
            backgroundMusic.Stop();
            backgroundMusic.Play();
        }
    }
}
