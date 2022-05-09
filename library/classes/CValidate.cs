using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

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

        public static bool phoneValidate(string phone)
        {
            string pattern = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
            if (phone.Length > 6 && Regex.IsMatch(phone, pattern))
                return true;
            return false;
        }

        static public string preparePassword(string password)
        {
            if (password.Length > 0)
            {
                var md5 = MD5.Create();
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

                return Convert.ToBase64String(hash);
            }
            return "";
        }
    }
}
