using System;
using System.Windows.Forms;

namespace calculator1
{
    public partial class Form1 : Form
    {
        double resultValue = 0;
        string operatiomPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox_Result_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            if (TextBox_Result.Text == "0" || (isOperationPerformed))
            {
                TextBox_Result.Clear();
            }
            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!TextBox_Result.Text.Contains("."))
                {
                    TextBox_Result.Text = TextBox_Result.Text + button.Text;
                }
            }
            else
            {
                TextBox_Result.Text = TextBox_Result.Text + button.Text;
            }
        }

        private void opperator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(resultValue != 0)
            {
                buttonEquals.PerformClick();
                operatiomPerformed = button.Text;
                lableCurrentOperation.Text = resultValue + " " + operatiomPerformed;
                isOperationPerformed = true;
            }         
            else
            {
                operatiomPerformed += button.Text;
                resultValue = double.Parse(TextBox_Result.Text);
                lableCurrentOperation.Text = resultValue + " " + operatiomPerformed;
                isOperationPerformed = true;
            }
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            TextBox_Result.Text = "0";

        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            TextBox_Result.Text = "0";
            resultValue = 0;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            switch (operatiomPerformed)
            {
                case "+":
                    TextBox_Result.Text = (resultValue + Double.Parse(TextBox_Result.Text)).ToString();
                    break;
                case "-":
                    TextBox_Result.Text = (resultValue - Double.Parse(TextBox_Result.Text)).ToString();
                    break;
                case "*":
                    TextBox_Result.Text = (resultValue * Double.Parse(TextBox_Result.Text)).ToString();
                    break;
                case "/":
                    TextBox_Result.Text = (resultValue / Double.Parse(TextBox_Result.Text)).ToString();
                    break;
                case "-/+":
                    resultValue *= -1;
                    TextBox_Result.Text = (resultValue + Double.Parse(TextBox_Result.Text)).ToString();               
                    break;
                default:
                    break;
            }
            resultValue = double.Parse(TextBox_Result.Text);
            lableCurrentOperation.Text = "";
        }
    }
}