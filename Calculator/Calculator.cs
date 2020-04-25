using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        string operation = "";
        double value = 0;
        double valueTemp = 0;
        bool operation_press = false;
        bool number_press = false;
        int count_operationClick = 0;

        //btnNumber
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (number_press == false)
            {
                txtResult.Clear();
            }
            if (operation_press == true)
            {
                txtResult.Clear();
                operation_press = false;
            }

            Button btnNumber = (Button)sender;
            txtResult.Text += btnNumber.Text;
            number_press = true;
        }// end btnNumber

        //Clear E
        private void btnClearE_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            lblValue.Text = "";
            number_press = false;
            value = 0;
            valueTemp = 0;
            count_operationClick = 0;
        }// end Clear E

        //Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            number_press = false;
        }// end Clear

        //Operation Press
        private void btnAdd_Click(object sender, EventArgs e)
        {
            count_operationClick++;
            operation = "+";
            operation_press = true;

            if (count_operationClick == 1)
            {
                value = double.Parse(txtResult.Text);
            }
            else
            {
                value += double.Parse(txtResult.Text);
            }

            lblValue.Text = value.ToString() + " " + operation;
            txtResult.Text = "0";
        }
        private void btnSub_Click(object sender, EventArgs e)
        {
            count_operationClick++;
            operation = "-";
            operation_press = true;
            if (count_operationClick == 1)
            {
                value = double.Parse(txtResult.Text);
            }
            else
            {
                value -= double.Parse(txtResult.Text);
            }

            lblValue.Text = value.ToString() + " " + operation;
            txtResult.Text = "0";
        }
        private void btnMul_Click(object sender, EventArgs e)
        {
            count_operationClick++;
            operation = "*";
            operation_press = true;

            if (count_operationClick == 1)
            {
                value = 1;
                valueTemp = double.Parse(txtResult.Text);
            }
            else
            {
                valueTemp *= double.Parse(txtResult.Text);
            }

            value *= valueTemp;

            lblValue.Text = value.ToString() + " " + operation;
            txtResult.Text = "0";
            if (count_operationClick > 1)
            {
                if (txtResult.Text == "0")
                {
                    valueTemp = 0;
                }
                else
                {
                    valueTemp = double.Parse(txtResult.Text);
                }
            }
        }
        private void btnDiv_Click(object sender, EventArgs e)
        {
            count_operationClick++;
            operation = "/";
            operation_press = true;

            if (count_operationClick == 1)
            {
                value = double.Parse(txtResult.Text);
            }
            else
            {
                value /= double.Parse(txtResult.Text);
            }

            lblValue.Text = value.ToString() + " " + operation;
            txtResult.Text = "0";
        }// end Operation Press

        //Result
        private void btnResult_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    txtResult.Text = (value + double.Parse(txtResult.Text)).ToString();
                    break;
                case "-":
                    txtResult.Text = (value - double.Parse(txtResult.Text)).ToString();
                    break;
                case "*":
                    txtResult.Text = (value * double.Parse(txtResult.Text)).ToString();
                    break;
                case "/":
                    if (txtResult.Text == "0")
                    {
                        MessageBox.Show("Không thể chia một số cho 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtResult.Text = (value / double.Parse(txtResult.Text)).ToString();
                    }
                    break;
            }// end switch         

            lblValue.Text = "";
            operation_press = false;
            number_press = false;
        }// end Result
    }
}