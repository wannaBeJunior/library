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

        CMySql DB = new CMySql();

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
            totalBooksCount = DB.getCount("SELECT count(id) FROM `books`");
            employeesCount = DB.getCount("SELECT count(id) FROM `employees`;");
            readersCount = DB.getCount("SELECT count(id) FROM `readers`;");
        }

        private void printStatistic()
        {
            label2.Text = $"Всего книг в библиотеке: {totalBooksCount} шт.\nВсего читателей: {readersCount} чел.\nВсего персонала: {employeesCount} чел.";
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
