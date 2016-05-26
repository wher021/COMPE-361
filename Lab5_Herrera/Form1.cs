using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Complex operand1=new Complex();
        Complex operand2 = new Complex();
        string Operator;
        int chaining;
        List<Complex> list = new List<Complex>();
        Object sender;////store global variable sender!!!

        public Form1()
        {
            InitializeComponent();
        }

        private void number_Click(object sender, EventArgs e)
        {
            if (this.sender == realBox.Text)
                realBox.Text += ((Button)sender).Text;
            else if (this.sender == imagBox)
                imagBox.Text += ((Button)sender).Text;
            //if (sender == button1 && this.sender == realBox)
            //    realBox.Text += 1;
            //else if (sender == button1 && this.sender == imagBox)
            //    imagBox.Text += 1;
            //if (sender == button2 && this.sender == realBox)
            //    realBox.Text += 2;
            //else if (sender == button2 && this.sender == imagBox)
            //    imagBox.Text += 2;
            //if (sender == button3 && this.sender == realBox)
            //    realBox.Text += 3;
            //else if (sender == button3 && this.sender == imagBox)
            //    imagBox.Text += 3;
            //if (sender == button4 && this.sender == realBox)
            //    realBox.Text += 4;
            //else if (sender == button4 && this.sender == imagBox)
            //    imagBox.Text += 4;
            //if (sender == button5 && this.sender == realBox)
            //    realBox.Text += 5;
            //else if (sender == button5 && this.sender == imagBox)
            //    imagBox.Text += 5;
            //if (sender == button6 && this.sender == realBox)
            //    realBox.Text += 6;
            //else if (sender == button6 && this.sender == imagBox)
            //    imagBox.Text += 6;
            //if (sender == button7 && this.sender == realBox)
            //    realBox.Text += 7;
            //else if (sender == button7 && this.sender == imagBox)
            //    imagBox.Text += 7;
            //if (sender == button8 && this.sender == realBox)
            //    realBox.Text += 8;
            //else if (sender == button8 && this.sender == imagBox)
            //    imagBox.Text += 8;
            //if (sender == button9 && this.sender == realBox)
            //    realBox.Text += 9;
            //else if (sender == button9 && this.sender == imagBox)
            //    imagBox.Text += 9;

        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            try
            {
                GetOperand2();
                Calculate();
            }
            catch
            {
                MessageBox.Show("missing operand");
            }        

        }

        private void Calculate()
        {

                if (Operator == "+")
                {
                    operand1 = operand1 + operand2;
                    sumBox.Text = operand1.ToString();
                }
                else if (Operator == "-")
                {
                    operand1 = operand1 - operand2;
                    sumBox.Text = operand1.ToString();
                }
                if (Operator == "*")
                {
                    operand1 = operand1 * operand2;
                    sumBox.Text = operand1.ToString();
                }
                if (Operator == "/")
                {
                    operand1 = operand1 / operand2;
                    sumBox.Text = operand1.ToString();

                }
                chainBox.Text = "";
                ClearBox();
            
        }

        private void GetOperand2()
        {
            if (Complex.mode == MODE.Rectangular)
            {
                operand2.Real = double.Parse(realBox.Text);
                operand2.Imag = double.Parse(imagBox.Text);
            }
            else if (Complex.mode == MODE.Polar)
            {
                operand2.Magnitude = double.Parse(realBox.Text);
                operand2.Angle = double.Parse(imagBox.Text);
            }
        }

        private void arithmeticButton_Click(object sender, EventArgs e)
        {
            if(sender==addButton)
            Operator = "+";
            else if(sender==subButton)
            Operator = "-";
            else if (sender == multiButton)
                Operator = "*";
            else if (sender == divButton)
                Operator = "/";
            try
            {
                GetOperand1();
            }
            catch
            {
                MessageBox.Show("missing operand");
            }
           
        }

        private void GetOperand1()
        {
            if (chaining == 0)
            {
                if (Complex.mode == MODE.Rectangular)
                {
                    operand1.Real = double.Parse(realBox.Text);
                    operand1.Imag = double.Parse(imagBox.Text);
                }
                else if (Complex.mode == MODE.Polar)
                {
                    operand1.Magnitude = double.Parse(realBox.Text);
                    operand1.Angle = double.Parse(imagBox.Text);
                }
                chainBox.Text = operand1.ToString() + Operator;//chaining record
                chaining = 1;
            }
            else if (chaining == 1)
            {
                chainBox.Text = operand1.ToString() + Operator;
            }
            ClearBox();
        }

        public void ClearBox()
        {
             realBox.Text = "";
             imagBox.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            modeBox.SelectedIndex = 0;
            MessageBox.Show("please read instructions from the menu before using, you start in rectangular mode");
        }

        private void realBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.sender = sender;
        }

        private void imagBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.sender = sender;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearBox();
            sumBox.Text = "";
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            chaining = 0;
            ClearBox();
            sumBox.Text = "";
            chainBox.Text = "";
            memoryBox.Items.Clear();
        }

        private void memoryButton_Click(object sender, EventArgs e)
        {
            AddMemoryElement();
        }

        private void AddMemoryElement()
        {
            Complex temp = new Complex();
            temp = operand1;
            //list.Add(temp);
            memoryBox.Items.Add(temp);
        }

        private void modeBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (modeBox.SelectedItem.Equals("Rectangular"))
            {
                Complex.mode = MODE.Rectangular;
                label1.Text = "Real";
                label2.Text = "Imaginary";
                sumBox.Text = operand1.ToString();
                chainBox.Text = operand1.ToString() + Operator;
            }
            else if (modeBox.SelectedItem.Equals("Polar"))
            {
                Complex.mode = MODE.Polar;
                label1.Text = "Magnitude";
                label2.Text = "Angle";
                sumBox.Text = operand1.ToString();
                chainBox.Text = operand1.ToString() + Operator;
            }
        }

        private void memoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Complex temp2 = new Complex();///CHHHHHHHHHHHHHHHHEch THIS
            temp2 = (Complex)memoryBox.SelectedItem;

            if (Complex.mode == MODE.Rectangular)
            {
                realBox.Text = temp2.Real.ToString();
                imagBox.Text = temp2.Imag.ToString();

            }
            else if (Complex.mode == MODE.Polar)
            {
                realBox.Text = temp2.Magnitude.ToString();
                imagBox.Text = temp2.Angle.ToString();
            }
        }

        private void myKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Multiply)
            {
                Operator = "*";
                GetOperand1();
                realBox.Focus();
            }    
            else if (e.KeyCode == Keys.Add)
            {
                Operator = "+";
                GetOperand1();
                realBox.Focus();
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                Operator = "-";
                GetOperand1();
                realBox.Focus();
            }
            else if (e.KeyCode == Keys.Divide)
            {
                Operator = "/";
                GetOperand1();
                realBox.Focus();
            }
            else if (e.KeyCode == Keys.C)
            {
                chainBox.Text = "";
                ClearBox();
                sumBox.Text = "";
                realBox.Focus();
            }
            else if (e.KeyCode == Keys.N)
            {
                chaining = 0;
                ClearBox();
                sumBox.Text = "";
                chainBox.Text = "";
                memoryBox.Items.Clear();
                realBox.Focus();
            }
            else if (e.KeyCode == Keys.S)
            {
                AddMemoryElement();    
            }
            else if (e.KeyCode == Keys.M)
            {
                modeBox.Focus();
            }
            else if (e.KeyCode == Keys.R)
            {
                memoryBox.Focus();
            }

            else if (e.KeyCode == Keys.Q)
            {
                Environment.Exit(1);
            }

            if (e.KeyCode == Keys.Enter)
            {
                GetOperand2();
                Calculate();
            }

        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aboutString =
@"Instructions guide
1.Make sure numpad is enabled

2.Make sure you specified a valid real number for the real and imaginary parts
before pressing any arithmetic keys.
Switch between the real and imag textbox with tab
Finally after you have two operands hit enter to get a result

3.Key Definitions:
s=save the result in memory
r=recall the result, you will be taken to the memory list in order to select which saved memory result to use, use arrow keys and hit enter
m=mode, switch between rectangular and polar using arrow keys
n=restart with new chain (CE)
q=quit
c=clears inputboxes (c)

*=multiplacation
/=division
+=addition
-=subtraction

Importan Note, in order to give keyboard commans the focus has to be in either textbox
@Willy Herrera";
            MessageBox.Show(aboutString);
        }

        private void removeMemoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                memoryBox.Items.RemoveAt(0);
            }
            catch
            {
                MessageBox.Show("nothing in memory");
            }
        }

        private void realBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
