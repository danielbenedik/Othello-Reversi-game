using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05_OtheloFormsApp
{
    public partial class FormOthelloSetting : Form
    {
        int m_SizeBoard;
        bool m_IsHuman;

        public int SizeBoard { get => m_SizeBoard; set => m_SizeBoard = value; }

        public bool IsFtHuman { get => m_IsHuman; }

        public FormOthelloSetting()
        {
            InitializeComponent();
            m_SizeBoard = 6;
            m_IsHuman = false;
        }

        private void FormOthelloSettings(object sender, EventArgs e)
        {
        }

        private void BoardSize_Click(object sender, EventArgs e)
        {
            if (m_SizeBoard < 12)
            {
                m_SizeBoard += 2;
            }
            else
            {
                m_SizeBoard = 6;
            }

            BoardSize.Text = "Board Size: " + m_SizeBoard + "x" + m_SizeBoard + " (click to increase)";
        }

        private void AgainstComputer_Click(object sender, EventArgs e)
        {
            this.m_IsHuman = false;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AgainstFriend_Click(object sender, EventArgs e)
        {
            this.m_IsHuman = true;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}