using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class StringList : List<string>
    {
        public bool Replace(string OldStr, string NewStr)
        {
            for (var i = 0; i < Count; i++)
            {
                if (this[i] == OldStr)
                {
                    this[i] = NewStr;
                    return true;
                }
            }
            return false;
        }

    }
}
