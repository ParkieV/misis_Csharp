using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задача_1._1
{
    public partial class Form2 : Form
    {
        public Form1 f1;
        public Form2()
        {
            InitializeComponent();
        }

        public void Add(string s)
        {
            //listBox1.Items.Add(s);

            listBox1.Items.Insert(0, s);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.ParseLog(listBox1.SelectedItem.ToString());
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void Finalize()
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
