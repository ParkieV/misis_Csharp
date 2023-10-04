using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{

    public class StringStack : Stack<string>
    {
        public string Get()
        {
            if (TryPop(out var r)) return r;
            else throw new InvalidOperationException("Stack is empty!"); ;
        }

        public string Put(string s)
        {
            Push(s);
            return s;
        }
    }
}
