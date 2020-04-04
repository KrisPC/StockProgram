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
            this.ActiveControl = textBox1;
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //take in a stock(s) and using the API find the stock and its
                // current value display this to the screen. 
                string input = textBox1.Text;
                string input2 = textBox3.Text;
                double inputDouble = Convert.ToDouble(input2);
                Stock s = await Program.RunASync(input);
                double answer = (s.Price * inputDouble);
                textBox2.Text = textBox3.Text + " shares of " + s.Name + " at price of " + s.Price + " is equal to " + answer;
            }
            catch
            {
                textBox2.Text = "ERROR, CHECK INPUT BOXES";

            }
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
