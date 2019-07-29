using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ex02_OthelloGame
{
    public class Board
    {
        static bool s_NotFirstLoop;
        private int m_Size;
        private eCoin[,] m_BoardGame;
        private List<Point> m_AllOptionalMoveForPlayer;
        Random m_RandomPoint;

        public eCoin[,] BoardGame { get => m_BoardGame; set => m_BoardGame = value; }

        public List<Point> AllOptionalMoveForPlayer { get => m_AllOptionalMoveForPlayer; set => m_AllOptionalMoveForPlayer = value; }

        private enum eDirection
        {
          UP = 0,
          UPRIGHT = 1,
          RIGHT = 2,
          DOWNRIGHT = 3,
          DOWN = 4,
          DOWNLEFT = 5,
          LEFT = 6,
          UPLEFT = 7
        }

        public Board(int i_Size)
        {
            this.m_Size = i_Size;
            this.m_AllOptionalMoveForPlayer = new List<Point>();
            this.m_BoardGame = new eCoin[this.m_Size, this.m_Size];
            this.m_RandomPoint = new Random();
            s_NotFirstLoop = false;        
            this.StartPointBoard();
        }
     
        public void StartPointBoard()
        {
            for (int i = 0; i < this.m_BoardGame.GetLength(0); i++)
            {
                for (int k = 0; k < this.m_BoardGame.GetLength(1); k++)
                {
                    this.m_BoardGame[i, k] = eCoin.EMPTY;
                }
            }

            s_NotFirstLoop = false;
            this.m_BoardGame[((this.m_Size / 2) - 1), ((this.m_Size / 2) - 1)] = this.m_BoardGame[this.m_Size / 2, this.m_Size / 2] = eCoin.BLACK;
            this.m_BoardGame[(this.m_Size / 2) - 1, (this.m_Size / 2)] = this.m_BoardGame[(this.m_Size / 2), (this.m_Size / 2) - 1] = eCoin.WHITE;
        }

        public bool ListIsEmpty()
        {
            return this.m_AllOptionalMoveForPlayer.Count == 0;
        }

        public void MakeMove(Point i_UserInsert, Player i_CurrentPlayer )
        {            
                this.m_BoardGame[i_UserInsert.X, i_UserInsert.Y] = i_CurrentPlayer.M_CoinType;
                this.UpdateGameBoard(i_UserInsert, i_CurrentPlayer.M_CoinType, true);
        }

        public void MakeMove(Player i_CurrentPlayer)
        {
            Point ComputerPoint;
            if (i_CurrentPlayer.M_IsHuman == false && s_NotFirstLoop)
            {
                ComputerPoint = this.m_AllOptionalMoveForPlayer[this.m_RandomPoint.Next(this.m_AllOptionalMoveForPlayer.Count)]; 
                this.m_BoardGame[ComputerPoint.X, ComputerPoint.Y] = i_CurrentPlayer.M_CoinType;
                this.UpdateGameBoard(ComputerPoint, i_CurrentPlayer.M_CoinType, true);
            }

            s_NotFirstLoop = true;
        }

        public void GenerateMoves(eCoin i_CurrentPlayerCoin) 
        {
            this.m_AllOptionalMoveForPlayer.Clear();
            Point cell = new Point();
            bool nextMove = true;

            for (cell.X = 0; cell.X < this.m_BoardGame.GetLength(0); ++cell.X)
            {
                for (cell.Y = 0; cell.Y < this.m_BoardGame.GetLength(1); ++cell.Y)
                {
                    if (this.m_BoardGame[cell.X, cell.Y] == eCoin.EMPTY)
                    {
                        nextMove = !true;
                        for (int width = -1; !nextMove && width < 2; ++width)
                        {
                            for (int height = -1; !nextMove && height < 2; ++height)
                            {
                                nextMove = this.CheckTheDirection(i_CurrentPlayerCoin, cell, width, height);

                                if (nextMove)
                                {
                                    this.m_AllOptionalMoveForPlayer.Add(cell);
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool CheckTheDirection(eCoin i_CurrentCoin, Point i_StartingCell, int i_Width, int i_Height)
        {
            Point cell = new Point(i_StartingCell.X + i_Width, i_StartingCell.Y + i_Height);

            if (this.BoundsCheck(cell) && (this.m_BoardGame[cell.X, cell.Y] == this.GetOpponentCoin(i_CurrentCoin)))
            {
                cell.X += i_Width;
                cell.Y += i_Height;

                while (this.BoundsCheck(cell) && this.m_BoardGame[cell.X, cell.Y] == this.GetOpponentCoin(i_CurrentCoin))
                {
                    cell.X += i_Width;
                    cell.Y += i_Height;
                }

                return this.BoundsCheck(cell) && this.m_BoardGame[cell.X, cell.Y] == i_CurrentCoin;
            }
            else
            {
                return !true;
            }
        }
       
        public bool BoundsCheck(Point i_Cell)
        {
            if (i_Cell.X < this.m_Size && i_Cell.X >= 0 && i_Cell.Y < this.m_Size && i_Cell.Y >= 0)
            {
                return true;
            }
            else
            {
                return !true;
            }
        }

        public int UpdatePlayerPoints(eCoin i_PlayerType)
        {
            int countPoints = 0;

            foreach (eCoin type in this.m_BoardGame)
            {
                if (type == i_PlayerType)
                {
                    countPoints++;
                }
            }

            return countPoints;
        }

        private eCoin GetOpponentCoin(eCoin i_CurrrentPlayerColor)
        {
            return i_CurrrentPlayerColor == eCoin.WHITE ? eCoin.BLACK : eCoin.WHITE;
        }

        private bool UpdateGameBoard(Point i_cell, eCoin i_PlayerCoin, bool i_UpdateBoard)
        {
            bool flagForUpdate = !true;
            bool checkOpponentCoin = !true;
            eCoin opponentCoin = this.GetOpponentCoin(i_PlayerCoin);
            int i = i_cell.X;
            int j = i_cell.Y;

            for (int direction = 0; direction < 8; direction++)
            {
                for (int k = 0; k < this.m_Size; k++)
                {
                    this.GetTheDirection(ref i, ref j, direction);

                    if (i >= this.m_Size || i < 0 || j >= this.m_Size || j < 0)
                    {
                        goto NextDirecrtionToCheck;
                    }

                    if (this.m_BoardGame[i, j] == opponentCoin)
                    {
                        checkOpponentCoin = true;
                    }

                    if (this.m_BoardGame[i, j] == i_PlayerCoin)
                    {
                        if (checkOpponentCoin == true)
                        {
                            flagForUpdate = true;
                            if (i_UpdateBoard == true)
                            {
                                this.UpdateMatrixByDirection(i_PlayerCoin, opponentCoin, i_cell.X, i_cell.Y, direction);
                                goto NextDirecrtionToCheck;
                            }
                            else
                            {
                                goto End;
                            }
                        }
                        else
                        {
                            goto NextDirecrtionToCheck;
                        }
                    }

                    if (this.m_BoardGame[i, j] == eCoin.EMPTY)
                    {
                        goto NextDirecrtionToCheck;
                    }
                }

            NextDirecrtionToCheck:
                i = i_cell.X;
                j = i_cell.Y;
                checkOpponentCoin = !true;
            }

        End:
            return flagForUpdate;
        }

        private void UpdateMatrixByDirection(eCoin i_Coin, eCoin i_OpponentSymbol, int i_X, int i_Y, int i_Direction)
        {
            bool flagForStop = !true;
            this.GetTheDirection(ref i_X, ref i_Y, i_Direction);

            while (!flagForStop)
            {
                if (this.m_BoardGame[i_X, i_Y] == i_Coin)
                {
                    flagForStop = true;
                }

                if (this.m_BoardGame[i_X, i_Y] == i_OpponentSymbol)
                {
                    this.m_BoardGame[i_X, i_Y] = i_Coin;
                }

                if (this.m_BoardGame[i_X, i_Y] == eCoin.EMPTY)
                {
                    break;
                }

                this.GetTheDirection(ref i_X, ref i_Y, i_Direction);
            }
        }

        private void GetTheDirection(ref int io_X, ref int io_Y, int direction)
        {
            if (direction == (int)eDirection.UP)
            {
                io_X -= 1;
            }
            else if (direction == (int)eDirection.UPRIGHT)
            {
                io_X -= 1;
                io_Y += 1;
            }
            else if (direction == (int)eDirection.RIGHT)
            {
                io_Y += 1;
            }
            else if (direction == (int)eDirection.DOWNRIGHT)
            {
                io_Y += 1;
                io_X += 1;
            }
            else if (direction == (int)eDirection.DOWN)
            {
                io_X += 1;
            }
            else if (direction == (int)eDirection.DOWNLEFT)
            {
                io_X += 1;
                io_Y -= 1;
            }
            else if (direction == (int)eDirection.LEFT)
            {
                io_Y -= 1;
            }
            else if (direction == (int)eDirection.UPLEFT)
            {
                io_X -= 1;
                io_Y -= 1;
            }
        }
    }
}
