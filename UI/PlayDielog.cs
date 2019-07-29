using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ex02_OthelloGame;

namespace Ex05_OtheloFormsApp
{
    public partial class PlayDielog : Form
    {
        const int k_SizeOfButton = 45;
        ButtonOthelo[,] m_BoardGameDielog;
        bool m_IsFtHuman;
        int m_SizeBoard;
        Point m_MoveCurrentPlayer;

        public Point PointCurrentPlayer { get => m_MoveCurrentPlayer; }

        public PlayDielog(int i_SizeBoard, bool i_IsFtHuman)
        {
            m_SizeBoard = i_SizeBoard;
            this.m_BoardGameDielog = new ButtonOthelo[i_SizeBoard, i_SizeBoard];
            this.m_IsFtHuman = i_IsFtHuman;
            InitializeComponent();
            
            AddButtonToBoard();
            this.Width = (m_SizeBoard * k_SizeOfButton) + 35;
            this.Height = (m_SizeBoard * k_SizeOfButton) + 56;
        }

          public void UpdateBoard(eCoin[,] i_DataBord, List<Point> i_OptionMove)
        {
            for (int row = 0; row < m_SizeBoard; row++)
            {
                for (int colum = 0; colum < m_SizeBoard; colum++)
                {
                    switch (i_DataBord[row, colum])
                    {
                        case eCoin.BLACK:
                            m_BoardGameDielog[row, colum].BackColor = Color.Black;
                            m_BoardGameDielog[row, colum].Text = "O";
                            m_BoardGameDielog[row, colum].ForeColor = Color.White;
                            break;
                        case eCoin.WHITE:
                            m_BoardGameDielog[row, colum].BackColor = Color.White;
                            m_BoardGameDielog[row, colum].Text = "O";
                            m_BoardGameDielog[row, colum].ForeColor = Color.Black;
                            break;
                        case eCoin.EMPTY:
                            m_BoardGameDielog[row, colum].BackColor = Color.Gainsboro;
                            m_BoardGameDielog[row, colum].Text = string.Empty;
                            break;
                        default:
                            break;
                    }

                    m_BoardGameDielog[row, colum].Enabled = false;
                }
            }

            for (int i = 0; i < i_OptionMove.Count; i++) 
            {
                m_BoardGameDielog[i_OptionMove[i].X, i_OptionMove[i].Y].BackColor = Color.Green;
                m_BoardGameDielog[i_OptionMove[i].X, i_OptionMove[i].Y].Enabled = true;
            }
          }

        public void UpdateCurrentPlayer(eCoin i_type)
        {
            if(i_type == eCoin.BLACK)
            {
                this.Text = "Othello- Black's Turn";
            }
            else
            {
                this.Text = "Othello- White's Turn";
            }
        }

        public void RandomPoint(List<Point> i_OptionalPoint)
        {
        }

        private void AddButtonToBoard()
        {
            for (int row = 0; row < m_SizeBoard; row++) 
            {
                for (int colum = 0; colum < m_SizeBoard; colum++) 
                {
                    AddButton(row, colum);
                }
            }
        }

        private void AddButton(int i_Row, int i_Colum)
        {
            ButtonOthelo newButton = new ButtonOthelo();
            newButton.X = i_Row;
            newButton.Y = i_Colum;
            newButton.Location = new System.Drawing.Point(10 + (i_Colum * k_SizeOfButton), 10 + (i_Row * k_SizeOfButton));
            newButton.Size = new System.Drawing.Size(k_SizeOfButton, k_SizeOfButton);
            newButton.Enabled = false;
            newButton.Click += ButtonBoard_Clicked;
            this.Controls.Add(newButton);
            m_BoardGameDielog[i_Row, i_Colum] = newButton;
        }

        private void ButtonBoard_Clicked(object sender, EventArgs e)
        {
            if (sender is ButtonOthelo)
            {
                ButtonOthelo currentButton = sender as ButtonOthelo;
                m_MoveCurrentPlayer.X = currentButton.X;
                m_MoveCurrentPlayer.Y = currentButton.Y;
                DialogResult = DialogResult.OK;
            }
        }

        private void PlayDielog_Load(object sender, EventArgs e)
        {
        }
    }
}
