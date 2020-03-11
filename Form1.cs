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
    }
}