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
    public partial class returneBook : Form
    {
        CMySql DB = new CMySql();

        public List<string> errors = new List<string>();
        Dictionary<int, string> readingsEndDates = new Dictionary<int, string>();
        public returneBook()
        {
            InitializeComponent();
            getAllReadings();
            if(errors.Count > 0)
            {
                CErrors.showErrors(errorsLabel, this, errors);
            }
        }

        public void getAllReadings()
        {
            List<DataRow> readings = DB.execSelect($"SELECT readings.id as 'id', readings.dateEnd, readings.status, readings.books_id, readings.readers_id, bs.name as 'bookName', bs.bookDate, concat(rs.name, ' ', rs.surname) as 'name' FROM readings JOIN books bs ON bs.id = readings.books_id JOIN users rs ON rs.id = readings.readers_id WHERE readings.status = 0;");
            readings.ForEach(delegate(DataRow row) { readingsEndDates.Add(Convert.ToInt32(row["id"]), row["dateEnd"].ToString() + " " + row["readers_id"].ToString()); comboBox1.Items.Add(row["id"].ToString() + " " + row["bookName"].ToString() + " Вернуть до - " + row["dateEnd"].ToString() + " Взята пользователем - " + row["name"].ToString()); });
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                errors.Add("Выберите запись!");
                return;
            }
            string successMsg = "";
            int id = Convert.ToInt32(comboBox1.SelectedItem.ToString().Substring(0, 1));
            int userId = Convert.ToInt32(readingsEndDates[id].Split()[2]);
            DateTime dateEnd = new DateTime();
            dateEnd = Convert.ToDateTime(readingsEndDates[id].Split()[0]);
            DateTime dateNow = DateTime.Now;
            if(dateNow > dateEnd)
            {
                int reputation = Convert.ToInt32(DB.execSelect($"SELECT `reputation` FROM `users` WHERE `id` = {userId}")[0]["reputation"]);
                reputation -= 10;
                try
                {
                    DB.execUpdate($"UPDATE `users` SET `reputation` = {reputation} WHERE `id` = {userId}");
                    successMsg += "Репутация пользователя снижена!";
                }
                catch
                {
                    errors.Add("Что-то пошло не так! Попробуйте позже!");
                    return;
                }
            }
            
            try
            {
                DB.execUpdate($"UPDATE readings SET `status` = 1 WHERE id = {id}");
            }catch
            {
                errors.Add("Что-то пошло не так! Попробуйте позже!");
                return;
            }
            successLabel.Text = successMsg + "Книга успешно возвращена!";
        }
    }
}
