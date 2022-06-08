using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GUI_for_MS_Access
{
    public partial class FormUDC : Form
    {
        readonly MainForm mainForm;
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Articles&Authors.mdb";
        private readonly OleDbConnection connection;

        public FormUDC(MainForm owner)
        {
            mainForm = owner;

            InitializeComponent();

            connection = new OleDbConnection(connectionString);

            connection.Open();
        }

        private void FormUDC_Load(object sender, EventArgs e)
        {
            UpdateDataBase();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

            int articleID = Convert.ToInt32(textBox1.Text);
            string code = textBox2.Text;

            string query = $"INSERT INTO UDC (Код,Code) VALUES " +
                $"('{articleID}','{code}')";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.ExecuteNonQuery();

            UpdateDataBase();
        }

        private void UpdateDataBase()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Articles_AuthorsDataSet.UDC". При необходимости она может быть перемещена или удалена.
            this.uDCTableAdapter.Fill(this._Articles_AuthorsDataSet.UDC);
        }
        private void FormUDC_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int articleID = Convert.ToInt32(textBox1.Text);

            if (MessageBox.Show($"Вы уверены, что хотите удалить УДК {articleID}?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string query = $"DELETE FROM UDC WHERE Код = {articleID}";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.ExecuteNonQuery();

            MessageBox.Show($"УДК с ID {articleID} удалён");

            UpdateDataBase();
        }
    }
}
