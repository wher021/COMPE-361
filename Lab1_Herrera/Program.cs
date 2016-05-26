using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Willy Herrera 812806170*/

namespace ConversionProgram
{
    class Program
    {
        static void Main(string[] args)
        {

            int choice;
            while (true)
            {
                Console.WriteLine("please choose one of the following options to convert (press q to quit)");
                Console.WriteLine("1 Length Units,2 Volume units 3,Area units");
                string s = Console.ReadLine();        
                if (s == "q")
                Environment.Exit(0);
                choice = int.Parse(s);

                if (choice == 1)///choice of conversion
                    Length1.Length(choice);
                else if (choice == 2)
                    Volume1.Volume(choice);
                else if (choice == 3)
                    Area1.Area(choice);
                else
                    Console.WriteLine("you can only choose 1,2,3");
               
                Console.WriteLine();
            }
        }
    }
}
