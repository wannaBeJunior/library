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

        public static int getIndexOfElementInList(string needle, List<string> haystack, string index)
        {
            for(int i = 0; i < haystack.Count; i++)
            {
                if(haystack[i] == needle)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
