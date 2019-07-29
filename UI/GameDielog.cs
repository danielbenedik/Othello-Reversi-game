using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Ex02_OthelloGame;

namespace Ex05_OtheloFormsApp
{
    class GameDielog
    {
        FormOthelloSetting m_firstSettingDielog;
        Game m_OtheloDataGame;
        PlayDielog play;

        public GameDielog()
        {
            m_firstSettingDielog = new FormOthelloSetting();

            m_firstSettingDielog.ShowDialog();
            m_OtheloDataGame = new Game(m_firstSettingDielog.SizeBoard, m_firstSettingDielog.IsFtHuman);
            if (m_firstSettingDielog.DialogResult == DialogResult.OK)
            {
                play = new PlayDielog(m_firstSettingDielog.SizeBoard, m_firstSettingDielog.IsFtHuman);
            }
        }

        public void RunGameDialog() 
        {
            if(play != null) 
            { 
               StartAgain:
                m_OtheloDataGame.UpdateStatusBoard();
                do
                {
                    if(m_OtheloDataGame.isCourrentPlayerIsHuman())
                    { 
                        play.UpdateCurrentPlayer(m_OtheloDataGame.CoinCurrentPlayer());
                        play.UpdateBoard(m_OtheloDataGame.GetBoardData(), m_OtheloDataGame.GetListMoveData());
                        play.ShowDialog();
                        m_OtheloDataGame.UpdateStatusBoard(play.PointCurrentPlayer);
                    }
                    else
                    {
                        m_OtheloDataGame.UpdateStatusBoard();
                    }
                }
                while (m_OtheloDataGame.IfGameIsOver() && (play.DialogResult == DialogResult.OK));

                if (play.DialogResult == DialogResult.OK) 
                {
                    if (endGameDialog(m_OtheloDataGame.AnnounceWinner()) == DialogResult.Yes)
                    {
                            m_OtheloDataGame.MakeAnotherRound();
                            goto StartAgain;
                    }
                }
            }
        }

        private DialogResult endGameDialog(string i_ResultStatus)
        {
            string title = "Othello";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            return MessageBox.Show(i_ResultStatus, title, buttons, icon);
        }
    }
}
