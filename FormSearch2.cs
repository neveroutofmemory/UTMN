using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GUI_for_MS_Access
{
    public partial class FormSearch2 : Form
    {
        MainForm mainForm;
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Articles&Authors.mdb";
        private readonly OleDbConnection connection;
        public FormSearch2(MainForm owner)
        {
            mainForm = owner;

            InitializeComponent();

            connection = new OleDbConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string query = "SELECT ID, [Full name], Citation, Occupation, Degree, Birthday FROM Authors " +
                $"WHERE [Full name] LIKE '{name}'";

            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        private void FormSearch2_Load(object sender, EventArgs e)
        {
            connection.Open();
        }

        private void FormSearch2_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
    }
}
