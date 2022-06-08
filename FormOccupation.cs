using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GUI_for_MS_Access
{
    public partial class FormOccupation : Form
    {
        readonly MainForm mainForm;

        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Articles&Authors.mdb";
        private readonly OleDbConnection connection;

        public FormOccupation(MainForm owner)
        {
            mainForm = owner;

            InitializeComponent();

            connection = new OleDbConnection(connectionString);

            connection.Open();
        }

        private void FormOccupation_Load(object sender, EventArgs e)
        {
            UpdateDataBase();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

            int articleID = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            string address = textBox3.Text;
            string director = textBox4.Text;

            string query = $"INSERT INTO Occupation (ID,[Name of company],[Main adress],Director) VALUES " +
                $"('{articleID}','{name}','{address}','{director}')";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.ExecuteNonQuery();

            UpdateDataBase();
        }

        private void UpdateDataBase()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Articles_AuthorsDataSet.Occupation". При необходимости она может быть перемещена или удалена.
            this.occupationTableAdapter.Fill(this._Articles_AuthorsDataSet.Occupation);
        }

        private void FormOccupation_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int articleID = Convert.ToInt32(textBox1.Text);

            if (MessageBox.Show($"Вы уверены, что хотите удалить занятость {articleID}?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string query = $"DELETE FROM Occupation WHERE ID = {articleID}";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.ExecuteNonQuery();

            MessageBox.Show($"Занятость с ID {articleID} удалена");

            UpdateDataBase();
        }
    }
}
