///Author:Kris, Noah, David
// date 04/13/2020
// objective: Sprint 2
//API used: alphavantage
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

        public double total;

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
                //We need a running total in order to keep track of each value of the stock.
                total += answer;
                textBox2.Text = textBox3.Text + " shares of " + s.Name + " at price of " + s.Price + " is equal to " + answer + Environment.NewLine + "Total is: " + total;
                

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

        //This button will save to text file, showing a "history" of previous portfolio values in a way that makes sense to the user
        private void button2_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(textBox2.Text + Environment.NewLine + "FILE CREATED SUCCESSFULLY", "Total Box");
            string messageDate = (DateTime.Now.ToString("F"));

            string path = Environment.CurrentDirectory + "/" + "History.txt";

            List<string> lines = File.ReadAllLines(path).ToList();
            lines.Add("---------");
            lines.Add(textBox2.Text);
            lines.Add(messageDate);
            File.ReadAllLines(path);

            //We only want one statement for if the file doesn't already exist in the directory
            if (!File.Exists(path))
            {
                File.CreateText(path);

            }

            //We want whatever text that we collected from 'saving' our data in the app
            File.WriteAllLines(path, lines);
            Console.ReadLine();
            
        }

        //We want to create a clear button that erases everything, including the running total so that
        //the user does not have to backspace everything. Plus, the result box is read only.
        private void button3_Click(object sender, EventArgs e)
        {
            total = 0;
            textBox1.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + "/" + "History.txt";
            Process.Start("notepad.exe", path);
        }
    }
}
