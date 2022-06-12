using System;
using System.Windows.Forms;

namespace Lesiv_Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox2.Text == "")
            {
                label6.Visible = true;
            }
            if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                label9.Visible = true;
            }
            else
            { 
                label6.Visible = false;
                label9.Visible = false;

                double
                    a = Convert.ToDouble(textBox1.Text),
                    b = Convert.ToDouble(textBox2.Text),
                    c = Convert.ToDouble(textBox3.Text),
                    start = Convert.ToDouble(textBox5.Text),
                    end = Convert.ToDouble(textBox6.Text),
                    step = Convert.ToDouble(textBox4.Text);

                createGraphic(a, b, c, start, end, step);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label4.Visible = false;
                textBox3.Visible = false;
            }
            else
            {
                label4.Visible = true;
                textBox3.Visible = true;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                label4.Visible = false;
                textBox3.Visible = false;
            }
            else
            {
                label4.Visible = true;
                textBox3.Visible = true;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                label4.Visible = false;
                textBox3.Visible = false;
            }
            else
            {
                label4.Visible = true;
                textBox3.Visible = true;
            }
        }
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                label4.Visible = false;
                textBox3.Visible = false;
            }
            else
            {
                label4.Visible = true;
                textBox3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox2.Text == "")
            {
                label6.Visible = true;
            }
            if (textBox8.Text == "")
            {
                label11.Visible = true;
            }
            else
            {
                label6.Visible = false;
                label11.Visible = false;
                double
                    y,
                    a = Convert.ToDouble(textBox1.Text),
                    b = Convert.ToDouble(textBox2.Text),
                    c = Convert.ToDouble(textBox3.Text),
                    X = Convert.ToDouble(textBox8.Text);

                if (radioButton1.Checked)
                {
                    y = X * a + b;
                    chart.Series[8].Points.AddXY(X, y);
                }
                else if (radioButton2.Checked)
                {
                    y = a * Math.Sin(X * b) + c;
                    chart.Series[8].Points.AddXY(X, y);
                }
                else if (radioButton3.Checked)
                {
                    y = a * Math.Cos(X * b + c);
                    chart.Series[8].Points.AddXY(X, y);
                }
                else if (radioButton4.Checked)
                {
                    y = a * Math.Tan(X * b) + c;
                    chart.Series[8].Points.AddXY(X, y);
                }
                else if (radioButton5.Checked)
                {
                    y = a * (1.0 /Math.Tan(X * b + c));
                    chart.Series[8].Points.AddXY(X, y);
                }
                else if (radioButton6.Checked)
                {
                    y = b * Math.Pow(X, a);
                    chart.Series[8].Points.AddXY(X, y);
                }
                else if (radioButton7.Checked)
                {
                    y = Math.Pow(a, (X + b));
                    chart.Series[8].Points.AddXY(X, y);
                }
                else if (radioButton8.Checked)
                {
                    y = Math.Pow(((Math.Sin(X) + a * X) / ((X - Math.Pow(X, 1 / 2)) + 1)), b / X);
                    chart.Series[8].Points.AddXY(X, y);
                }
            }
            
        }

        private void createGraphic(double a, double b, double c, double start, double end, double step)
        {
            double x, y;

            for (int i = 0; i < 9; i++)
            {
                this.chart.Series[i].Points.Clear();
            }

            x = start;

            while (x <= end)
            {
                if (radioButton1.Checked)
                {
                    y = x * a + b;
                    chart.Series[0].Points.AddXY(x, y);
                }
                else if (radioButton2.Checked)
                {
                    y = a * Math.Sin(x * b) + c;
                    chart.Series[1].Points.AddXY(x, y);
                }
                else if (radioButton3.Checked)
                {
                    y = a * Math.Cos(x * b + c);
                    chart.Series[2].Points.AddXY(x, y);
                }
                else if (radioButton4.Checked)
                {
                    y = a * Math.Tan(x * b) + c;
                    chart.Series[3].Points.AddXY(x, y);
                }
                else if (radioButton5.Checked)
                {
                    y = a * (1.0 / Math.Tan(x * b + c));
                    chart.Series[4].Points.AddXY(x, y);
                }
                else if (radioButton6.Checked)
                {
                    y = b * Math.Pow(x, a);
                    chart.Series[5].Points.AddXY(x, y);
                }
                else if (radioButton7.Checked)
                {
                    y = Math.Pow(a, (x + b));
                    chart.Series[6].Points.AddXY(x, y);
                }
                else if (radioButton8.Checked)
                {
                    y = Math.Pow(((Math.Sin(x) + a * x) / ((x - Math.Pow(x, 1 / 2)) + 1)), b / x);
                    chart.Series[7].Points.AddXY(x, y);
                }
                x += step;
            }
        }
    }
}
