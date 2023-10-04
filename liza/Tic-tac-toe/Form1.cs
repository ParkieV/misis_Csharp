using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_tac_toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (this.radioButton1.Checked == true)
            {
                var Form3x3 = new Tic_tac_toe3x3();
                Form3x3.Show();
            }
            else
            {
                var Form10x10 = new Tic_tac_toe10x10();
                Form10x10.Show();
            }
        }
    }
}
