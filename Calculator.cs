using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalcFunctions;

namespace Calculator_Refactor
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        // Retain a running total that's parsed from the display text
        private double firstNumber = 0;
        // Store the current operation to perform when equals is pressed
        string operation = "";

        private void calcDisplay_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            // This method is used to handle the click event for all number buttons
            // It appends the button's text to the calculator display
            Button btn = sender as Button;
            if (btn != null)
            {
                calcDisplay.Text += btn.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Button 1
            numberButton_Click(sender, e);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Button 2
            numberButton_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Button 3
            numberButton_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Button 4
            numberButton_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Button 5
            numberButton_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Button 6
            numberButton_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Button 7
            numberButton_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Button 8
            numberButton_Click(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Button 9
            numberButton_Click(sender, e);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            // Button 0
            numberButton_Click(sender, e);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // This clears the display
            calcDisplay.Text = "";
            // Reset the running total and stored operation
            firstNumber = 0;
            operation = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // This is the Delete back button
            // If the display text isn't empty, remove the last character
            if (calcDisplay.Text.Length > 0)
            {
                // Reassign the substring to the display text
                calcDisplay.Text = calcDisplay.Text.Substring(0, calcDisplay.Text.Length - 1);
            }
        }

        private void buttonPI_Click(object sender, EventArgs e)
        {
            // This is the PI constant button
            if (calcDisplay.Text.Length == 0)
            {
                // If the display is empty, set it to PI
                calcDisplay.Text = Math.PI.ToString().Substring(0, 16);
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            // Decimal point button
            // Ensure that there is only one decimal point in the display
            if (!calcDisplay.Text.Contains("."))
            {
                // If the display evaluates to null/empty, start with "0", otherwise append "."
                calcDisplay.Text = string.IsNullOrEmpty(calcDisplay.Text) ? "0." : calcDisplay.Text + ".";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // This is the addition button
            if (calcDisplay.Text.Length > 0)
            {
                // If there is already an operation set, perform the calculation first before proceeding to the next operation
                if (operation.Length > 0)
                {
                    buttonEquals_Click(sender, e);
                }
                // Try to parse the first number from the display text
                if (double.TryParse(calcDisplay.Text, out firstNumber))
                {
                    // Successfully parsed the number
                    operation = "+";
                    // Clear the display for the next input
                    calcDisplay.Text = "";
                }
            }
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            // This is the subtraction button
            if (calcDisplay.Text.Length > 0)
            {
                // If there is already an operation set, perform the calculation first before proceeding to the next operation
                if (operation.Length > 0)
                {
                    buttonEquals_Click(sender, e);
                }
                // Try to parse the first number from the display text
                if (double.TryParse(calcDisplay.Text, out firstNumber))
                {
                    // Successfully parsed the number
                    operation = "-";
                    // Clear the display for the next input
                    calcDisplay.Text = ""; 
                }
            }
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            // This is the multiplication button
            if (calcDisplay.Text.Length > 0)
            {
                // If there is already an operation set, perform the calculation first before proceeding to the next operation
                if (operation.Length > 0)
                {
                    buttonEquals_Click(sender, e);
                }
                // Try to parse the first number from the display text
                if (double.TryParse(calcDisplay.Text, out firstNumber))
                {
                    // Successfully parsed the number
                    operation = "*";
                    // Clear the display for the next input
                    calcDisplay.Text = "";
                }
            }
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            // This is the division button
            if (calcDisplay.Text.Length > 0)
            {
                // If there is already an operation set, perform the calculation first before proceeding to the next operation
                if (operation.Length > 0)
                {
                    buttonEquals_Click(sender, e);
                }
                // Try to parse the first number from the display text
                if (double.TryParse(calcDisplay.Text, out firstNumber))
                {
                    // Successfully parsed the number
                    operation = "/";
                    // Clear the display for the next input
                    calcDisplay.Text = "";
                }
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            // This is the equals button
            double secondNumber;
            if (calcDisplay.Text.Length == 0 || operation == "")
            {
                // If the display is empty, do nothing
                return;
            }
            else if (double.TryParse(calcDisplay.Text, out secondNumber))
            {
                double result = 0;
                MathFunctions obj_mathFunctions = new MathFunctions();

                if (operation == "+")
                {
                    // Perform addition
                    result = obj_mathFunctions.Add(firstNumber, secondNumber);
                }
                else if (operation == "-")
                {
                    // Perform subtraction
                    result = obj_mathFunctions.Subtract(firstNumber, secondNumber);
                }
                else if (operation == "*")
                {
                    // Perform mulitplication
                    result = obj_mathFunctions.Multiply(firstNumber, secondNumber);
                }
                else if (operation == "/")
                {
                    // Perform division
                    result = obj_mathFunctions.Divide(firstNumber, secondNumber);
                }
                // Update firstNumber for potential further calculations
                firstNumber = result;
                // Display the result
                calcDisplay.Text = result.ToString();
                // Reset the operation after calculation to handle additional operations
                operation = ""; 
            }
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            // This is the percentage button
            if (calcDisplay.Text.Length > 0)
            {
                // Try to parse the first number from the display text
                if (double.TryParse(calcDisplay.Text, out firstNumber))
                {
                    // Successfully parsed the number
                    // Convert to percentage
                    firstNumber /= 100;
                    // Display the percentage value
                    calcDisplay.Text = firstNumber.ToString();
                }
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripThemeMenu_Click(object sender, EventArgs e)
        {

        }

        private void toolStripThemeLight_Click(object sender, EventArgs e)
        {
            if (toolStripThemeLight.Checked == false)
            {
                // If light theme is unchecked, switch to light theme
                toolStripThemeLight.Checked = true;
                toolStripThemeDark.Checked = false;
                // Apply Light theme
                // ...to the outer form area
                Calculator.ActiveForm.BackColor = Color.WhiteSmoke;
                // ...to the group box area
                groupBox1.BackColor = Color.LightGray;
                groupBox1.ForeColor = Color.Black;
                // ...to the calculator display area
                calcDisplay.BackColor = Color.White;
                calcDisplay.ForeColor = Color.Black;

                // ...to each button within the group box
                foreach (Control control in groupBox1.Controls)
                {
                    if (control is Button button)
                    {
                        // Set the background and text color for each button
                        button.BackColor = Color.WhiteSmoke;
                        button.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void toolStripThemeDark_Click(object sender, EventArgs e)
        {
            if (toolStripThemeDark.Checked == false)
            {
                // If dark theme is unchecked, switch to dark theme
                toolStripThemeLight.Checked = false;
                toolStripThemeDark.Checked = true;
                // Apply Dark theme
                // ...to the outer form area
                Calculator.ActiveForm.BackColor = Color.DimGray;
                // ...to the group box area
                groupBox1.BackColor = Color.Black;
                groupBox1.ForeColor = Color.LightGray;
                // ...to the calculator display area
                calcDisplay.BackColor = Color.DimGray;
                calcDisplay.ForeColor = Color.White;

                // ...to each button within the group box
                foreach (Control control in groupBox1.Controls)
                {
                    if (control is Button button)
                    {
                        // Set the background and text color for each button
                        button.BackColor = Color.DarkGray;
                        button.ForeColor = Color.White;
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }
    }
}
