using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
////Willy Herrera 812806170
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexCalculator a = new ComplexCalculator();
            while (true)
            {
                try///try do something about the error
                {
                    a.runCalculator();
                }
                catch (QuitException)
                { 
                    Environment.Exit(0); 
                }
                catch (ClearMenuException)
                {
                }
                catch (MainMenuException)
                {

                }
            }
            
        }
    }
    class ComplexCalculator
    {
        string input;
        string operation;
        
        public void runCalculator()
        {
            Console.WriteLine("(c) Clear\n(+) Add\n(-) Subtract\n(*) Multiply\n(/) Divide\n(m) Menu\n(q) Quit");

            Console.WriteLine("Enter operand 1");
            
            input = Console.ReadLine();

            Complex first = ParseComplexInput(input);//first operand
            Console.WriteLine(first);///displayed entered values
                     
            Console.Write("Enter operation:");
            operation = Console.ReadLine();
            ValidateInput(operation);

            Console.WriteLine("Enter operand 2");
            input = Console.ReadLine();
            Complex second = ParseComplexInput(input);//second operand
            Console.WriteLine(second);///displayed entered values

            Complex result = new Complex() ;
      
            if (operation == "-")
            {
                result = first - second;
            }
            else if (operation== "+")
            {
                result = first + second;     
            }
            else if (operation == "*")
            {
                result = first * second;
                
            }
            else if (operation == "/")
            {
                result = first / second;
            }
            else
            {
                throw new Exception("errr");
            }
            
            Console.WriteLine("({0},{1}) {6} ({2},{3}) = ({4},{5})",first.Real,first.Imaginary,second.Real,second.Imaginary,result.Real,result.Imaginary,operation);
        }

        public static Complex ParseComplexInput(string input)//Parse function
        {
            ValidateInput(input);

            String [] result = input.Split(' ');

            double real = double.Parse(result[0]);
            double image = double.Parse(result[1]);

            Complex complex = new Complex(real, image);
            return complex;//return real and imaginary part
        }

        private static void ValidateInput(string input)///look for exceptions
        {
            if ((input == "m"))
            {
                throw new MainMenuException();
            }
            else if (input == "c")
            {
                throw new ClearMenuException();
            }
            else if ((input == "q"))
            {
                throw new QuitException();
            }
        }

    }
}
