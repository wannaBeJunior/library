using System;
using System.Collections.Generic;
using System.Data;
using System.Media;
using System.Windows.Forms;
using library.classes;

namespace library
{
    public partial class main : Form
    {
        public Form form1;
        public List<string> errors = new List<string>();
        public List<DataRow> books = new List<DataRow>();
        public List<DataRow> filteredBooks = new List<DataRow>();
        public int booksCount;

        public string bookNameInSmartFilter;
        public int bookYearInSmartFilter;
        public int pagesCountInSmartFilter;
        public string authorInSmartFilter;
        public string genreInSmartFilter;
        public string countryInSmartFilter;

        public List<string> allAuthors = new List<string>();
        public List<string> allGenres = new List<string>();
        public List<string> allCountries = new List<string>();
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
            if (hours > 20 & hours < 7)
            {
                text = "Доброй ночи";
            }
            else if (hours > 6 & hours < 11)
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
            if (books.Count > 0)
            {
                getAllSmartFilterParameters();
                dataGridView1.RowCount = books.Count;
                books.ForEach(delegate (DataRow row) { setTable(row); });
            }
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
            if (row["status"].ToString() == "")
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

        public void getAllSmartFilterParameters()
        {
            this.books.ForEach(delegate (DataRow row)
            {
                allAuthors.Add(row["authorName"].ToString());
                allGenres.Add(Convert.ToString(row["genre"]));
                allCountries.Add(Convert.ToString(row["country"]));
            });

            allAuthors.ForEach(delegate (string name) { authorComboBox.Items.Add(name); });
            authorComboBox.SelectedIndex = 0;
            allGenres.ForEach(delegate (string genre) { genresComboBox2.Items.Add(genre); });
            genresComboBox2.SelectedIndex = 0;
            allCountries.ForEach(delegate (string country) { countryComboBox.Items.Add(country); });
            countryComboBox.SelectedIndex = 0;
        }

        public void setSmartFilterParameters()
        {
            bookNameInSmartFilter = bookNameTextBox.Text;
            if (bookDateTextBox.Text != "")
            {
                bookYearInSmartFilter = Convert.ToInt32(bookDateTextBox.Text);
            }
            else
            {
                bookYearInSmartFilter = 0;
            }
            if (pageCountTextBox.Text != "")
            {
                pagesCountInSmartFilter = Convert.ToInt32(pageCountTextBox.Text);
            }
            else
            {
                pagesCountInSmartFilter = 0;
            }

            if (authorComboBox.SelectedIndex != 0)
            {
                authorInSmartFilter = allAuthors[authorComboBox.SelectedIndex - 1];
            }
            else
            {
                authorInSmartFilter = "";
            }

            if (genresComboBox2.SelectedIndex != 0)
            {
                genreInSmartFilter = allGenres[genresComboBox2.SelectedIndex - 1];
            }
            else
            {
                genreInSmartFilter = "";
            }

            if (countryComboBox.SelectedIndex != 0)
            {
                countryInSmartFilter = allCountries[countryComboBox.SelectedIndex - 1];
            }
            else
            {
                countryInSmartFilter = "";
            }
        }

        private void resultsFiltered()
        {
            setListOfFilteredBooks();
        }

        private void setListOfFilteredBooks()
        {
            books.ForEach(delegate (DataRow row)
            {
                filteredBooks.Add(row);
                if (bookNameInSmartFilter != "")
                {
                    if (row["book"].ToString() != bookNameInSmartFilter)
                    {
                        filteredBooks.Remove(row);
                        return;
                    }
                }
                if (bookYearInSmartFilter != 0)
                {
                    if (Convert.ToInt32(row["bookDate"]) != bookYearInSmartFilter)
                    {
                        filteredBooks.Remove(row);
                        return;
                    }
                }
                if(pagesCountInSmartFilter != 0)
                {
                    if(Convert.ToInt32(row["pagesCount"]) != pagesCountInSmartFilter)
                    {
                        filteredBooks.Remove(row);
                        return;
                    }
                }
                if(authorInSmartFilter != "")
                {
                    if(row["authorName"].ToString() != authorInSmartFilter)
                    {
                        filteredBooks.Remove(row);
                        return;
                    }
                }
                if (genreInSmartFilter != "")
                {
                    if (row["genre"].ToString() != genreInSmartFilter)
                    {
                        filteredBooks.Remove(row);
                        return;
                    }
                }
                if (countryInSmartFilter != "")
                {
                    if (row["country"].ToString() != countryInSmartFilter)
                    {
                        filteredBooks.Remove(row);
                        return;
                    }
                }
            });
            this.booksCount = 0;
            if(filteredBooks.Count != 0)
            {
                dataGridView1.RowCount = filteredBooks.Count;
            }else
            {
                dataGridView1.RowCount = 1;
            }
            filteredBooks.ForEach(delegate (DataRow row) { setTable(row); });
        }

        private void tableClear()
        {
            filteredBooks.Clear();
            dataGridView1.Rows.Clear();
        }

        private void filterApply_Click(object sender, EventArgs e)
        {
            tableClear();
            setSmartFilterParameters();
            resultsFiltered();
        }

        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statisticForm statisticForm = new statisticForm();
            statisticForm.Show();
        }
    }
}