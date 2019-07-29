using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ex02_OthelloGame
{
    public class Player
    {
        public static int s_CountOfPlayer = 0;
        readonly string m_Name;
        readonly bool m_IsHuman;
        readonly eCoin m_CoinType;
        private int m_Points;

        public Player(bool i_isHuman, string i_Name, eCoin i_CoinType)
        {
            this.m_Name = i_Name;
            this.m_IsHuman = i_isHuman;
            this.m_CoinType = i_CoinType;
            this.m_Points = 0;
        }

        public bool M_IsHuman
        {
            get { return this.m_IsHuman; }
        }

        public eCoin M_CoinType
        {
            get { return this.m_CoinType; }
        }

        public string M_Name
        {
            get { return this.m_Name; }
        }

        public int M_Points
        {
            get { return this.m_Points; }
            set { this.m_Points = value; }
        }
    }
}
