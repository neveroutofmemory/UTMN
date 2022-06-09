using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class MenuForm : Form
    {
        readonly MainForm mainForm;

        public MenuForm(MainForm owner)
        {
            mainForm = owner;

            InitializeComponent();
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            bool isExitFormNow = true;

            // Изменяет свойство MainForm'ы "GameOpponent"
            if (radioButton1.Checked)
            {
                mainForm.GameOpponent = MainForm.Opponent.Person;
            }
            else if (radioButton2.Checked)
            {
                mainForm.GameOpponent = MainForm.Opponent.Computer;
            }
            else
            {
                await RedFlashing(groupBox1);
                isExitFormNow = false;
            }

            // Изменяет свойство MainForm'ы "StarterSign"
            if (radioButton3.Checked)
            {
                mainForm.StarterSign = MainForm.Sign.Cross;
            }
            else if (radioButton4.Checked)
            {
                mainForm.StarterSign = MainForm.Sign.Circle;
            }
            else
            {
                await RedFlashing(groupBox2);
                isExitFormNow = false;
            }

            if (isExitFormNow)
            {
                mainForm.Enabled = true;

                mainForm.Activate();

                this.Close();
            }
        }

        async Task RedFlashing(GroupBox groupBox)
        {
            for (int t = 0; t < 5; t++)
            {
                groupBox.ForeColor = Color.Red;
                await Task.Delay(50);
                groupBox.ForeColor = Color.White;
                await Task.Delay(50);
            }
        }
    }
}
