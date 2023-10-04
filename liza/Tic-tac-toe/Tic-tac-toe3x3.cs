using System;
using System.CodeDom.Compiler;
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
    public partial class Tic_tac_toe3x3 : Form
    {

        public GameField mas = new GameField();
        private Tuple<int, Tuple<int, int, int, int>> result = new Tuple<int, Tuple<int, int, int, int>>(0, new Tuple<int, int, int, int>(0, 0, 0, 0));
        Timer timer;
        public Tic_tac_toe3x3()
        {
            InitializeComponent();
        }

        private void Tic_tac_toe3x3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mas.setScore1(0);
            this.mas.setScore2(0);
        }

        private void Tic_tac_toe3x3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void OnTimer(object sender, EventArgs e)
        {
            Draw(sender);
            Refresh();
        }

        private void Draw(object sender)
        {
            DrawTable(sender);
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
        }

        private void Tic_tac_toe3x3_MouseClick(object sender, MouseEventArgs e)
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
            result = this.mas.isGameEnd();
            if (result.Item1 == 0)
            {
                bool fl = this.mas.isFieldFull();
                if (fl)
                {
                    var FormDraw = new MessageDraw();
                    FormDraw.Show();
                    FormDraw.FormClosed += new FormClosedEventHandler(FormDraw_FormClosed);
                }
            }
            else if (result.Item1 == 1)
            {
                var FormWin1 = new Message1();
                FormWin1.Show();
                FormWin1.FormClosed += new FormClosedEventHandler(FormWin1_FormClosed);
            }
            else if (result.Item1 == 2)
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
            g.DrawLine(new Pen(Color.Black, 8.0f), lCoord.Item1, lCoord.Item2, rCoord.Item1, rCoord.Item2);
            Invalidate();
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
                g.DrawLine(new Pen(Color.DarkGray, 2.0f), xStartLine, 90, xStartLine, 246);
                xStartLine += 52;
            }

            //Draw horizontal lines
            int yStartLine = 90;
            for (int i = 0; i < size + 1; i++)
            {
                g.DrawLine(new Pen(Color.DarkGray, 2.0f), 70, yStartLine, 226, yStartLine);
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
    public class GameField
    {
        private static bool player = true;
        private int size = 3;
        private int needPoints = 3;
        private int score1 = 0, score2 = 0;
        private List<List<int>> elemsMassive = new List<List<int>>();
        private List<List<Tuple<int, int>>> coordsElems = new List<List<Tuple<int, int>>>();


        public GameField()
        {
            init();
        }

        public GameField(int new_size)
        {
            size = new_size;
            init();
        }

        public GameField(int new_size, int new_needPoints)
        {
            size = new_size;
            needPoints = new_needPoints;
            init();
        }

        private void init()
        {
            for (int i = 0; i < size; i++)
            {
                elemsMassive.Add(new List<int>());
                for (int j = 0; j < size; j++)
                {
                    elemsMassive[i].Add(0);
                }
            }


            int xCoord = 97;
            for (int i = 0; i < size; i++)
            {
                coordsElems.Add(new List<Tuple<int, int>>());
                int yCoord = 117;
                for (int j = 0; j < size; j++)
                {
                    coordsElems[i].Add(new Tuple<int, int>(xCoord, yCoord));
                    yCoord += 52;
                }
                xCoord += 52;
            }
        }

        public Tuple<int, int> getCoordCase(int x, int y)
        {
            return coordsElems[x][y];
        }

        public int getElemCase(int x, int y)
        {
            return elemsMassive[x][y];
        }

        public int ssize()
        {
            return size;
        }

        public bool getPlayer()
        {
            return player;
        }

        public void setElemCase(int x, int y, int val)
        {
            elemsMassive[x][y] = val;
        }

        public void changePlayer()
        {
            player = !player;
        }

        public bool isFieldFull()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (getElemCase(i, j) == 0) return false;
                }
            }
            return true;
        }

        public Tuple<int, Tuple<int, int, int, int>> isGameEnd()
        {
            Tuple<int, int, int, int> winCoords1 = new Tuple<int, int, int, int>(0, 0, 0, 0), winCoords2 = new Tuple<int, int, int, int>(0, 0, 0, 0);
            int max1 = 0, max2 = 0;
            for (int i = 0; i < size; i++)
            {
                int l1 = 0, l2 = 0, r1 = 0, r2 = 0;
                for (int j = 0; j < size; j++)
                {
                    r1 = j; r2 = j;
                    if (elemsMassive[i][j] != 1)
                    {
                        if (r1 - l1 > max1)
                        {
                            max1 = r1 - l1;
                            winCoords1 = new Tuple<int, int, int, int>(i, l1, i, r1 - 1);
                        }
                        l1 = j + 1;
                    }
                    if (elemsMassive[i][j] != 2)
                    {
                        if (r2 - l2 > max2)
                        {
                            max2 = r2 - l2;
                            winCoords2 = new Tuple<int, int, int, int>(i, l2, i, r2 - 1);
                        }
                        l2 = j + 1;
                    }
                }
                if (r1 - l1 + 1 > max1)
                {
                    max1 = r1 - l1 + 1;
                    winCoords1 = new Tuple<int, int, int, int>(i, l1, i, r1);
                }
                if (r2 - l2 + 1 > max2)
                {
                    max2 = r2 - l2 + 1;
                    winCoords2 = new Tuple<int, int, int, int>(i, l2, i, r2);
                }
            }
            for (int i = 0; i < size; i++)
            {
                int l1 = 0, l2 = 0, r1 = 0, r2 = 0;
                for (int j = 0; j < size; j++)
                {
                    r1 = j; r2 = j;
                    if (elemsMassive[j][i] != 1)
                    {
                        if (r1 - l1 > max1)
                        {
                            max1 = r1 - l1;
                            winCoords1 = new Tuple<int, int, int, int>(l1, i, r1 - 1, i);
                        }
                        l1 = j + 1;
                    }
                    if (elemsMassive[j][i] != 2)
                    {
                        if (r2 - l2 > max2)
                        {
                            max2 = r2 - l2;
                            winCoords2 = new Tuple<int, int, int, int>(l2, i, r2 - 1, i);
                        }
                        l2 = j + 1;
                    }
                }
                if (r1 - l1 + 1 > max1)
                {
                    max1 = r1 - l1 + 1;
                    winCoords1 = new Tuple<int, int, int, int>(l1, i, r1, i);
                }
                if (r2 - l2 + 1 > max2)
                {
                    max2 = r2 - l2 + 1;
                    winCoords2 = new Tuple<int, int, int, int>(l2, i, r2, i);
                }
            }

            for (int i = 0; i < size; i++)
            {
                Tuple<int, int> l1 = new Tuple<int, int>(i, 0), l2 = new Tuple<int, int>(i, 0), r1 = new Tuple<int, int>(i, 0), r2 = new Tuple<int, int>(i, 0);
                while (r1.Item1 < size)
                {
                    if (elemsMassive[r1.Item1][r1.Item2] != 1)
                    {
                        if (r1.Item1 - l1.Item1 > max1)
                        {
                            max1 = r1.Item1 - l1.Item1;
                            winCoords1 = new Tuple<int, int, int, int>(l1.Item1, l1.Item2, r1.Item1 - 1, r1.Item2 - 1);
                        }
                        l1 = new Tuple<int, int>(r1.Item1 + 1, r1.Item2 + 1);
                    }
                    if (elemsMassive[r2.Item1][r2.Item2] != 2)
                    {
                        if (r2.Item1 - l2.Item1 > max2)
                        {
                            max2 = r2.Item1 - l2.Item1;
                            winCoords2 = new Tuple<int, int, int, int>(l2.Item1, l2.Item2, r2.Item1 - 1, r2.Item2 - 1);
                        }
                        l2 = new Tuple<int, int>(r2.Item1 + 1, r2.Item2 + 1);
                    }
                    r1 = new Tuple<int, int>(r1.Item1 + 1, r1.Item2 + 1); r2 = new Tuple<int, int>(r2.Item1 + 1, r2.Item2 + 1);
                }
                if (r1.Item1 - l1.Item1 > max1)
                {
                    max1 = r1.Item1 - l1.Item1;
                    winCoords1 = new Tuple<int, int, int, int>(l1.Item1, l1.Item2, r1.Item1 - 1, r1.Item2 - 1);
                }
                if (r2.Item1 - l2.Item1 > max2)
                {
                    max2 = r2.Item1 - l2.Item1;
                    winCoords2 = new Tuple<int, int, int, int>(l2.Item1, l2.Item2, r2.Item1 - 1, r2.Item2 - 1);
                }
            }
            for (int i = 0; i < size; i++)
            {
                Tuple<int, int> l1 = new Tuple<int, int>(0, i), l2 = new Tuple<int, int>(0, i), r1 = new Tuple<int, int>(0, i), r2 = new Tuple<int, int>(0, i);
                while (r1.Item2 < size)
                {
                    if (elemsMassive[r1.Item1][r1.Item2] != 1)
                    {
                        if (r1.Item1 - l1.Item1 > max1)
                        {
                            max1 = r1.Item1 - l1.Item1;
                            winCoords1 = new Tuple<int, int, int, int>(l1.Item1, l1.Item2, r1.Item1 - 1, r1.Item2 - 1);
                        }
                        l1 = new Tuple<int, int>(r1.Item1 + 1, r1.Item2 + 1);
                    }
                    if (elemsMassive[r2.Item1][r2.Item2] != 2)
                    {
                        if (r2.Item1 - l2.Item1 > max2)
                        {
                            max2 = r2.Item1 - l2.Item1;
                            winCoords2 = new Tuple<int, int, int, int>(l2.Item1, l2.Item2, r2.Item1 - 1, r2.Item2 - 1);
                        }
                        l2 = new Tuple<int, int>(r2.Item1 + 1, r2.Item2 + 1);
                    }
                    r1 = new Tuple<int, int>(r1.Item1 + 1, r1.Item2 + 1); r2 = new Tuple<int, int>(r2.Item1 + 1, r2.Item2 + 1);
                }
                if (r1.Item1 - l1.Item1 > max1)
                {
                    max1 = r1.Item1 - l1.Item1;
                    winCoords1 = new Tuple<int, int, int, int>(l1.Item1, l1.Item2, r1.Item1 - 1, r1.Item2 - 1);
                }
                if (r2.Item1 - l2.Item1 > max2)
                {
                    max2 = r2.Item1 - l2.Item1;
                    winCoords2 = new Tuple<int, int, int, int>(l2.Item1, l2.Item2, r2.Item1 - 1, r2.Item2 - 1);
                }
            }
            for (int i = 0; i < size; i++)
            {
                Tuple<int, int> l1 = new Tuple<int, int>(0, i), l2 = new Tuple<int, int>(0, i), r1 = new Tuple<int, int>(0, i), r2 = new Tuple<int, int>(0, i);
                while (r1.Item2 >= 0 && r1.Item1 < size)
                {
                    if (elemsMassive[r1.Item1][r1.Item2] != 1)
                    {
                        if (r1.Item1 - l1.Item1 > max1)
                        {
                            max1 = r1.Item1 - l1.Item1;
                            winCoords1 = new Tuple<int, int, int, int>(l1.Item1, l1.Item2, r1.Item1 - 1, r1.Item2 + 1);
                        }
                        l1 = new Tuple<int, int>(r1.Item1 + 1, r1.Item2 - 1);
                    }
                    if (elemsMassive[r2.Item1][r2.Item2] != 2)
                    {
                        if (r2.Item1 - l2.Item1 > max2)
                        {
                            max2 = r2.Item1 - l2.Item1;
                            winCoords2 = new Tuple<int, int, int, int>(l2.Item1, l2.Item2, r2.Item1 - 1, r2.Item2 + 1);
                        }
                        l2 = new Tuple<int, int>(r2.Item1 + 1, r2.Item2 - 1);
                    }
                    r1 = new Tuple<int, int>(r1.Item1 + 1, r1.Item2 - 1); r2 = new Tuple<int, int>(r2.Item1 + 1, r2.Item2 - 1);
                }
                if (r1.Item1 - l1.Item1 > max1)
                {
                    max1 = r1.Item1 - l1.Item1;
                    winCoords1 = new Tuple<int, int, int, int>(l1.Item1, l1.Item2, r1.Item1 - 1, r1.Item2 + 1);
                }
                if (r2.Item1 - l2.Item1 > max2)
                {
                    max2 = r2.Item1 - l2.Item1;
                    winCoords2 = new Tuple<int, int, int, int>(l2.Item1, l2.Item2, r2.Item1 - 1, r2.Item2 + 1);
                }
            }
            for (int i = 0; i < size; i++)
            {
                Tuple<int, int> l1 = new Tuple<int, int>(i, size - 1), l2 = new Tuple<int, int>(i, size - 1), r1 = new Tuple<int, int>(i, size - 1), r2 = new Tuple<int, int>(i, size - 1);
                while (r1.Item2 >= 0 && r1.Item1 < size)
                {
                    if (elemsMassive[r1.Item1][r1.Item2] != 1)
                    {
                        if (r1.Item1 - l1.Item1 > max1)
                        {
                            max1 = r1.Item1 - l1.Item1;
                            winCoords1 = new Tuple<int, int, int, int>(l1.Item1, l1.Item2, r1.Item1 - 1, r1.Item2 + 1);
                        }
                        l1 = new Tuple<int, int>(r1.Item1 + 1, r1.Item2 - 1);
                    }
                    if (elemsMassive[r2.Item1][r2.Item2] != 2)
                    {
                        if (r2.Item1 - l2.Item1 > max2)
                        {
                            max2 = r2.Item1 - l2.Item1;
                            winCoords2 = new Tuple<int, int, int, int>(l2.Item1, l2.Item2, r2.Item1 - 1, r2.Item2 + 1);
                        }
                        l2 = new Tuple<int, int>(r2.Item1 + 1, r2.Item2 - 1);
                    }
                    r1 = new Tuple<int, int>(r1.Item1 + 1, r1.Item2 - 1); r2 = new Tuple<int, int>(r2.Item1 + 1, r2.Item2 - 1);
                }
                if (r1.Item1 - l1.Item1 > max1)
                {
                    max1 = r1.Item1 - l1.Item1;
                    winCoords1 = new Tuple<int, int, int, int>(l1.Item1, l1.Item2, r1.Item1 - 1, r1.Item2 + 1);
                }
                if (r2.Item1 - l2.Item1 > max2)
                {
                    max2 = r2.Item1 - l2.Item1;
                    winCoords2 = new Tuple<int, int, int, int>(l2.Item1, l2.Item2, r2.Item1 - 1, r2.Item2 + 1);
                }
            }


            if (max1 >= needPoints)
            {
                return new Tuple<int, Tuple<int, int, int, int>>(1, winCoords1);
            }
            else if (max2 >= needPoints)
            {
                return new Tuple<int, Tuple<int, int, int, int>>(2, winCoords2);
            }
            return new Tuple<int, Tuple<int, int, int, int>>(0, winCoords1);
        }

        public string getScore1()
        {
            return score1.ToString();
        }

        public string getScore2()
        {
            return score2.ToString();
        }

        public void setScore1(int score)
        {
            score1 = score;
        }

        public void setScore2(int score)
        {
            score2 = score;
        }
    }
}
