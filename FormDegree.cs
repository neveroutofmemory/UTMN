using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GUI_for_MS_Access
{
    public partial class FormDegree : Form
    {
        readonly MainForm mainForm;

        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Articles&Authors.mdb";
        private readonly OleDbConnection connection;

        public FormDegree(MainForm owner)
        {
            mainForm = owner;

            InitializeComponent();

            connection = new OleDbConnection(connectionString);

            connection.Open();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            int articleID = Convert.ToInt32(textBox1.Text);
            string degree = textBox2.Text;

            string query = $"INSERT INTO Degree (ID,Degree) VALUES " +
                $"('{articleID}','{degree}')";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.ExecuteNonQuery();

            UpdateDataBase();
        }

        private void UpdateDataBase()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Articles_AuthorsDataSet.Degree". При необходимости она может быть перемещена или удалена.
            this.degreeTableAdapter.Fill(this._Articles_AuthorsDataSet.Degree);
        }

        private void FormDegree_Load(object sender, EventArgs e)
        {
            UpdateDataBase();
        }

        private void FormDegree_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int articleID = Convert.ToInt32(textBox1.Text);

            if (MessageBox.Show($"Вы уверены, что хотите удалить научную степень {articleID}?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string query = $"DELETE FROM Degree WHERE ID = {articleID}";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.ExecuteNonQuery();

            MessageBox.Show($"Научная степень с ID {articleID} удалена");

            UpdateDataBase();
        }
    }
}
