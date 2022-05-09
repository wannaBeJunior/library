using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library.classes;

namespace library
{
    public partial class editProfile : Form
    {
        CMySql DB = new CMySql();

        public List<string> errors = new List<string>();

        public string password;

        public int userId;

        public int formHeight;
        public editProfile(int id)
        {
            InitializeComponent();
            userId = id;
            formHeight = this.Height;
            getProfile(id);
        }

        public void getProfile(int id)
        {
            DB.execSelect($"SELECT * FROM library.users WHERE `id` = {id};").ForEach(delegate (DataRow row) {
                loginTextBox.Text = row["login"].ToString();
                passwordTextBox.Text = row["password"].ToString();
                password = row["password"].ToString();
                nameTextBox.Text = row["name"].ToString();
                surnameTextBox.Text = row["surname"].ToString();
                lastNameTextBox.Text = row["lastname"].ToString();
                phoneNumTextBox.Text = row["phone"].ToString();
                streetTextBox.Text = row["street"].ToString();
                buildingTextBox.Text = row["building"].ToString();
                apartmentsTextBox.Text = row["apartments"].ToString();
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetForm();
            if (!CValidate.loginValidate(loginTextBox.Text))
            {
                errors.Add("Логин должен быть короче 45 символов, но длинее 1 символа");
            }
            if (!CValidate.nameValidate(nameTextBox.Text))
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
            if (password != passwordTextBox.Text)
            {
                if (!CValidate.passwordValidate(passwordTextBox.Text))
                {
                    errors.Add("Длина пароля должна быть больше 6 и пароль \nдолжен содержать заглавные буквы, цифры и занки препинания");
                }
            }
            if (!CValidate.phoneValidate(phoneNumTextBox.Text))
            {
                errors.Add("Некоректный номер телефона");
            }
            if (errors.Count < 1)
            {
                string hashedPassword = password;
                if (password != passwordTextBox.Text)
                {
                    hashedPassword = CValidate.preparePassword(passwordTextBox.Text);
                }
                try
                {
                    DB.execUpdate($"UPDATE `library`.`users` SET `login` = '{loginTextBox.Text}', `password` = '{hashedPassword}', `name` = '{nameTextBox.Text}', `surname` = '{surnameTextBox.Text}', `lastname` = '{lastNameTextBox.Text}', `phone` = '{phoneNumTextBox.Text}', `street` = '{streetTextBox.Text}', `building` = '{buildingTextBox.Text}', `apartments` = '{apartmentsTextBox.Text}' WHERE (`id` = '{userId}');");
                }
                catch
                {
                    errors.Add("Пользователь с таким логином уже существует.");
                }
            }
            if (errors.Count > 0)
            {
                CErrors.showErrors(errorsLabel, this, errors);
            }else
            {
                successLabel.Text = "Изменения успешно сохранены!";
            }
        }
        public void resetForm()
        {
            errorsLabel.Text = "";
            this.Height = formHeight;
            errors.Clear();
        }
    }
}
