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
//take in a stock(s) and using the API find the stock and its
// current value display this to the screen.
            string input = textBox1.Text;
            Stock s = await Program.RunASync(input);
            textBox2.Text = "Name of stock: " + s.Name + Environment.NewLine + "Price of Stock: " + s.Price;
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
