using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        double value = 0;
        string operation = string.Empty;
        bool operation_pressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (Result.Text == "0" && button.Text != "," || operation_pressed)
                Result.Clear();

            operation_pressed = false;

            if (Result.Text.Contains(",") && button.Text == ",")
                return;

            Result.Text += button.Text;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Result.Text = "0";
        }

        private void Clear_All_Click(object sender, EventArgs e)
        {
            operation = string.Empty;
            value = 0;
            operation_pressed = false;
            equation.Text = string.Empty;
            Result.Text = "0";
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            operation = button.Text;
            value = double.Parse(Result.Text);
            operation_pressed = true;
            equation.Text = value + " " + operation;
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            equation.Text = string.Empty;
            switch (operation)
            {
                case "+":
                    Result.Text = (value + double.Parse(Result.Text)).ToString();
                    break;
                case "-":
                    Result.Text = (value - double.Parse(Result.Text)).ToString();
                    break;
                case "/":
                    Result.Text = (value / double.Parse(Result.Text)).ToString();
                    break;
                case "*":
                    Result.Text = (value * double.Parse(Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            operation_pressed = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            if (AtextBox.Focused || BtextBox.Focused || CtextBox.Focused)
                return;
            if (key == Keys.NumPad0 || key == Keys.D0)
                button10.PerformClick();
            else if (key == Keys.NumPad1 || key == Keys.D1)
                button7.PerformClick();
            else if (key == Keys.NumPad2 || key == Keys.D2)
                button8.PerformClick();
            else if (key == Keys.NumPad3 || key == Keys.D3)
                button9.PerformClick();
            else if (key == Keys.NumPad4 || key == Keys.D4)
                button4.PerformClick();
            else if (key == Keys.NumPad5 || key == Keys.D5)
                button5.PerformClick();
            else if (key == Keys.NumPad6 || key == Keys.D6)
                button6.PerformClick();
            else if (key == Keys.NumPad7 || key == Keys.D7)
                button1.PerformClick();
            else if (key == Keys.NumPad8 || key == Keys.D8)
                button2.PerformClick();
            else if (key == Keys.NumPad9 || key == Keys.D9)
                button3.PerformClick();
            else if (key == Keys.Divide)
                button11.PerformClick();
            else if (key == Keys.Multiply)
                button12.PerformClick();
            else if (key == Keys.Subtract)
                button14.PerformClick();
            else if (key == Keys.Add)
                button15.PerformClick();
            else if (key == Keys.Decimal)
                button13.PerformClick();
            else if (key == Keys.Escape)
                button17.PerformClick();
            else if (key == Keys.Back)
                button18.PerformClick();
            else if (key == Keys.Enter)
                button16.PerformClick();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            var textBox = sender as TextBox;
            var validateExpression = new Regex(@"^\d\d*\,?\d*$");
            if (!validateExpression.IsMatch(textBox.Text))
            {
                e.Cancel = true;
                AtextBox.Focus();
                errorProvider1.SetError(textBox, "Invalid number!");
                Calculate_Button.Enabled = false;
            }
            else
            {
                Calculate_Button.Enabled = true;
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }
        }

        private void Calculate(object sender, EventArgs e)
        {
            var a = double.Parse(AtextBox.Text);
            var b = double.Parse(BtextBox.Text);
            var c = double.Parse(CtextBox.Text);
            var perimeter = (a + b + c) / 2;
            var square = Math.Sqrt(perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c));
            Perimeter.Text = $"p = {perimeter}";
            Square.Text = $"S = {square}";
        }
    }
}
