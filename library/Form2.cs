using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using library.classes;

namespace library
{
    public partial class main : Form
    {
        public Form form1;
        public List<string> errors = new List<string>();
        public List<DataRow> books = new List<DataRow>();
        public int booksCount;
        public main(Form form1)
        {
            this.form1 = form1;
            InitializeComponent();
            setLabelText();
            getBooks();
        }

        public void setLabelText()
        {
            string text = "";
            DateTime localDate = DateTime.Now;
            int hours = Convert.ToInt32(localDate.ToString("HH"));
            if(hours > 20 & hours < 7)
            {
                text = "Доброй ночи";
            }else if(hours > 6 & hours < 11)
            {
                text = "Доброe утро";
            }
            else
            {
                text = "Добрый день";
            }
            label2.Text = text;
        }

        public void getBooks()
        {
            CMySql DBbooks = new CMySql();
            books = DBbooks.execSelect("SELECT books.name as 'book',books.id, books.authors_id, books.genres_id,books.bookDate, books.review, books.pagesCount, authors.id, concat(authors.name, ' ', authors.surname, ' ', authors.lastname) as 'authorName', genres.id, genres.name as 'genre', countries.name as 'country', countries.id, readings.books_id as 'status' FROM `books` JOIN `authors` ON `authors`.`id` = `books`.`authors_id` JOIN `genres` ON `genres`.`id` = `books`.`genres_id` JOIN `countries` ON `books`.`countries_id` = `countries`.`id` LEFT JOIN `readings` ON `books`.`id` = `readings`.`books_id`;");
            dataGridView1.RowCount = books.Count;
            books.ForEach(delegate(DataRow row) { setTable(row); });
        }

        public void setTable(DataRow row)
        {
            dataGridView1.Rows[this.booksCount].Cells[0].Value = Convert.ToString(row["id"]);
            dataGridView1.Rows[this.booksCount].Cells[1].Value = Convert.ToString(row["book"]);
            dataGridView1.Rows[this.booksCount].Cells[2].Value = Convert.ToString(row["bookDate"]);
            dataGridView1.Rows[this.booksCount].Cells[3].Value = Convert.ToString(row["review"]);
            dataGridView1.Rows[this.booksCount].Cells[4].Value = Convert.ToString(row["pagesCount"]);
            dataGridView1.Rows[this.booksCount].Cells[5].Value = Convert.ToString(row["genre"]);
            dataGridView1.Rows[this.booksCount].Cells[6].Value = Convert.ToString(row["country"]);
            dataGridView1.Rows[this.booksCount].Cells[7].Value = Convert.ToString(row["authorName"]);
            string status = "Книга не доступна";
            if(row["status"].ToString() == "")
            {
                status = "Книга доступна";
            }
            dataGridView1.Rows[this.booksCount].Cells[8].Value = status;
            this.booksCount++;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Close();
        }
    }
}
// 1. id = 1; name = 'Test'
// 2. id = 2; name = 'Test2'
