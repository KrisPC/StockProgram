//Author:Kris, Noah, David
// date 03/11/2020
// objective: proof of concept 
//API used alphavatage
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace StockProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string input = textBox1.Text;
                string input2 = textBox3.Text;
                double inputDouble = Convert.ToDouble(input2);
                Stock s = await Program.RunASync(input);
                double answer = (s.Price * inputDouble);
                textBox4.Text = input2 + " shares of " + s.Name + " is equal to: " + Environment.NewLine + answer.ToString();
            }
            catch
            {
                textBox4.Text = "ERROR, check input!";
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}