
namespace GUI_for_MS_Access
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOICodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publichingHouseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datePublishedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfPagesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uDCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.citationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articlesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._Articles_AuthorsDataSet = new GUI_for_MS_Access._Articles_AuthorsDataSet();
            this.articles_AuthorsTableAdapter = new GUI_for_MS_Access._Articles_AuthorsDataSetTableAdapters.Articles_AuthorsTableAdapter();
            this.articlesTableAdapter = new GUI_for_MS_Access._Articles_AuthorsDataSetTableAdapters.ArticlesTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.authorsTableAdapter = new GUI_for_MS_Access._Articles_AuthorsDataSetTableAdapters.AuthorsTableAdapter();
            this.textBox_doi_code = new System.Windows.Forms.TextBox();
            this.textBox_publishing_house = new System.Windows.Forms.TextBox();
            this.textBox_date = new System.Windows.Forms.TextBox();
            this.textBox_number_of_pages = new System.Windows.Forms.TextBox();
            this.textBox_udc = new System.Windows.Forms.TextBox();
            this.textBox_citation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.degreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocupationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publishingHouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uDCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.запросыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.найтиПоДатеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.найтиПоАвторуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.найтиПоИздательствуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articlesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Articles_AuthorsDataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 0;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(12, 27);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(120, 23);
            this.UpdateButton.TabIndex = 4;
            this.UpdateButton.Text = "Добавить статью";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(138, 27);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(114, 23);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "Удалить статью";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.dOICodeDataGridViewTextBoxColumn,
            this.publichingHouseDataGridViewTextBoxColumn,
            this.datePublishedDataGridViewTextBoxColumn,
            this.numberOfPagesDataGridViewTextBoxColumn,
            this.uDCDataGridViewTextBoxColumn,
            this.citationDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.articlesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(889, 262);
            this.dataGridView1.TabIndex = 7;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // dOICodeDataGridViewTextBoxColumn
            // 
            this.dOICodeDataGridViewTextBoxColumn.DataPropertyName = "DOI code";
            this.dOICodeDataGridViewTextBoxColumn.HeaderText = "DOI code";
            this.dOICodeDataGridViewTextBoxColumn.Name = "dOICodeDataGridViewTextBoxColumn";
            // 
            // publichingHouseDataGridViewTextBoxColumn
            // 
            this.publichingHouseDataGridViewTextBoxColumn.DataPropertyName = "Publiching house";
            this.publichingHouseDataGridViewTextBoxColumn.HeaderText = "Publiching house";
            this.publichingHouseDataGridViewTextBoxColumn.Name = "publichingHouseDataGridViewTextBoxColumn";
            // 
            // datePublishedDataGridViewTextBoxColumn
            // 
            this.datePublishedDataGridViewTextBoxColumn.DataPropertyName = "Date published";
            this.datePublishedDataGridViewTextBoxColumn.HeaderText = "Date published";
            this.datePublishedDataGridViewTextBoxColumn.Name = "datePublishedDataGridViewTextBoxColumn";
            // 
            // numberOfPagesDataGridViewTextBoxColumn
            // 
            this.numberOfPagesDataGridViewTextBoxColumn.DataPropertyName = "Number of pages";
            this.numberOfPagesDataGridViewTextBoxColumn.HeaderText = "Number of pages";
            this.numberOfPagesDataGridViewTextBoxColumn.Name = "numberOfPagesDataGridViewTextBoxColumn";
            // 
            // uDCDataGridViewTextBoxColumn
            // 
            this.uDCDataGridViewTextBoxColumn.DataPropertyName = "UDC";
            this.uDCDataGridViewTextBoxColumn.HeaderText = "UDC";
            this.uDCDataGridViewTextBoxColumn.Name = "uDCDataGridViewTextBoxColumn";
            // 
            // citationDataGridViewTextBoxColumn
            // 
            this.citationDataGridViewTextBoxColumn.DataPropertyName = "Citation";
            this.citationDataGridViewTextBoxColumn.HeaderText = "Citation";
            this.citationDataGridViewTextBoxColumn.Name = "citationDataGridViewTextBoxColumn";
            // 
            // articlesBindingSource
            // 
            this.articlesBindingSource.DataMember = "Articles";
            this.articlesBindingSource.DataSource = this._Articles_AuthorsDataSet;
            // 
            // _Articles_AuthorsDataSet
            // 
            this._Articles_AuthorsDataSet.DataSetName = "_Articles_AuthorsDataSet";
            this._Articles_AuthorsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // articles_AuthorsTableAdapter
            // 
            this.articles_AuthorsTableAdapter.ClearBeforeFill = true;
            // 
            // articlesTableAdapter
            // 
            this.articlesTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ID статьи";
            // 
            // authorsTableAdapter
            // 
            this.authorsTableAdapter.ClearBeforeFill = true;
            // 
            // textBox_doi_code
            // 
            this.textBox_doi_code.Location = new System.Drawing.Point(13, 127);
            this.textBox_doi_code.Name = "textBox_doi_code";
            this.textBox_doi_code.Size = new System.Drawing.Size(120, 20);
            this.textBox_doi_code.TabIndex = 11;
            // 
            // textBox_publishing_house
            // 
            this.textBox_publishing_house.Location = new System.Drawing.Point(139, 127);
            this.textBox_publishing_house.Name = "textBox_publishing_house";
            this.textBox_publishing_house.Size = new System.Drawing.Size(120, 20);
            this.textBox_publishing_house.TabIndex = 12;
            // 
            // textBox_date
            // 
            this.textBox_date.Location = new System.Drawing.Point(265, 127);
            this.textBox_date.Name = "textBox_date";
            this.textBox_date.Size = new System.Drawing.Size(120, 20);
            this.textBox_date.TabIndex = 13;
            // 
            // textBox_number_of_pages
            // 
            this.textBox_number_of_pages.Location = new System.Drawing.Point(13, 153);
            this.textBox_number_of_pages.Name = "textBox_number_of_pages";
            this.textBox_number_of_pages.Size = new System.Drawing.Size(120, 20);
            this.textBox_number_of_pages.TabIndex = 14;
            // 
            // textBox_udc
            // 
            this.textBox_udc.Location = new System.Drawing.Point(139, 153);
            this.textBox_udc.Name = "textBox_udc";
            this.textBox_udc.Size = new System.Drawing.Size(120, 20);
            this.textBox_udc.TabIndex = 15;
            // 
            // textBox_citation
            // 
            this.textBox_citation.Location = new System.Drawing.Point(265, 153);
            this.textBox_citation.Name = "textBox_citation";
            this.textBox_citation.Size = new System.Drawing.Size(120, 20);
            this.textBox_citation.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "DOI code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Publish";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Number of pages";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(136, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "UDC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(262, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Citation";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицыToolStripMenuItem,
            this.запросыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authorsToolStripMenuItem,
            this.toolStripSeparator1,
            this.degreeToolStripMenuItem,
            this.ocupationToolStripMenuItem,
            this.publishingHouseToolStripMenuItem,
            this.uDCToolStripMenuItem});
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // authorsToolStripMenuItem
            // 
            this.authorsToolStripMenuItem.Name = "authorsToolStripMenuItem";
            this.authorsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.authorsToolStripMenuItem.Text = "Authors";
            this.authorsToolStripMenuItem.Click += new System.EventHandler(this.AuthorsToolStripMenuItem_Click);
            // 
            // degreeToolStripMenuItem
            // 
            this.degreeToolStripMenuItem.Name = "degreeToolStripMenuItem";
            this.degreeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.degreeToolStripMenuItem.Text = "Degree";
            this.degreeToolStripMenuItem.Click += new System.EventHandler(this.DegreeToolStripMenuItem_Click);
            // 
            // ocupationToolStripMenuItem
            // 
            this.ocupationToolStripMenuItem.Name = "ocupationToolStripMenuItem";
            this.ocupationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ocupationToolStripMenuItem.Text = "Ocupation";
            this.ocupationToolStripMenuItem.Click += new System.EventHandler(this.OcupationToolStripMenuItem_Click);
            // 
            // publishingHouseToolStripMenuItem
            // 
            this.publishingHouseToolStripMenuItem.Name = "publishingHouseToolStripMenuItem";
            this.publishingHouseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.publishingHouseToolStripMenuItem.Text = "Publishing house";
            this.publishingHouseToolStripMenuItem.Click += new System.EventHandler(this.PublishingHouseToolStripMenuItem_Click);
            // 
            // uDCToolStripMenuItem
            // 
            this.uDCToolStripMenuItem.Name = "uDCToolStripMenuItem";
            this.uDCToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uDCToolStripMenuItem.Text = "UDC";
            this.uDCToolStripMenuItem.Click += new System.EventHandler(this.UDCToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 463);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Подсказка: для удаления введите только ID";
            // 
            // запросыToolStripMenuItem
            // 
            this.запросыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.найтиПоДатеToolStripMenuItem,
            this.найтиПоАвторуToolStripMenuItem,
            this.найтиПоИздательствуToolStripMenuItem});
            this.запросыToolStripMenuItem.Name = "запросыToolStripMenuItem";
            this.запросыToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.запросыToolStripMenuItem.Text = "Запросы";
            // 
            // найтиПоДатеToolStripMenuItem
            // 
            this.найтиПоДатеToolStripMenuItem.Name = "найтиПоДатеToolStripMenuItem";
            this.найтиПоДатеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.найтиПоДатеToolStripMenuItem.Text = "Найти по дате";
            this.найтиПоДатеToolStripMenuItem.Click += new System.EventHandler(this.найтиПоДатеToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // найтиПоАвторуToolStripMenuItem
            // 
            this.найтиПоАвторуToolStripMenuItem.Name = "найтиПоАвторуToolStripMenuItem";
            this.найтиПоАвторуToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.найтиПоАвторуToolStripMenuItem.Text = "Найти по автору";
            this.найтиПоАвторуToolStripMenuItem.Click += new System.EventHandler(this.найтиПоАвторуToolStripMenuItem_Click);
            // 
            // найтиПоИздательствуToolStripMenuItem
            // 
            this.найтиПоИздательствуToolStripMenuItem.Name = "найтиПоИздательствуToolStripMenuItem";
            this.найтиПоИздательствуToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.найтиПоИздательствуToolStripMenuItem.Text = "Найти по издательству";
            this.найтиПоИздательствуToolStripMenuItem.Click += new System.EventHandler(this.найтиПоИздательствуToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(913, 485);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_citation);
            this.Controls.Add(this.textBox_udc);
            this.Controls.Add(this.textBox_number_of_pages);
            this.Controls.Add(this.textBox_date);
            this.Controls.Add(this.textBox_publishing_house);
            this.Controls.Add(this.textBox_doi_code);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Articles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articlesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Articles_AuthorsDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private _Articles_AuthorsDataSet _Articles_AuthorsDataSet;
        private _Articles_AuthorsDataSetTableAdapters.Articles_AuthorsTableAdapter articles_AuthorsTableAdapter;
        private _Articles_AuthorsDataSetTableAdapters.ArticlesTableAdapter articlesTableAdapter;
        private System.Windows.Forms.Label label1;
        private _Articles_AuthorsDataSetTableAdapters.AuthorsTableAdapter authorsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOICodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn publichingHouseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datePublishedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfPagesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uDCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn citationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource articlesBindingSource;
        private System.Windows.Forms.TextBox textBox_doi_code;
        private System.Windows.Forms.TextBox textBox_publishing_house;
        private System.Windows.Forms.TextBox textBox_date;
        private System.Windows.Forms.TextBox textBox_number_of_pages;
        private System.Windows.Forms.TextBox textBox_udc;
        private System.Windows.Forms.TextBox textBox_citation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem degreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocupationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publishingHouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uDCToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem запросыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem найтиПоДатеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem найтиПоАвторуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem найтиПоИздательствуToolStripMenuItem;
    }
}

