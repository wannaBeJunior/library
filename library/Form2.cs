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

        public List<string> columns = new List<string>() { "id", "name", "bookDate", "review", "pagesCount", "genres_id", "countries_id", "authors_id" };

        CMySql DB = new CMySql();

        bool firstHit = true;
        public main(Form form1, char accessLevel)
        {
            this.form1 = form1;
            InitializeComponent();
            checkAccessLevel(accessLevel);
            setLabelText();
            getBooks();
            firstHit = false;
        }

        public void checkAccessLevel(char accessLevel)
        {
            if(accessLevel.CompareTo('A') <= 0)
            {
                menuStrip1.Hide();
            }
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
            books = DB.execSelect("SELECT books.name as 'book',books.id, books.authors_id, books.genres_id,books.bookDate, books.review, books.pagesCount, authors.id, concat(authors.name, ' ', authors.surname, ' ', authors.lastname) as 'authorName', genres.id, genres.name as 'genre', countries.name as 'country', countries.id FROM `books` JOIN `authors` ON `authors`.`id` = `books`.`authors_id` JOIN `genres` ON `genres`.`id` = `books`.`genres_id` JOIN `countries` ON `books`.`countries_id` = `countries`.`id`;");
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
            this.booksCount++;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Close();
        }

        public void getAllSmartFilterParameters()
        {
            List<DataRow> authors = DB.execSelect("SELECT concat(authors.name, ' ', authors.surname, ' ', authors.lastname) as 'authorName' FROM `authors`");
            authors.ForEach(delegate(DataRow author) {
                allAuthors.Add(author["authorName"].ToString());
            });
            
            List<DataRow> genres = DB.execSelect("SELECT * FROM `genres`");
            genres.ForEach(delegate (DataRow genre) {
                allGenres.Add(genre["name"].ToString());
            });

            List<DataRow> countries = DB.execSelect("SELECT * FROM `countries`");
            countries.ForEach(delegate (DataRow country) {
                allCountries.Add(country["name"].ToString());
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
            firstHit = true;
            tableClear();
            setSmartFilterParameters();
            resultsFiltered();
            firstHit = false;
        }

        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statisticForm statisticForm = new statisticForm();
            statisticForm.Show();
        }

        private void addEmplToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addEmployeeForm addEmployeeForm = new addEmployeeForm();
            addEmployeeForm.Show();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(firstHit)
            {
                return;
            }
            int row = Convert.ToInt32(e.RowIndex);
            int column = Convert.ToInt32(e.ColumnIndex);
            string fieldName = "";
            if ( row > -1 && column > -1)
            {
                string newText = dataGridView1.Rows[row].Cells[column].Value.ToString();
                int id = Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
                if (column == 0)
                {
                    errors.Add("Нельзя поменять id записи!");
                    return;
                }
                if(column == 5)
                {
                    //Новый жанр
                    if(!CList.findInStringList(newText, allGenres))
                    {
                        newText = DB.execInsert($"INSERT INTO `genres` (`name`) VALUES ('{newText}');").ToString();
                    }
                    else
                    {
                        newText = DB.getId($"SELECT `id` FROM `genres` WHERE `name` = '{newText}';");
                    }
                }
                if (column == 6)
                {
                    //Новая страна
                    if (!CList.findInStringList(newText, allCountries))
                    {
                        newText = DB.execInsert($"INSERT INTO `countries` (`name`) VALUES ('{newText}');").ToString();
                    }
                    else
                    {
                        newText = DB.getId($"SELECT `id` FROM `countries` WHERE `name` = '{newText}';");
                    }
                }
                if (column == 7)
                {
                    //Новый автор
                    string[] names = newText.Split(' ');
                    if (!CList.findInStringList(newText, allAuthors))
                    {
                        newText = DB.execInsert($"INSERT INTO `authors` (`name`, `surname`, `lastname`) VALUES ('{names[0]}', '{names[1]}', '{names[2]}');").ToString();
                    }
                    else
                    {
                        newText = DB.getId($"SELECT `id` FROM `authors` WHERE `name` = '{names[0]}' AND `surname` = '{names[1]}' AND `lastname` = '{names[2]}';");
                    }
                }
                fieldName = columns[column];
                try
                {
                    DB.execUpdate($"UPDATE `books` SET `{fieldName}`='{newText}' WHERE `id` = {id};");
                }catch
                {
                    MessageBox.Show("Не удалось обновить запись. Попробуйте позже!");
                }
            }
        }

        private void giveBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giveBook givBookForm = new giveBook();
            givBookForm.Show();
        }

        private void addReaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addReader addReaderForm = new addReader();
            addReaderForm.Show();
        }
    }
}