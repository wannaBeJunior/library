using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using library.classes;

namespace library
{
    public partial class statisticForm : Form
    {
        public int availableBooksCount = 0;
        public int unAvailableBooksCount = 0;
        public int totalBooksCount = 0;

        public int readersCount = 0;

        public int employeesCount = 0;

        public statisticForm()
        {
            InitializeComponent();
        }

        private void statisticForm_Load(object sender, EventArgs e)
        {
            setStatistic();
            printStatistic();
        }

        private void setStatistic()
        {
            CMySql DB = new CMySql();
            List<DataRow> booksCount = new List<DataRow>();
            booksCount = DB.execSelect("SELECT books.name as 'book',books.id, books.authors_id, books.genres_id,books.bookDate, books.review, books.pagesCount, authors.id, concat(authors.name, ' ', authors.surname, ' ', authors.lastname) as 'authorName', genres.id, genres.name as 'genre', countries.name as 'country', countries.id, readings.books_id as 'status' FROM `books` JOIN `authors` ON `authors`.`id` = `books`.`authors_id` JOIN `genres` ON `genres`.`id` = `books`.`genres_id` JOIN `countries` ON `books`.`countries_id` = `countries`.`id` LEFT JOIN `readings` ON `books`.`id` = `readings`.`books_id`;");
            booksCount.ForEach(delegate(DataRow row) {
                if (row["status"].ToString() == "")
                {
                    availableBooksCount++;
                }else
                {
                    unAvailableBooksCount++;
                }
            });
            totalBooksCount = availableBooksCount + unAvailableBooksCount;

            employeesCount = DB.getCount("SELECT count(id) FROM `employees`;");

            readersCount = DB.getCount("SELECT count(id) FROM `readers`;");
        }

        private void printStatistic()
        {
            label2.Text = $"Всего книг в библиотеке: {totalBooksCount} шт.\nИз них на руках - {unAvailableBooksCount} шт.\nНа полках - {availableBooksCount} шт.\nВсего читателей: {readersCount} чел.\nВсего персонала: {employeesCount} чел.";
        }

        private void Print_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPageHandler;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print();
        }

        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(label2.Text, new Font("Arial", 14), Brushes.Black, 0, 0);
        }
    }
}
