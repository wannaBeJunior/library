using System.Collections.Generic;

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
