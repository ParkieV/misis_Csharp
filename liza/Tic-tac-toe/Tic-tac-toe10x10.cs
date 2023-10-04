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
    public partial class Tic_tac_toe10x10 : Form
    {
        public GameField mas = new GameField(10, 5);
        private Tuple<int, Tuple<int, int, int, int>> result = new Tuple<int, Tuple<int, int, int, int>>(0, new Tuple<int, int, int, int>(0, 0, 0, 0));
        public Tic_tac_toe10x10()
        {
            InitializeComponent();
        }

        private void AfterGame(int winner)
        {
            for (int i = 0; i < this.mas.ssize(); i++)
            {
                for (int j = 0; j < this.mas.ssize(); j++)
                {
                    this.mas.setElemCase(i, j, 0);
                }
            }
            if (winner == 1)
            {
                this.mas.setScore1(int.Parse(this.mas.getScore1()) + 1);
            }
            else if (winner == 2)
            {
                this.mas.setScore2(int.Parse(this.mas.getScore2()) + 1);
            }
            if (!this.mas.getPlayer())
            {
                this.mas.changePlayer();
            }
            this.result = new Tuple<int, Tuple<int, int, int, int>>(0, new Tuple<int, int, int, int>(0, 0, 0, 0));
        }

        private void DrawTable(object sender, int size = 3)
        {
            Graphics g = this.CreateGraphics();
            int xStart = 0;
            int yStart = 0;
            g.TranslateTransform(xStart, yStart);

            // Draw vertical lines
            int xStartLine = 70;
            for (int i = 0; i < size + 1; i++)
            {
                g.DrawLine(new Pen(Color.DarkGray, 2.0f), xStartLine, 90, xStartLine, 610);
                xStartLine += 52;
            }

            //Draw horizontal lines
            int yStartLine = 90;
            for (int i = 0; i < size + 1; i++)
            {
                g.DrawLine(new Pen(Color.DarkGray, 2.0f), 70, yStartLine, 590, yStartLine);
                yStartLine += 52;
            }
        }

        private void DrawChest(object sender, int x, int y)
        {
            Graphics g = this.CreateGraphics();
            g.TranslateTransform(x - 2, y - 2);
            g.DrawLine(new Pen(Color.DarkBlue, 2.0f), -20, 20, 20, -20);
            g.DrawLine(new Pen(Color.DarkBlue, 2.0f), -20, -20, 20, 20);
        }
        private void DrawCircle(object sender, int x, int y)
        {
            Graphics g = this.CreateGraphics();
            g.TranslateTransform(x, y);
            g.DrawEllipse(new Pen(Color.DarkRed, 2.0f), new Rectangle(-22, -22, 40, 40));
        }

        private void Tic_tac_toe10x10_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mas.setScore1(0);
            this.mas.setScore2(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.mas.ssize(); i++)
            {
                for (int j = 0; j < this.mas.ssize(); j++)
                {
                    this.mas.setElemCase(i, j, 0);
                }
            }
            this.mas.setScore1(0);
            this.mas.setScore2(0);
            if (!this.mas.getPlayer())
            {
                this.mas.changePlayer();
            }
        }

        private void Tic_tac_toe10x10_Paint(object sender, PaintEventArgs e)
        {
            DrawTable(sender, 10);
            for (int i = 0; i < this.mas.ssize(); i++)
            {
                for (int j = 0; j < this.mas.ssize(); j++)
                {
                    if (this.mas.getElemCase(i, j) == 1)
                    {
                        Tuple<int, int> caseCoord = this.mas.getCoordCase(i, j);
                        DrawChest(sender, caseCoord.Item1, caseCoord.Item2);
                    }
                    if (this.mas.getElemCase(i, j) == 2)
                    {
                        Tuple<int, int> caseCoord = this.mas.getCoordCase(i, j);
                        DrawCircle(sender, caseCoord.Item1, caseCoord.Item2);
                    }
                }
            }
            if (result.Item1 == 1)
            {
                drawWinLine(result.Item2);
            }
            else if (result.Item1 == 2)
            {
                drawWinLine(result.Item2);
            }
            this.label4.Text = this.mas.getScore1();
            this.label5.Text = this.mas.getScore2();
            Refresh();
        }

        private void Tic_tac_toe10x10_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.Location.X - 72; int y = e.Location.Y - 92;
            bool f1 = x >= 0, f2 = x / 52 >= 0, f3 = x / 52 < mas.ssize();
            if (x >= 0 && x / 52 >= 0 && x / 52 < mas.ssize())
            {
                x /= 52;
                if (y >= 0 && y / 52 >= 0 && y / 52 < mas.ssize())
                {
                    y /= 52;
                    Tuple<int, int> coord_center = mas.getCoordCase(x, y);
                    if (mas.getElemCase(x, y) == 0)
                    {
                        if (mas.getPlayer())
                        {
                            this.mas.setElemCase(x, y, 1);
                        }
                        else
                        {
                            this.mas.setElemCase(x, y, 2);
                        }
                        this.mas.changePlayer();
                    }
                }
            }
            Tuple<int, Tuple<int, int, int, int>> score = this.mas.isGameEnd();
            if (score.Item1 == 0)
            {
                bool fl = this.mas.isFieldFull();
                if (fl)
                {
                    var FormDraw = new MessageDraw();
                    FormDraw.Show();
                    FormDraw.FormClosed += new FormClosedEventHandler(FormDraw_FormClosed);
                }
            }
            else if (score.Item1 == 1)
            {
                var FormWin1 = new Message1();
                FormWin1.Show();
                FormWin1.FormClosed += new FormClosedEventHandler(FormWin1_FormClosed);
            }
            else if (score.Item1 == 2)
            {
                var FormWin2 = new Message2();
                FormWin2.Show();
                FormWin2.FormClosed += new FormClosedEventHandler(FormWin2_FormClosed);

            }
        }

        private void drawWinLine(Tuple<int, int, int, int> coordsMas)
        {
            Graphics g = this.CreateGraphics();
            g.TranslateTransform(0, 0);
            Tuple<int, int> lCoord = this.mas.getCoordCase(coordsMas.Item1, coordsMas.Item2);
            Tuple<int, int> rCoord = this.mas.getCoordCase(coordsMas.Item3, coordsMas.Item4);
            g.DrawLine(new Pen(Color.Black, 4.0f), lCoord.Item1, lCoord.Item2, rCoord.Item1, rCoord.Item2);
        }

        private void FormWin1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.AfterGame(1);
        }
        private void FormWin2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.AfterGame(2);
        }
        private void FormDraw_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.AfterGame(0);
        }
    }
}