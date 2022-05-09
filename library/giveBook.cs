using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using library.classes;

namespace library
{
    public partial class giveBook : Form
    {
        public Dictionary<int, string> allReaders = new Dictionary<int, string>();
        public Dictionary<int, string> allBooks = new Dictionary<int, string>();

        CMySql DB = new CMySql();

        public List<string> errors = new List<string>();
        
        public int formHeight;
        public giveBook()
        {
            InitializeComponent();
            getBooks();
            getReaders();
            setTextBox();
            setComboBoxes();
            formHeight = this.Height;
        }

        public void setTextBox()
        {
            daysTextBox.Text = "14";
        }

        public void setComboBoxes()
        {
            readersComboBox.SelectedIndex = 0;
            booksComboBox.SelectedIndex = 0;

            foreach (var kvp in allReaders)
            {
                readersComboBox.Items.Add(kvp.Value.ToString());
            }

            foreach (var kvp in allBooks)
            {
                booksComboBox.Items.Add(kvp.Value.ToString());
            }
        }

        public void getBooks()
        {
            List<DataRow> books = DB.execSelect("SELECT concat(books.name, ' ', books.bookDate, 'г.') as 'book', `id` FROM `books` order by `id` asc;");
            books.ForEach(delegate (DataRow book) {
                allBooks.Add(Convert.ToInt32(book["id"]), book["book"].ToString());
            });
        }

        public void getReaders()
        {
            List<DataRow> readers = DB.execSelect("SELECT concat(users.name, ' ', users.surname, ' ', users.lastname) as 'readersName', `id` FROM `users` order by `id` asc;");
            readers.ForEach(delegate (DataRow reader) {
                allReaders.Add(Convert.ToInt32(reader["id"]), reader["readersName"].ToString());
            });
        }

        private void giveButton_Click(object sender, EventArgs e)
        {
            resetForm();
            string reader = readersComboBox.SelectedItem.ToString();
            int readerId = allReaders.Where(x => x.Value == reader).FirstOrDefault().Key;
            
            string book = booksComboBox.SelectedItem.ToString();
            int bookId = allBooks.Where(x => x.Value == book).FirstOrDefault().Key;

            if(readerId > 0 && bookId > 0)
            {
                int days = Convert.ToInt32(daysTextBox.Text);
                DateTime dateStart = DateTime.Now;
                //Проверим доступность книги
                int count = DB.getCount($"SELECT count(id) FROM `readings` WHERE `dateEnd` > CURDATE() AND `books_id` = {bookId};");

                if (count > 0)
                {
                    DateTime date = new DateTime();
                    dateStart = Convert.ToDateTime(DB.execSelect($"SELECT `dateEnd` FROM `readings` WHERE `books_id` = {bookId} order by `id` desc limit 1;")[0]["dateEnd"].ToString());
                }
                DateTime dateEnd = dateStart.AddDays(days);
                try
                {
                    DB.execInsert($"INSERT INTO `readings` (`dateStart`, `dateEnd`, `books_id`, `readers_id`) VALUES ('{dateStart.ToString("yyyy-MM-dd")}', '{dateEnd.ToString("yyyy-MM-dd")}', '{bookId}', '{readerId}')");
                    label5.Text = $"Готово! Получить книгу можно с {dateStart.ToString("yyyy-MM-dd")}";             
                }catch
                {
                    errors.Add("Не удалось создать запись. Попробуйте позже!");
                    CErrors.showErrors(label6, this, errors);
                }
            }else if(readerId < 1 || bookId < 1)
            {
                errors.Add("Укажите читателя и выберите книгу!");
                CErrors.showErrors(label6, this, errors);
                return;
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
