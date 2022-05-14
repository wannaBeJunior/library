using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
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
        public List<DataRow> mostPopularBook = new List<DataRow>();
        
        public int usersCount = 0;
        public int readersCount = 0;
        public int employeesCount = 0;
        public List<DataRow> mostActiveReader = new List<DataRow>();

        public string printingText = "";

        CMySql DB = new CMySql();

        public statisticForm()
        {
            InitializeComponent();
        }

        private void statisticForm_Load(object sender, EventArgs e)
        {
            setStatistic();
            printStatistic();
            setPrintingText();
        }

        private void setStatistic()
        {
            totalBooksCount = DB.getCount("SELECT count(id) FROM `books`");
            unAvailableBooksCount = DB.getCount("SELECT count(`books`.`id`) FROM `books` JOIN `readings` ON `readings`.`books_id` = `books`.`id` AND CURDATE() <= `readings`.`dateEnd`;");
            mostPopularBook = DB.execSelect("SELECT bookDate, name, books_id, count(1) cnt FROM readings JOIN `books` ON `readings`.`books_id` = `books`.`id` WHERE readers_id=(SELECT readers_id FROM readings GROUP BY readers_id ORDER BY count(1) DESC LIMIT 1) GROUP BY books_id ORDER BY cnt DESC LIMIT 1;");

            usersCount = DB.getCount("SELECT count(id) FROM `users`");
            readersCount = DB.getCount("SELECT count(`users`.`id`) FROM `users` WHERE `accessLevels_id` = 2");
            mostActiveReader = DB.execSelect("SELECT name, surname, readers_id, count(1) cnt FROM readings JOIN `users` ON `readings`.`readers_id` = `users`.`id` GROUP BY readers_id ORDER BY cnt DESC LIMIT 1;");
        }

        private void printStatistic()
        {
            totalBooksLabel.Text += totalBooksCount.ToString() + " шт.";
            unavailableBooksCountLabel.Text += unAvailableBooksCount.ToString() + " шт.";
            availableBooksCountLabel.Text += (totalBooksCount - unAvailableBooksCount).ToString() + " шт.";
            mostPopularBookLabel.Text += "[" + mostPopularBook[0]["books_id"].ToString() + "] " + mostPopularBook[0]["name"].ToString() + " " + mostPopularBook[0]["bookDate"].ToString() + "г.";

            totalUsersCountLabel.Text += usersCount.ToString() + " чел.";
            readersCountLabel.Text += readersCount.ToString() + " чел.";
            employeesCountLabel.Text += (usersCount - readersCount).ToString() + " чел.";
            mostActiveReaderLabel.Text += "[" + mostActiveReader[0]["readers_id"].ToString() + "] " + mostActiveReader[0]["name"].ToString() + " " + mostActiveReader[0]["surname"].ToString();
        }

        private void setPrintingText()
        {
            printingText = "Статистика по книгам:"
                + "\n" + totalBooksLabel.Text 
                + "\n" + unavailableBooksCountLabel.Text 
                + "\n" + availableBooksCountLabel.Text 
                + "\n" + mostPopularBookLabel.Text
                + "\n" + "Статистика по пользователям:"
                + "\n" + totalUsersCountLabel.Text
                + "\n" + readersCountLabel.Text
                + "\n" + employeesCountLabel.Text
                + "\n" + mostActiveReaderLabel.Text;
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
            e.Graphics.DrawString(printingText, new Font("Arial", 14), Brushes.Black, 0, 0);
        }
    }
}
