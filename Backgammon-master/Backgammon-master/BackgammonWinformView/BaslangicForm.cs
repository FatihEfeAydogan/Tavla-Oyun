﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgammonWinformView
{
    public partial class BaslangicForm : Form
    {
        public BaslangicForm()
        {
            InitializeComponent();
        }

        private void Oyna_Click(object sender, EventArgs e)
        {
            BackgammonForm bgf = new BackgammonForm();
            bgf.Show();
            this.Hide();
        }

        private void Cikis_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Çıkış Yapmak İstediğinize Emin Misiniz?", "Çıkış", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                Application.Exit();
               
                 // Mevcut formu gizle
            }
            else if (result == DialogResult.Cancel)
            {
                // Hiçbir şey yapma, mevcut formda kal
            }
        }
    }
}
