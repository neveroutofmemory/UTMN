using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GUI_for_MS_Access
{
    public partial class FormAuthors : Form
    {
        readonly MainForm mainForm;

        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Articles&Authors.mdb";
        private readonly OleDbConnection connection;
        public FormAuthors(MainForm owner)
        {
            mainForm = owner;

            InitializeComponent();

            connection = new OleDbConnection(connectionString);

            connection.Open();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            int articleID = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            int сitation = Convert.ToInt32(textBox3.Text);
            string occupation = textBox4.Text;
            string degree = textBox5.Text;
            string birthday = textBox6.Text;

            string query = $"INSERT INTO Authors (ID,[Full name],Citation,Occupation,Degree,Birthday) VALUES " +
                $"('{articleID}','{name}','{сitation}','{occupation}','{degree}','{birthday}')";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.ExecuteNonQuery();

            UpdateDataBase();
        }

        private void UpdateDataBase()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Articles_AuthorsDataSet.Authors". При необходимости она может быть перемещена или удалена.
            this.authorsTableAdapter.Fill(this._Articles_AuthorsDataSet.Authors);
        }

        private void FormAuthors_Load(object sender, EventArgs e)
        {
            UpdateDataBase();
        }

        private void FormAuthors_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int articleID = Convert.ToInt32(textBox1.Text);

            if (MessageBox.Show($"Вы уверены, что хотите удалить автора {articleID}?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string query = $"DELETE FROM Authors WHERE ID = {articleID}";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.ExecuteNonQuery();

            MessageBox.Show($"Автор с ID {articleID} удалён");

            UpdateDataBase();
        }
    }
}
