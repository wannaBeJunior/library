using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime;

namespace library
{
    public partial class main : Form
    {
        public Form form1;
        public main(Form form1)
        {
            this.form1 = form1;
            InitializeComponent();
            setLabelText();
        }

        public void setLabelText()
        {
            string text = "";
            DateTime localDate = DateTime.Now;
            int hours = Convert.ToInt32(localDate.ToString("HH"));
            if(hours >= 20 & hours < 7)
            {
                text = "Доброй ночи.";
            }
            if (hours >= 7 & hours < 10)
            {
                text = "Доброe утро.";
            }
            else
            {
                text = "Добрый день.";
            }
            label2.Text = text;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Close();
        }
    }
}
