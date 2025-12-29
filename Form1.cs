using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XO_Game.Properties;

namespace XO_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255,255,255,255);

            Pen Pen = new Pen(White);

            Pen.Width = 15;
            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(Pen, 360, 230, 980, 230);
            e.Graphics.DrawLine(Pen, 360, 400, 980, 400);


            e.Graphics.DrawLine(Pen, 550, 80, 550, 530);
            e.Graphics.DrawLine(Pen, 800, 80, 800, 530);
        }

        enum enPlayer { Player1, Player2 };

        enum enWinner
        {
           Player1, Player2, Draw,GameInProgress
        }
        struct stGameStatus
        {
            public short PlayCount;
            public enWinner Winner;
            public bool GameOver;
        }

        stGameStatus GameStatus;

        enPlayer PlayerTurn = enPlayer.Player1;

        void EndGame()
        {

            lblTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {

                case enWinner.Player1:

                    lblWinner.Text = "Player1";
                    break;

                case enWinner.Player2:

                    lblWinner.Text = "Player2";
                    break;

                default:

                    lblWinner.Text = "Draw";
                    break;

            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        bool CheckValue(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() &&  btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if(btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
             

            }
            GameStatus.GameOver = false;
            return false;
        }
        void CheckWinner()
        {

            if (CheckValue(button1,button2,button3))
                return;
            if (CheckValue(button4, button5, button6))
                return;
            if (CheckValue(button7, button8, button9))
                return;
            if (CheckValue(button1, button4, button7))
                return;
            if (CheckValue(button2, button5, button8))
                return;
            if (CheckValue(button3, button6, button9))
                return;
            if (CheckValue(button1, button5, button9))
                return;
            if (CheckValue(button3, button5, button7))
                return;
        }

        void ResetButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }
        void ResetGame()
        {
            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);


            lblTurn.Text = "Player1";
            lblWinner.Text = "In Progress";
            PlayerTurn = enPlayer.Player1;
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;

        }
        public void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?" && lblTurn.Text != "Game Over")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        lblTurn.Text = "Player2";
                        PlayerTurn = enPlayer.Player2;
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        lblTurn.Text = "Player1";
                        PlayerTurn = enPlayer.Player1;
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
                
            }
            else
            { 
                MessageBox.Show("Wrong Choise", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ChangeImage(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeImage(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeImage(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeImage(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeImage(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeImage(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeImage(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeImage(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeImage(button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
