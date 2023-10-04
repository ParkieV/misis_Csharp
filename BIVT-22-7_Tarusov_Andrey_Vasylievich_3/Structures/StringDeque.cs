using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class MyDequeString : MyDeque<string>
    {
        public string PopHead()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Deque is empty!");
            }
            return RemoveFirst();
        }
        public string PopTail()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Deque is empty!");
            }
            return RemoveLast();
        }
    }
}
