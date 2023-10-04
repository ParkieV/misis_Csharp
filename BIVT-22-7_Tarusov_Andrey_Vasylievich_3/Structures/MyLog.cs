using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class MyLog : StringList
    {
        public string LogFileName = "MyLog.log";
        public string AddTimed(string action, string target, string elem, string currstate, string discr)//discription - описание
        {
            StreamWriter f = File.AppendText(LogFileName);
            DateTime now = DateTime.Now;
            if (currstate.Length > 0) currstate = currstate.Substring(0, currstate.Length - 1);
            string r = now.ToString("yyyy.MM.dd HH:mm:ss") + " -> " + action + " " + elem + " to/from " +
                target + " => {" + currstate + "} :" + discr;
            f.WriteLine(r);
            Insert(0, r);
            f.Close();
            return r;
        }
        public string[] Parse(string s)
        {
            string[] m = s.Split(' ');

            if (m.Length > 8)
            {
                m[8] = m[8].Substring(1, m[8].Length - 2);
                string[] r = { m[3], m[6], m[4], m[8] };
                return r;
            }
            return m;
        }

    }
}
