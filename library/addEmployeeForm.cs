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
using library.classes;

namespace library
{
    public partial class addEmployeeForm : Form
    {
        public List<string> errors = new List<string>();

        public int formHeight;
        public addEmployeeForm()
        {
            InitializeComponent();
            formHeight = this.Height;
        }

        private void addEmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetForm();
            validateInputData();
        }

        private void validateInputData()
        {
            if(!CValidate.loginValidate(loginTextBox.Text))
            {
                errors.Add("Логин должен быть короче 45 символов, но длинее 1 символа");
            }
            if(!CValidate.nameValidate(nameTextBox.Text))
            {
                errors.Add("Имя не может содержать числа");
            }
            if (!CValidate.nameValidate(surnameTextBox.Text))
            {
                errors.Add("Фамилия не может содержать числа");
            }
            if (!CValidate.nameValidate(lastNameTextBox.Text))
            {
                errors.Add("Отчество не может содержать числа");
            }
            if(!CValidate.passwordValidate(passwordTextBox.Text))
            {
                errors.Add("Длина пароля должна быть больше 6 и пароль \nдолжен содержать заглавные буквы, цифры и занки препинания");
            }
            if(errors.Count > 0)
            {
                CErrors.showErrors(errorsLabel, this, errors);
            }else
            {
                saveEmployeeToDB();
            }
        }

        public void saveEmployeeToDB()
        {
            string password = preparePassword(passwordTextBox.Text);
            CMySql DBConn = new CMySql();
            try
            {
                DBConn.execInsert($"INSERT INTO `employees` (`name`, `surname`, `lastname`, `login`, `password`) VALUES ('{nameTextBox.Text}', '{surnameTextBox.Text}', '{lastNameTextBox.Text}', '{loginTextBox.Text}', '{password}');");
            }
            catch
            {
                resetForm();
                errors.Add("Сотрудник с таким логином уже существует.");
                CErrors.showErrors(errorsLabel, this, errors);
            }
            /*if()
            {
                errorsLabel.ForeColor = Color.Green;
                errorsLabel.Text = "Сотрудник добавлен в БД. \nСообщите ему логин и пароль для входа.";
            }else
            {
                resetForm();
                errors.Add("Сотрудник с таким логином уже существует.");
                CErrors.showErrors(errorsLabel, this, errors);
            }*/
        }

        static public string preparePassword(string password)
        {
            if(password.Length > 0)
            {
                var md5 = MD5.Create();
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

                return Convert.ToBase64String(hash);
            }
            return "";
        }

        public void resetForm()
        {
            this.Height = formHeight;
            errors.Clear();
        }
    }
}
