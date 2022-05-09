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
    public partial class myBooks : Form
    {
        public int userId;

        public int booksCount;

        public List<DataRow> books = new List<DataRow>();
        
        CMySql DB = new CMySql();
        public myBooks(int id)
        {
            userId = id;
            booksCount = 0;
            InitializeComponent();
            getMyBooks();
        }

        public void getMyBooks()
        {
            books = DB.execSelect($"SELECT `readings`.`id`, `readings`.`dateStart`, `readings`.`dateEnd`, `readings`.`books_id`,  `readings`.`readers_id`, `books`.`id`, `books`.`name` as 'book', `books`.`bookDate`, `books`.`authors_id`, `authors`.`id`, concat(`authors`.`name`, ' ', `authors`.`surname`, ' ', `authors`.`lastname`) as 'name' FROM `readings` JOIN `books` ON `readings`.`books_id` = `books`.`id` JOIN `authors` ON `books`.`authors_id` = `authors`.`id` WHERE `readings`.`readers_id` = {userId} AND `readings`.`dateEnd` > CURDATE();");
            if (books.Count > 0)
            {
                dataGridView1.RowCount = books.Count;
                books.ForEach(delegate (DataRow row) { setTable(row); });
            }
        }

        public void setTable(DataRow row)
        {
            dataGridView1.Rows[this.booksCount].Cells[0].Value = Convert.ToString(row["book"]);
            dataGridView1.Rows[this.booksCount].Cells[1].Value = Convert.ToString(row["bookDate"]);
            dataGridView1.Rows[this.booksCount].Cells[2].Value = Convert.ToString(row["name"]);
            var parsedDate = DateTime.Parse(Convert.ToString(row["dateEnd"]));
            dataGridView1.Rows[this.booksCount].Cells[3].Value = parsedDate.ToString("yyyy-MM-dd");
            this.booksCount++;
        }
    }
}
