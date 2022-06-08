using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GUI_for_MS_Access
{
    public partial class MainForm : Form
    {
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Articles&Authors.mdb";
        private readonly OleDbConnection connection;

        string doi_code;
        int pub_house;
        string date_pub;
        int num_pages;
        string udc;
        int citation;

        public MainForm()
        {
            InitializeComponent();

            connection = new OleDbConnection(connectionString);

            connection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateDataBase();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int articleID = Convert.ToInt32(textBox1.Text);

            if (MessageBox.Show($"Вы уверены, что хотите удалить статью {articleID}?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string query = $"DELETE FROM Articles WHERE ID = {articleID}";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.ExecuteNonQuery();

            MessageBox.Show($"Статья с ID {articleID} удалена");

            UpdateDataBase();
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            int articleID = Convert.ToInt32(textBox1.Text);
            doi_code = textBox_doi_code.Text;
            pub_house = Convert.ToInt32(textBox_publishing_house.Text);
            date_pub = textBox_date.Text;
            num_pages = Convert.ToInt32(textBox_number_of_pages.Text);
            udc = textBox_udc.Text;
            citation = Convert.ToInt32(textBox_citation.Text);

            string query = $"INSERT INTO Articles (ID,[DOI code],[Publiching house],[Date published],[Number of pages],UDC,Citation) VALUES " +
                $"('{articleID}','{doi_code}','{pub_house}','{date_pub}','{num_pages}','{udc}','{citation}')";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.ExecuteNonQuery();

            UpdateDataBase();
        }

        private void UpdateDataBase()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Articles_AuthorsDataSet.Articles". При необходимости она может быть перемещена или удалена.
            this.articlesTableAdapter.Fill(this._Articles_AuthorsDataSet.Articles);
        }

        private void AuthorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAuthors(this).Show();
        }

        private void DegreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormDegree(this).Show();
        }

        private void OcupationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormOccupation(this).Show();
        }

        private void PublishingHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormPublishingHouse(this).Show();
        }

        private void UDCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormUDC(this).Show();
        }

        private void найтиПоДатеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormSearch1(this).Show();
        }

        private void найтиПоАвторуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormSearch2(this).Show();
        }

        private void найтиПоИздательствуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormSearch3(this).Show();
        }
    }
}
