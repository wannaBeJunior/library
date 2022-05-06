using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace library.classes
{
    class CValidate
    {
        public static bool loginValidate(string login)
        {
            if (login.Length <= 45 && login.Length > 1)
                return true;
            return false;
        }

        public static bool nameValidate(string name)
        {
            char[] chrs = name.ToCharArray();
            for(int i = 0; i < chrs.Length; i++)
            {
                if(Char.IsDigit(chrs[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool passwordValidate(string password)
        {
            string pattern = @"(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{6,}";
            if (password.Length > 6 && Regex.IsMatch(password,pattern))
                return true;
            return false;
        }
    }
}
