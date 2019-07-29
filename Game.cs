using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ex02_OthelloGame
{
    public enum eCoin
    {
        EMPTY,
        BLACK,
        WHITE
    }

    public class Game
    {
        static int s_countListIsEmpty = 0;
        public Player m_CurrentPlayer;
        private Board m_Board;
        private Player m_Player1;
        private Player m_Player2;
        int m_TotalOfRounds = 0;
        int m_BleckWinRounds = 0;
        int m_WhiteWinRounds = 0;

        public Game(int i_sizeBoard, bool i_IsHuman)
        {
            this.m_Board = new Board(i_sizeBoard);
            SettingPlayers(i_IsHuman);
            m_CurrentPlayer = m_Player2;
        }

        public eCoin[,] GetBoardData()
        {
            return m_Board.BoardGame;
        }

        public List<Point> GetListMoveData()
        {
            return m_Board.AllOptionalMoveForPlayer;
        }

        private void SettingPlayers(bool i_IsHuman)
        {
            m_Player1 = new Player(true, "person", eCoin.BLACK);
            m_Player2 = new Player(i_IsHuman, "null", eCoin.WHITE);
        }

        public bool isCourrentPlayerIsHuman()
        {
            return m_CurrentPlayer.M_IsHuman;
        }

        public eCoin CoinCurrentPlayer()
        {
            return m_CurrentPlayer.M_CoinType;
        }

        public bool IfGameIsOver()
        {
            if (s_countListIsEmpty >= 2) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void MakeAnotherRound()
        {
            this.m_Board.StartPointBoard();
            m_CurrentPlayer = m_Player2;
            s_countListIsEmpty = 0;
        }

        public void UpdateStatusBoard(Point i_UserInsert)
        {
            m_Board.MakeMove(i_UserInsert, m_CurrentPlayer);
            MakeTheBoardReadyForTheNextRound();
        }

        public void UpdateStatusBoard()
        {
            m_Board.MakeMove(m_CurrentPlayer);
            MakeTheBoardReadyForTheNextRound();
        }

        public void MakeTheBoardReadyForTheNextRound()
        {
            UptadeNextCurrentPlayer();
            this.m_Board.GenerateMoves(this.m_CurrentPlayer.M_CoinType);

                if (this.m_Board.ListIsEmpty())
                { 
                    s_countListIsEmpty++;
                    if (s_countListIsEmpty < 2)
                    {
                        MakeTheBoardReadyForTheNextRound();
                    }
                }
                else
                {
                    s_countListIsEmpty = 0;
                }
        }
        
        public void UptadeNextCurrentPlayer()
        {
            if (this.m_CurrentPlayer == this.m_Player1)
            {
                this.m_CurrentPlayer = this.m_Player2;
            }
            else
            {
                this.m_CurrentPlayer = this.m_Player1;
            }
        }
        
        public string AnnounceWinner()
        {
            this.m_Player1.M_Points = this.m_Board.UpdatePlayerPoints(this.m_Player1.M_CoinType);
            this.m_Player2.M_Points = this.m_Board.UpdatePlayerPoints(this.m_Player2.M_CoinType);
            m_TotalOfRounds++;
            string result;

            if (this.m_Player1.M_Points > this.m_Player2.M_Points)
            {
                m_BleckWinRounds++;
                result = "Black Won!! (" + this.m_Player1.M_Points + "/" + this.m_Player2.M_Points + ") (" + m_BleckWinRounds + "/" + m_TotalOfRounds + ")\nWould you like another round?";
            }
            else if(this.m_Player2.M_Points > this.m_Player1.M_Points)
            {
                m_WhiteWinRounds++;
                result = "White Won!! (" + this.m_Player2.M_Points + "/" + this.m_Player1.M_Points + ") (" + m_WhiteWinRounds + "/" + m_TotalOfRounds + ")\nWould you like another round?";
            }
            else
            {
                m_BleckWinRounds++;
                m_WhiteWinRounds++;
                result = "Draw in the game (" + this.m_Player1.M_Points + "/" + this.m_Player2.M_Points + ")\nWould you like another round?";
            }

            return result;
        }
    }
}