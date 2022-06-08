using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GUI_for_MS_Access
{
    public partial class FormSearch3 : Form
    {
        MainForm mainForm;
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Articles&Authors.mdb";
        private readonly OleDbConnection connection;

        public FormSearch3(MainForm owner)
        {
            mainForm = owner;

            InitializeComponent();

            connection = new OleDbConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string query = "SELECT Код, [Name of publishing house] FROM [Publishing house] " +
                $"WHERE [Name of publishing house] LIKE '{name}'";

            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        private void FormSearch3_Load(object sender, EventArgs e)
        {
            connection.Open();
        }

        private void FormSearch3_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
    }
}
