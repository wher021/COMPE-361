using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexNumbers
{
    class ComplexCalculator
    {
        private Complex total=new Complex();
        private Complex operand1=new Complex(), operand2=new Complex();
        private string Operator;

        public Complex op1
        {
            get { return operand1; }
            set { operand1 = value; }
        }

        public Complex op2
        {
            get { return operand2; }
            set { operand2 = value; }
        }

        public Complex tot
        {
            get { return total; }
        }

        public string oper
        {
            get { return Operator; }
            set { Operator = value; }
        }

        public void displayMenu()
        {
            Console.WriteLine("(c) Clear\n(+) Add\n(-) Subtract\n(*) Multiply\n(/) Divide\n(p) Polar\n(r) Rectangular\n(m) Menu\n(q) Quit\n(M) Magnitude\n(A) Angle\n(R) Real\n(I) Imaginary");
        }

        public void runCalculator ()
        {
            displayMenu();

            Operand1();

            while (true)
            {
                string op;
                op=getOperator();
                Operand2();
                Calculate(op);
                op1 = tot;

            }
                

        }
        private string getOperator()
        {
            string s="";

            while (true)
            {
                Console.WriteLine("enter operator");
                s = Console.ReadLine();
       
                switch (s)
                {
                    case "m":
                        {
                            displayMenu();
                            break;
                        }
                    case "c":
                        {
                            runCalculator();//PrintMenu();
                            break;
                        }
                    case "q":
                        {
                            Environment.Exit(0);
                            break;
                        }

                    case "p":
                        {
                            Complex.mode = MODE.Polar;
                            Console.WriteLine("you are in Polar Mode");
                            Console.WriteLine("{0}", op1);
                            break;
                        }
                    case "r":
                        {
                            Complex.mode = MODE.Rectangular;
                            Console.WriteLine("you are in Rectangular Mode");
                            Console.WriteLine("{0}", op1);
                            break;
                        }

                    case "M":
                        {
                            Console.WriteLine("{0}: ", op1.Magnitude);
                            string input_mag = Console.ReadLine();
                            if (input_mag == "")
                                break;
                            op1.Magnitude = double.Parse(input_mag);
                            Console.WriteLine(op1);
                            break;
                        }
                    case "A":
                        {
                            Console.WriteLine("{0}: ", op1.Angle);
                            string input_angle = Console.ReadLine();
                            if (input_angle == "")
                                break;
                            op1.Angle = double.Parse(input_angle);
                            Console.WriteLine(op1);
                            break;
                        }
                    case "R":
                        {
                            Console.WriteLine("{0}: ", op1.Real);
                            string input_real = Console.ReadLine();
                            if (input_real == "")
                                break;
                            op1.Real = double.Parse(input_real);
                            Console.WriteLine(op1);
                            break;
                        }
                    case "I":
                        {
                            Console.WriteLine("{0}: ", op1.Imag);
                            string input_imag = Console.ReadLine();
                            if (input_imag == "")
                                break;
                            op1.Imag = double.Parse(input_imag);
                            Console.WriteLine(op1);
                            break;
                        }             
                        
                }
                  if (s.Equals("+") || s.Equals("-") || s.Equals("*") || s.Equals("/"))
                  {
                      break;
                  }                   
            }
            return s;
      
            
        }

        private void Operand2()
        {
            string s;
            if (Complex.mode == MODE.Polar)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("enter Magnitude");
                        s = Console.ReadLine();
                        op2.Magnitude = double.Parse(s);
                        Console.WriteLine("enter Angle");
                        s = Console.ReadLine();
                        op2.Angle = double.Parse(s);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("invalid input");
                    }
                }
            }
            else if (Complex.mode == MODE.Rectangular)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter operand2");
                        Console.Write("real part: ");
                        s = Console.ReadLine();
                        op2.Real = double.Parse(s);
                        Console.Write("imaginary part: ");
                        s = Console.ReadLine();
                        op2.Imag = double.Parse(s);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("invalid input");
                    }
                }
            }
        }

        public void Operand1()
        {
            string s;
            if (Complex.mode == MODE.Polar)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("enter Magnitude");
                        s = Console.ReadLine();
                        op1.Magnitude = double.Parse(s);
                        Console.WriteLine("enter Angle");
                        s = Console.ReadLine();
                        op1.Angle = double.Parse(s);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("invalid input");
                    }
                }
            }
            else if (Complex.mode == MODE.Rectangular)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter operand1");
                        Console.Write("real part: ");
                        s = Console.ReadLine();
                        op1.Real = double.Parse(s);
                        Console.Write("imaginary part: ");
                        s = Console.ReadLine();
                        op1.Imag = double.Parse(s);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("invalid input");
                    }
                }
            }

        }

        public void Calculate(string op)
        {

            switch (op)
            {
                case "+":
                    {
                        total = operand1 + operand2;
                        break;
                    }

                case "-":
                    {
                        total = operand1 - operand2;
                        break;
                    }
                case "*":
                    {
                        total = operand1 * operand2;
                        break;
                    }

                case "/":
                    {
                        total = operand1 / operand2;
                        break;
                    }
                    
            }
            Console.WriteLine("({0}) {1} ({2}) = ({3})",op2,op,op2,total);
        }
    }
}
            
