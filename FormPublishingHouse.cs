using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GUI_for_MS_Access
{
    public partial class FormPublishingHouse : Form
    {
        readonly MainForm mainForm;
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Articles&Authors.mdb";
        private readonly OleDbConnection connection;

        public FormPublishingHouse(MainForm owner)
        {
            mainForm = owner;

            InitializeComponent();

            connection = new OleDbConnection(connectionString);

            connection.Open();
        }

        private void FormPublishingHouse_Load(object sender, EventArgs e)
        {
            UpdateDataBase();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

            int articleID = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;

            string query = $"INSERT INTO [Publishing house] (Код,[Name of publishing house]) VALUES " +
                $"('{articleID}','{name}')";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.ExecuteNonQuery();

            UpdateDataBase();
        }

        private void UpdateDataBase()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Articles_AuthorsDataSet.Publishing_house". При необходимости она может быть перемещена или удалена.
            this.publishing_houseTableAdapter.Fill(this._Articles_AuthorsDataSet.Publishing_house);
        }

        private void FormPublishingHouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int articleID = Convert.ToInt32(textBox1.Text);

            if (MessageBox.Show($"Вы уверены, что хотите удалить издательство {articleID}?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string query = $"DELETE FROM [Publishing house] WHERE Код = {articleID}";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.ExecuteNonQuery();

            MessageBox.Show($"Издательство с ID {articleID} удалено");

            UpdateDataBase();
        }
    }
}
