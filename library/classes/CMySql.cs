using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace library.classes
{
    class CMySql
    {
        public string host = "localhost";
        public int port = 3306;
        public string database = "library";
        public string username = "root";
        public string password = "root";
        public MySqlConnection connecting;
        public List<DataRow> result = new List<DataRow>();

        public CMySql()
        {
            GetDBConnection(host, port, database, username, password);
            connecting.Open();
        }

        public void GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            connecting = new MySqlConnection(connString);
        }

        public List<DataRow> execSelect(string SqlQuery)
        {
            List<DataRow> resultList = new List<DataRow>();
            MySqlCommand command = new MySqlCommand(SqlQuery, connecting);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable result = new DataTable();
            adapter.Fill(result);
            foreach (DataRow row in result.Rows)
            {
                resultList.Add(row);
            }
            return resultList;
        }

        public int getCount(string SqlQuery)
        {
            int count = 0;
            MySqlCommand command = new MySqlCommand(SqlQuery, connecting);
            count = Convert.ToInt32(command.ExecuteScalar());
            return count;
        }

        public int execInsert(string SqlQuery)
        {
            MySqlCommand command = new MySqlCommand(SqlQuery, connecting);
            command.ExecuteScalar();
            return Convert.ToInt32(command.LastInsertedId);
        }

        public int execUpdate(string SqlQuery)
        {
            return execInsert(SqlQuery);
        }

        public string getId(string SqlQuery)
        {
            MySqlCommand command = new MySqlCommand(SqlQuery, connecting);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                return reader["id"].ToString();
            }
        }

        public bool addNewUser(ref List<string> errors, string login, string password, string name, string surname, string lastname, string phone, string street, string building, string apartments, char accessLevel)
        {
            if (!CValidate.loginValidate(login))
            {
                errors.Add("Логин должен быть короче 45 символов, но длинее 1 символа");
            }
            if (!CValidate.nameValidate(name))
            {
                errors.Add("Имя не может содержать числа");
            }
            if (!CValidate.nameValidate(surname))
            {
                errors.Add("Фамилия не может содержать числа");
            }
            if (!CValidate.nameValidate(lastname))
            {
                errors.Add("Отчество не может содержать числа");
            }
            if (!CValidate.passwordValidate(password))
            {
                errors.Add("Длина пароля должна быть больше 6 и пароль \nдолжен содержать заглавные буквы, цифры и занки препинания");
            }
            if(!CValidate.phoneValidate(phone))
            {
                errors.Add("Некоректный номер телефона");
            }
            if (errors.Count < 1)
            {
                string hashedPassword = CValidate.preparePassword(password);
                try
                {
                    execInsert($"INSERT INTO `library`.`users` (`login`, `password`, `name`, `surname`, `lastname`, `dateOfRegister`, `phone`, `street`, `building`, `apartments`, `accessLevels_id`) VALUES ('{login}', '{hashedPassword}', '{name}', '{surname}', '{lastname}', '2022-08-05', '{phone}', '{street}', '{building}', '{apartments}', '{accessLevel}');");
                }
                catch
                {
                    errors.Add("Сотрудник с таким логином уже существует.");
                }
                return true;
            }
            return false;
        }
    }
}
