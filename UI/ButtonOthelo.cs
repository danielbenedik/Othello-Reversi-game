using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Ex02_OthelloGame;

namespace Ex05_OtheloFormsApp
{
    class ButtonOthelo : Button 
    {
        int x;
        int y;
        
        public ButtonOthelo()
        {
            this.BackColor = Color.Gainsboro;
        }

        public int X { get => x; set => x = value; }

        public int Y { get => y; set => y = value; }
    }
}
