using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionProgram
{
    class Volume1
    {
        enum choice2 { ounces = 1, quarts, liters };
        public static void Volume(int choice)
        {
            string s;
            double ounces, quarts, liters;
            Console.WriteLine("choose one of the followng 1.ounces,2.quarts,3.liters");
            s = Console.ReadLine();
            choice = int.Parse(s);

            switch (choice)
            {
                case (int)choice2.ounces:
                    {
                        Console.WriteLine("enter amount of ounces");
                        s = Console.ReadLine();
                        ounces = double.Parse(s);
                        Console.WriteLine("ounces={0},quarts={1},liters={2}", ounces, quarts = ounces / 32, liters = ounces * 0.0295735);
                        break;
                    }
                case (int)choice2.quarts:
                    {
                        Console.WriteLine("enter amount of quarts");
                        s = Console.ReadLine();
                        quarts = double.Parse(s);
                        Console.WriteLine("ounces={0},quarts={1},liters={2}", ounces = quarts * 32, quarts, liters = quarts * 0.946353);
                        break;
                    }
                case (int)choice2.liters:
                    {
                        Console.WriteLine("enter amount of liters");
                        s = Console.ReadLine();
                        liters = double.Parse(s);
                        Console.WriteLine("ounces={0},quarts={1},liters={2}", ounces = liters * 33.814, quarts = liters * 1.0669, liters);
                        break;
                    }
            }
            return;
        }
    }
}
