using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void SimpleDelegate();
        Complex operand1 = new Complex();
        Complex operand2 = new Complex();
        string Operator;
        int chaining;
        List<Complex> list = new List<Complex>();
        Object sender;////store global variable sender!!!
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("please read instructions from the menu before using, you start in rectangular mode");
            modeBox.SelectedIndex = 0;
            realBox.Focus();
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority
.ApplicationIdle, new SimpleDelegate(DoFocus));
        }

        private void number_Click(object sender, RoutedEventArgs e)
        {
            if (this.sender == realBox)
                realBox.Text += ((Button)sender).Content;
            else if (this.sender == imagBox)
                imagBox.Text += ((Button)sender).Content;

        }

        private void equalButton_Click(object sender, RoutedEventArgs e)
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
            chainBox.Text=null;
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

        private void arithmeticButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == addButton)
                Operator = "+";
            else if (sender == subButton)
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
            realBox.Text=null;
            imagBox.Text=null;

        }

        private void realBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.sender = sender;
        }

        private void imagBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.sender = sender;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
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

        private void memoryButton_Click(object sender, RoutedEventArgs e)
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

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearBox();
            sumBox.Text=null;
        }

        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            chaining = 0;
            ClearBox();
            sumBox.Text = null;
            chainBox.Text=null;
            memoryBox.Items.Clear();
        }

        private void modeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBoxItem currentItem = ((System.Windows.Controls.ComboBoxItem)modeBox.SelectedItem);

            if (modeBox.SelectedIndex.Equals(0))
            {
                Complex.mode = MODE.Rectangular;
                label1.Content = "Real";
                label2.Content = "Imag";
                sumBox.Text = operand1.ToString();
                chainBox.Text = operand1.ToString() + Operator;
            }
            else if (modeBox.SelectedIndex.Equals(1))//(currentItem.Content.Equals("Polar"))
            {
                Complex.mode = MODE.Polar;
                label1.Content = "Magnitude";
                label2.Content = "Angle";
                sumBox.Text = operand1.ToString();
                chainBox.Text = operand1.ToString() + Operator;
            }
       
        }

        private void memoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void removeMemoryButton_Click(object sender, RoutedEventArgs e)
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

        private void myKeyDown_KeyDown(object sender, KeyEventArgs e)
        {

                if (e.Key == Key.Multiply)
                {
                    e.Handled = true;
                    Operator = "*";
                    GetOperand1();
                    realBox.Focus();
                }
                else if (e.Key == Key.Add)
                {
                    e.Handled = true;
                    Operator = "+";
                    GetOperand1();
                    
                    realBox.Focus();
                    DoFocus();
                }
                else if (e.Key == Key.Subtract)
                {
                    e.Handled = true;
                    Operator = "-";
                    GetOperand1();
                    realBox.Focus();
                }
                else if (e.Key == Key.Divide)
                {
                    e.Handled = true;
                    Operator = "/";
                    GetOperand1();
                    realBox.Focus();
                }
                else if (e.Key == Key.C)
                {
                    e.Handled = true;
                    chainBox.Text = "";
                    ClearBox();
                    sumBox.Text = "";
                    realBox.Focus();
                }
                else if (e.Key == Key.N)
                {
                    e.Handled = true;
                    chaining = 0;
                    ClearBox();
                    sumBox.Text = "";
                    chainBox.Text = "";
                    memoryBox.Items.Clear();
                    realBox.Focus();
                }
                else if (e.Key == Key.S)
                {
                    e.Handled = true;
                    AddMemoryElement();
                }
                else if (e.Key == Key.M)
                {
                    e.Handled = true;
                    modeBox.Focus();
                }
                else if (e.Key == Key.R)
                {
                    e.Handled = true;
                    memoryBox.Focus();
                }

                else if (e.Key == Key.Q)
                {
                    e.Handled = true;
                    Environment.Exit(1);
                }

                if (e.Key == Key.Enter)
                {
                    try
                    {

                        GetOperand2();
                        Calculate();
                        DoFocus();

                    }
                    catch
                    {
                        MessageBox.Show("operand cannot be empty");
                    }
                    
                }        

        }

        private void Window_SizeChanged_2(object sender, SizeChangedEventArgs e)
        {
            this.FontSize = this.Width / 40;
            //memoryBox.FontSize = this.Width / 40;
        }
        void DoFocus()
        {
            realBox.Focus();

        }



    }
}
