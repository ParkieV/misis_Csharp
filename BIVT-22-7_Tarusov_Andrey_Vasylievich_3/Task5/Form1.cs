namespace Задача_1._1
{
    public partial class Form1 : Form
    {
        public readonly string[] ACTION = { "Enqueue", "Push", "Get", "Add", "GetLast", "Sort", "Find", "Filter", "Remove", "Replace" };
        public readonly string[] TARGET = { "MyStack", "MyQueue", "MyDeque", "SysStack", "SysQueue", "StringList" };
        readonly string SPLITTER = ";";

        Structures.MyDequeString ms = new Structures.MyDequeString();
        Structures.MyDequeString mq = new Structures.MyDequeString();
        Structures.MyDequeString md = new Structures.MyDequeString();
        Structures.StringStack st = new Structures.StringStack();
        Structures.StringQueue qu = new Structures.StringQueue();
        Structures.StringList sl = new Structures.StringList();
        Structures.MyLog log = new Structures.MyLog();
        Form2 logForm = new Form2();
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            logForm.f1 = this;
            logForm.Hide();
            try
            {
                string[] m = File.ReadAllLines(log.LogFileName);
                foreach (var i in m)
                {
                    log.Add(i);
                    logForm.Add(i);
                }
            }
            catch { };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "";
            listBox1.Items.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                ms.AddFirst(textBox1.Text);
                foreach (var i in ms) { listBox1.Items.Add(i); s += i + SPLITTER; }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                md.AddFirst(textBox1.Text);
                foreach (var i in md) { listBox1.Items.Add(i); s += i + SPLITTER; }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                st.Put(textBox1.Text);
                foreach (var i in st) { listBox1.Items.Add(i); s += i + SPLITTER; }
            }
            logForm.Add(log.AddTimed(ACTION[1], TARGET[comboBox1.SelectedIndex], textBox1.Text, s, ""));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "";
            listBox1.Items.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = ms.PopTail();
                foreach (var i in ms) { listBox1.Items.Add(i); s += i + SPLITTER; }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Text = mq.PopTail();
                foreach (var i in mq) { listBox1.Items.Add(i); s += i + SPLITTER; }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Text = md.PopTail();
                foreach (var i in md) { listBox1.Items.Add(i); s += i + SPLITTER; }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                textBox1.Text = st.Get();
                foreach (var i in st) { listBox1.Items.Add(i); s += i + SPLITTER; }
            }
            else
            {
                textBox1.Text = qu.Get();
                foreach (var i in qu) { listBox1.Items.Add(i); s += i + SPLITTER; }
            }
            logForm.Add(log.AddTimed(ACTION[2], TARGET[comboBox1.SelectedIndex], textBox1.Text, s, ""));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            listBox1.Items.Clear();
            if (comboBox1.SelectedIndex == 1)
            {
                mq.AddFirst(textBox1.Text);
                foreach (var i in mq) { listBox1.Items.Add(i); s += i + SPLITTER; }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                md.AddFirst(textBox1.Text);
                foreach (var i in md) { listBox1.Items.Add(i); s += i + SPLITTER; }
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                qu.Put(textBox1.Text);
                foreach (var i in qu) { listBox1.Items.Add(i); s += i + SPLITTER; }
            }
            logForm.Add(log.AddTimed(ACTION[0], TARGET[comboBox1.SelectedIndex], textBox1.Text, s, ""));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            sl.Add(textBox1.Text);
            listBox2.Items.Clear();
            string s = "";
            for (var i = 0; i < sl.Count; i++) { listBox2.Items.Add(sl[i]); s += sl[i] + SPLITTER; }
            logForm.Add(log.AddTimed(ACTION[3], TARGET[5], textBox1.Text, s, ""));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sl.Sort();
            string s = "";
            listBox2.Items.Clear();
            for (var i = 0; i < sl.Count; i++) { listBox2.Items.Add(sl[i]); s += sl[i] + SPLITTER; }
            logForm.Add(log.AddTimed(ACTION[5], TARGET[5], textBox1.Text, s, ""));

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Predicate<string> m = (string p) => { return p == textBox1.Text; };
            List<string> res = sl.FindAll(m);
            listBox2.Items.Clear();
            string s = "";
            for (var i = 0; i < res.Count; i++) { listBox2.Items.Add(res[i]); s += sl[i] + SPLITTER; }
            logForm.Add(log.AddTimed(ACTION[6], TARGET[5], textBox1.Text, s, ""));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Predicate<string> m = (string p) => { return p != textBox1.Text; };
            List<string> res = sl.FindAll(m);
            listBox2.Items.Clear();
            string s = "";
            for (var i = 0; i < res.Count; i++) { listBox2.Items.Add(res[i]); s += sl[i] + SPLITTER; }
            logForm.Add(log.AddTimed(ACTION[7], TARGET[5], textBox1.Text, s, ""));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sl.Remove(textBox1.Text);
            listBox2.Items.Clear();
            string s = "";
            for (var i = 0; i < sl.Count; i++) { listBox2.Items.Add(sl[i]); s += sl[i] + SPLITTER; }
            logForm.Add(log.AddTimed(ACTION[8], TARGET[5], textBox1.Text, s, ""));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            sl.Replace((string)listBox2.SelectedItem, textBox1.Text);
            listBox2.Items.Clear();
            string s = "";
            for (var i = 0; i < sl.Count; i++) { listBox2.Items.Add(sl[i]); s += sl[i] + SPLITTER; }
            logForm.Add(log.AddTimed(ACTION[9], TARGET[5], textBox1.Text, s, ""));

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = (string)listBox2.SelectedItem;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                foreach (var i in ms) listBox1.Items.Add(i);
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                foreach (var i in mq) listBox1.Items.Add(i);
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                foreach (var i in md) listBox1.Items.Add(i);
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                foreach (var i in st) listBox1.Items.Add(i);
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                foreach (var i in qu) listBox1.Items.Add(i);
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (logForm.IsDisposed)
            {
                logForm = new Form2();
                logForm.f1 = this;
                foreach (var i in log) logForm.Add(i);
            }
            if (checkBox1.Checked == true) logForm.Show();
            else logForm.Hide();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = md.PopTail();
            listBox1.Items.Clear();
            string s = "";
            foreach (var i in md) { listBox1.Items.Add(i); s += " " + i; }
            logForm.Add(log.AddTimed(ACTION[4], TARGET[comboBox1.SelectedIndex], textBox1.Text, s, ""));

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void ParseLog(string p)
        {
            string[] s = log.Parse(p);
            if (s.Length < 4) return;
            for (var i = 0; i < TARGET.Length; i++)
            {
                if (s[1] == TARGET[i])
                {
                    textBox1.Text = s[2];
                    if (i < 5) 
                    {
                        comboBox1.SelectedIndex = i;
                        listBox1.Items.Clear();
                        string[] c = s[3].Split(SPLITTER[0]);
                        for (var j = 0; j < c.Length; j++) { listBox1.Items.Add(c[j]); }
                    }
                    else
                    {
                        listBox2.Items.Clear();
                        string[] c = s[3].Split(SPLITTER[0]);
                        for (var j = 0; j < c.Length; j++) { listBox2.Items.Add(c[j]); }
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}