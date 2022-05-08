using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.classes
{
    class CList
    {
        public static bool findInStringList(string needle, List<string> haystack)
        {
            foreach (string row in haystack)
            {
                if (row == needle)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
