using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ex05_OtheloFormsApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            GameDielog otheloGameDielog = new GameDielog();
            otheloGameDielog.RunGameDialog();
        }        
    }
}
