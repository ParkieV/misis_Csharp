using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class StringQueue : Queue<string>
    {
        public string Get()
        {
            if (this.Count() > 0) return Dequeue();
            else throw new InvalidOperationException("Deque is empty!");
        }

        public string Put(string s)
        {
            Enqueue(s);
            return s;
        }
    }
}
