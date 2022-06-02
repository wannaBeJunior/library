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
    public partial class addBook : Form
    {
        CMySql DBConnect = new CMySql();
        List<string> errors = new List<string> { };
        public addBook()
        {
            InitializeComponent();
            getAllComboBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.ToString();
            string date = textBox2.Text.ToString();
            string review = textBox3.Text.ToString();
            string pagesCount = textBox4.Text.ToString();
            string strGenre = textBox5.Text.ToString();
            string strAuthor = textBox6.Text.ToString();
            string strCountry = textBox7.Text.ToString();
            int genreId;
            int authorId;
            int countryId;
            if (comboBox1.SelectedIndex != 0)
            {
                genreId = Convert.ToInt32(comboBox1.SelectedItem.ToString().Substring(0, 1));
            }else
            {
                genreId = DBConnect.execInsert($"INSERT INTO `genres`(name) VALUES ('{strGenre}')");
            }
            if (comboBox2.SelectedIndex != 0)
            {
                authorId = Convert.ToInt32(comboBox2.SelectedItem.ToString().Substring(0, 1));
            }
            else
            {
                string[] names = strAuthor.Split();
                authorId = DBConnect.execInsert($"INSERT INTO `authors`(name, surname, lastname) VALUES ('{names[0]}', '{names[1]}', '{names[2]}')");
            }
            if (comboBox3.SelectedIndex != 0)
            {
                countryId = Convert.ToInt32(comboBox3.SelectedItem.ToString().Substring(0, 1));
            }
            else
            {
                countryId = DBConnect.execInsert($"INSERT INTO `countries`(name) VALUES ('{strCountry}')");
            }

            int result = DBConnect.execInsert($"INSERT INTO books(`name`, `bookDate`, `review`, `pagesCount`, `authors_id`, `genres_id`, `countries_id`) VALUES ('{name}', '{date}', '{review}', '{pagesCount}', '{authorId}', '{genreId}', '{countryId}')");
            if(!Convert.ToBoolean(result))
            {
                errors.Add("Что-то пошло не так! Попробуйте позже");
                CErrors.showErrors(errorsLabel, this, errors);
            }
        }

        private void getAllComboBoxes()
        {
            List<DataRow> genres = DBConnect.execSelect($"SELECT * FROM `genres`");
            if (genres.Count > 0)
            {
                genres.ForEach(delegate (DataRow row) { comboBox1.Items.Add(row["id"].ToString() + " " + row["name"].ToString()); });
                comboBox1.SelectedIndex = 0;
            }
            List<DataRow> authors = DBConnect.execSelect($"SELECT * FROM `authors`");
            if (authors.Count > 0)
            {
                authors.ForEach(delegate (DataRow row) { comboBox2.Items.Add(row["id"].ToString() + " " + row["name"].ToString() + " " + row["surname"].ToString()); });
                comboBox2.SelectedIndex = 0;
            }
            List<DataRow> countries = DBConnect.execSelect($"SELECT * FROM `countries`");
            if (countries.Count > 0)
            {
                countries.ForEach(delegate (DataRow row) { comboBox3.Items.Add(row["id"].ToString() + " " + row["name"].ToString()); });
                comboBox3.SelectedIndex = 0;
            }
        }
    }
}
