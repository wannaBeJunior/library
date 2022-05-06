﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            MySqlCommand command = new MySqlCommand(SqlQuery, connecting);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable result = new DataTable();
            adapter.Fill(result);
            foreach (DataRow row in result.Rows)
            {
                this.result.Add(row);
            }
            return this.result;
        }

        public int getCount(string SqlQuery)
        {
            int count = 0;
            MySqlCommand command = new MySqlCommand(SqlQuery, connecting);
            count = Convert.ToInt32(command.ExecuteScalar());
            return count;
        }

        public bool execInsert(string SqlQuery)
        {
            MySqlCommand command = new MySqlCommand(SqlQuery, connecting);
            return Convert.ToBoolean(command.ExecuteNonQuery());
        }
    }
}
