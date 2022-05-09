
namespace library
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.review = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagesCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smartFilterLabel = new System.Windows.Forms.Label();
            this.bookNameLabel = new System.Windows.Forms.Label();
            this.bookNameTextBox = new System.Windows.Forms.TextBox();
            this.bookDateLabel = new System.Windows.Forms.Label();
            this.bookDateTextBox = new System.Windows.Forms.TextBox();
            this.pageCountTextBox = new System.Windows.Forms.TextBox();
            this.pagesCountLabel = new System.Windows.Forms.Label();
            this.authorComboBox = new System.Windows.Forms.ComboBox();
            this.authorLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.genresComboBox2 = new System.Windows.Forms.ComboBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.filterApply = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.libraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giveBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emoloyeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокСотрудниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEmplToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(577, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 23);
            this.label2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Доступные книги";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.bookDate,
            this.review,
            this.pagesCount,
            this.genre,
            this.country,
            this.author});
            this.dataGridView1.Location = new System.Drawing.Point(266, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(978, 378);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // id
            // 
            this.id.HeaderText = "Идентификатор";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 125;
            // 
            // name
            // 
            this.name.HeaderText = "Название";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.Width = 125;
            // 
            // bookDate
            // 
            this.bookDate.HeaderText = "Дата написания";
            this.bookDate.MinimumWidth = 6;
            this.bookDate.Name = "bookDate";
            this.bookDate.Width = 125;
            // 
            // review
            // 
            this.review.HeaderText = "Описание";
            this.review.MinimumWidth = 6;
            this.review.Name = "review";
            this.review.Width = 125;
            // 
            // pagesCount
            // 
            this.pagesCount.HeaderText = "Кол-во страниц";
            this.pagesCount.MinimumWidth = 6;
            this.pagesCount.Name = "pagesCount";
            this.pagesCount.Width = 125;
            // 
            // genre
            // 
            this.genre.HeaderText = "Жанр";
            this.genre.MinimumWidth = 6;
            this.genre.Name = "genre";
            this.genre.Width = 125;
            // 
            // country
            // 
            this.country.HeaderText = "Страна";
            this.country.MinimumWidth = 6;
            this.country.Name = "country";
            this.country.Width = 125;
            // 
            // author
            // 
            this.author.HeaderText = "Автор";
            this.author.MinimumWidth = 6;
            this.author.Name = "author";
            this.author.Width = 125;
            // 
            // smartFilterLabel
            // 
            this.smartFilterLabel.AutoSize = true;
            this.smartFilterLabel.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartFilterLabel.Location = new System.Drawing.Point(12, 78);
            this.smartFilterLabel.Name = "smartFilterLabel";
            this.smartFilterLabel.Size = new System.Drawing.Size(156, 23);
            this.smartFilterLabel.TabIndex = 5;
            this.smartFilterLabel.Text = "Умный фильтр";
            // 
            // bookNameLabel
            // 
            this.bookNameLabel.AutoSize = true;
            this.bookNameLabel.Font = new System.Drawing.Font("Century", 10F);
            this.bookNameLabel.Location = new System.Drawing.Point(12, 104);
            this.bookNameLabel.Name = "bookNameLabel";
            this.bookNameLabel.Size = new System.Drawing.Size(146, 21);
            this.bookNameLabel.TabIndex = 6;
            this.bookNameLabel.Text = "Название книги";
            // 
            // bookNameTextBox
            // 
            this.bookNameTextBox.Location = new System.Drawing.Point(16, 129);
            this.bookNameTextBox.Name = "bookNameTextBox";
            this.bookNameTextBox.Size = new System.Drawing.Size(142, 22);
            this.bookNameTextBox.TabIndex = 7;
            // 
            // bookDateLabel
            // 
            this.bookDateLabel.AutoSize = true;
            this.bookDateLabel.Font = new System.Drawing.Font("Century", 10F);
            this.bookDateLabel.Location = new System.Drawing.Point(12, 159);
            this.bookDateLabel.Name = "bookDateLabel";
            this.bookDateLabel.Size = new System.Drawing.Size(135, 21);
            this.bookDateLabel.TabIndex = 8;
            this.bookDateLabel.Text = "Год написания";
            // 
            // bookDateTextBox
            // 
            this.bookDateTextBox.Location = new System.Drawing.Point(16, 184);
            this.bookDateTextBox.Name = "bookDateTextBox";
            this.bookDateTextBox.Size = new System.Drawing.Size(142, 22);
            this.bookDateTextBox.TabIndex = 9;
            // 
            // pageCountTextBox
            // 
            this.pageCountTextBox.Location = new System.Drawing.Point(16, 245);
            this.pageCountTextBox.Name = "pageCountTextBox";
            this.pageCountTextBox.Size = new System.Drawing.Size(142, 22);
            this.pageCountTextBox.TabIndex = 11;
            // 
            // pagesCountLabel
            // 
            this.pagesCountLabel.AutoSize = true;
            this.pagesCountLabel.Font = new System.Drawing.Font("Century", 10F);
            this.pagesCountLabel.Location = new System.Drawing.Point(12, 220);
            this.pagesCountLabel.Name = "pagesCountLabel";
            this.pagesCountLabel.Size = new System.Drawing.Size(139, 21);
            this.pagesCountLabel.TabIndex = 10;
            this.pagesCountLabel.Text = "Кол-во страниц";
            // 
            // authorComboBox
            // 
            this.authorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authorComboBox.FormattingEnabled = true;
            this.authorComboBox.Items.AddRange(new object[] {
            "Выберите автора"});
            this.authorComboBox.Location = new System.Drawing.Point(16, 294);
            this.authorComboBox.Name = "authorComboBox";
            this.authorComboBox.Size = new System.Drawing.Size(121, 24);
            this.authorComboBox.TabIndex = 12;
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Font = new System.Drawing.Font("Century", 10F);
            this.authorLabel.Location = new System.Drawing.Point(12, 270);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(58, 21);
            this.authorLabel.TabIndex = 13;
            this.authorLabel.Text = "Автор";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Font = new System.Drawing.Font("Century", 10F);
            this.genreLabel.Location = new System.Drawing.Point(12, 334);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(57, 21);
            this.genreLabel.TabIndex = 15;
            this.genreLabel.Text = "Жанр";
            // 
            // genresComboBox2
            // 
            this.genresComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genresComboBox2.FormattingEnabled = true;
            this.genresComboBox2.Items.AddRange(new object[] {
            "Выберите жанр"});
            this.genresComboBox2.Location = new System.Drawing.Point(16, 358);
            this.genresComboBox2.Name = "genresComboBox2";
            this.genresComboBox2.Size = new System.Drawing.Size(121, 24);
            this.genresComboBox2.TabIndex = 14;
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Font = new System.Drawing.Font("Century", 10F);
            this.countryLabel.Location = new System.Drawing.Point(12, 390);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(69, 21);
            this.countryLabel.TabIndex = 17;
            this.countryLabel.Text = "Страна";
            // 
            // countryComboBox
            // 
            this.countryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Items.AddRange(new object[] {
            "Выберите страну"});
            this.countryComboBox.Location = new System.Drawing.Point(16, 414);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(121, 24);
            this.countryComboBox.TabIndex = 16;
            // 
            // filterApply
            // 
            this.filterApply.Location = new System.Drawing.Point(16, 450);
            this.filterApply.Name = "filterApply";
            this.filterApply.Size = new System.Drawing.Size(142, 32);
            this.filterApply.TabIndex = 18;
            this.filterApply.Text = "Применить фильтр";
            this.filterApply.UseVisualStyleBackColor = true;
            this.filterApply.Click += new System.EventHandler(this.filterApply_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.libraryToolStripMenuItem,
            this.emoloyeesToolStripMenuItem,
            this.readersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1142, 28);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // libraryToolStripMenuItem
            // 
            this.libraryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.statisticToolStripMenuItem,
            this.giveBookToolStripMenuItem,
            this.myBooksToolStripMenuItem});
            this.libraryToolStripMenuItem.Name = "libraryToolStripMenuItem";
            this.libraryToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.libraryToolStripMenuItem.Text = "Библиотека";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.mainToolStripMenuItem.Text = "Главная";
            // 
            // statisticToolStripMenuItem
            // 
            this.statisticToolStripMenuItem.Name = "statisticToolStripMenuItem";
            this.statisticToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.statisticToolStripMenuItem.Text = "Статистика";
            this.statisticToolStripMenuItem.Click += new System.EventHandler(this.statisticToolStripMenuItem_Click);
            // 
            // giveBookToolStripMenuItem
            // 
            this.giveBookToolStripMenuItem.Name = "giveBookToolStripMenuItem";
            this.giveBookToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.giveBookToolStripMenuItem.Text = "Выдать книгу";
            this.giveBookToolStripMenuItem.Click += new System.EventHandler(this.giveBookToolStripMenuItem_Click);
            // 
            // emoloyeesToolStripMenuItem
            // 
            this.emoloyeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокСотрудниковToolStripMenuItem,
            this.addEmplToolStripMenuItem});
            this.emoloyeesToolStripMenuItem.Name = "emoloyeesToolStripMenuItem";
            this.emoloyeesToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.emoloyeesToolStripMenuItem.Text = "Сотрудники";
            // 
            // списокСотрудниковToolStripMenuItem
            // 
            this.списокСотрудниковToolStripMenuItem.Name = "списокСотрудниковToolStripMenuItem";
            this.списокСотрудниковToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.списокСотрудниковToolStripMenuItem.Text = "Список пользователей";
            this.списокСотрудниковToolStripMenuItem.Click += new System.EventHandler(this.allEmployeesToolStripMenuItem_Click);
            // 
            // addEmplToolStripMenuItem
            // 
            this.addEmplToolStripMenuItem.Name = "addEmplToolStripMenuItem";
            this.addEmplToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.addEmplToolStripMenuItem.Text = "Добавить сотрудника";
            this.addEmplToolStripMenuItem.Click += new System.EventHandler(this.addEmplToolStripMenuItem_Click);
            // 
            // readersToolStripMenuItem
            // 
            this.readersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addReaderToolStripMenuItem});
            this.readersToolStripMenuItem.Name = "readersToolStripMenuItem";
            this.readersToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.readersToolStripMenuItem.Text = "Читатели";
            // 
            // addReaderToolStripMenuItem
            // 
            this.addReaderToolStripMenuItem.Name = "addReaderToolStripMenuItem";
            this.addReaderToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.addReaderToolStripMenuItem.Text = "Добавить читателя";
            this.addReaderToolStripMenuItem.Click += new System.EventHandler(this.addReaderToolStripMenuItem_Click);
            // 
            // myBooksToolStripMenuItem
            // 
            this.myBooksToolStripMenuItem.Name = "myBooksToolStripMenuItem";
            this.myBooksToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.myBooksToolStripMenuItem.Text = "Мои книги";
            this.myBooksToolStripMenuItem.Click += new System.EventHandler(this.myBooksToolStripMenuItem_Click);
            // 
            // main
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1142, 494);
            this.Controls.Add(this.filterApply);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.countryComboBox);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.genresComboBox2);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.authorComboBox);
            this.Controls.Add(this.pageCountTextBox);
            this.Controls.Add(this.pagesCountLabel);
            this.Controls.Add(this.bookDateTextBox);
            this.Controls.Add(this.bookDateLabel);
            this.Controls.Add(this.bookNameTextBox);
            this.Controls.Add(this.bookNameLabel);
            this.Controls.Add(this.smartFilterLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main";
            this.Text = "Главная";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label smartFilterLabel;
        private System.Windows.Forms.Label bookNameLabel;
        private System.Windows.Forms.TextBox bookNameTextBox;
        private System.Windows.Forms.Label bookDateLabel;
        private System.Windows.Forms.TextBox bookDateTextBox;
        private System.Windows.Forms.TextBox pageCountTextBox;
        private System.Windows.Forms.Label pagesCountLabel;
        private System.Windows.Forms.ComboBox authorComboBox;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.ComboBox genresComboBox2;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.Button filterApply;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem libraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emoloyeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEmplToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addReaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giveBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСотрудниковToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn review;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagesCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewTextBoxColumn author;
        private System.Windows.Forms.ToolStripMenuItem myBooksToolStripMenuItem;
    }
}