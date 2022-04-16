using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using library.classes;

namespace library
{
    public partial class signin : Form
    {
        public string login = "";
        public string passwordHash = "";
        public List<string> errors = new List<string>();
        public int formHeight;
        public signin()
        {
            InitializeComponent();
            formHeight = this.Height;
        }

        private void doSignin(object sender, EventArgs e)
        {
            setData();
            if (errors.Count > 0)
            {
                showErrors();
            }
            else
            {
                startSignin();
                if (errors.Count > 0)
                {
                    showErrors();
                }
            }
        }

        private void setData()
        {
            resetForm();
            if (textBox1.Text.ToString() == "")
            {
                errors.Add("Вы не ввели логин");
            }
            else
            {
                login = textBox1.Text.ToString();
            }
            if (textBox2.Text.ToString() == "")
            {
                errors.Add("Вы не ввели пароль");
            }
            else
            {
                passwordHash = GetHash(textBox2.Text.ToString());
            }
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        public void startSignin()
        {
            CMySql DBConnect = new CMySql();
            List<DataRow> result = DBConnect.execSelect($"SELECT * FROM `employees` WHERE `login` = '{this.login}'");
            if(result.Count > 0)
            {
                if(verifyPassword(Convert.ToString(result[0]["password"])))
                {
                    /*Form2 f2 = new Form2();
                    f2.Show();*/
                }
                else
                {
                    errors.Add("Неправильный пароль");
                }
            }
            else
            {
                errors.Add("Неправильный логин");
            }
        }

        public bool verifyPassword(string dbPassword)
        {
            if(dbPassword == passwordHash)
            {
                return true;
            }
            return false;
        }

        public void showErrors()
        {
            int height = label5.Height;
            this.Height += errors.Count * height;
            for (int i = 0; i < errors.Count; i++)
            {
                label5.Text += errors[i] + '\n';
            }
        }

        public void resetForm()
        {
            this.Height = formHeight;
            errors.Clear();
            label5.Text = "";
        }
    }
}
