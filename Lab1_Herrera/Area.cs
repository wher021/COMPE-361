using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConversionProgram
{
    class Area1
    {
        enum choice3 { feet = 1, miles, acres };
        public static void Area(int choice)
        {
            string s;
            double feet, miles, acres;
            Console.WriteLine("choose one of the followng 1.feet,2.miles,3.acres");
            s = Console.ReadLine();
            choice = int.Parse(s);

            switch (choice)
            {
                case (int)choice3.feet:
                    {
                        Console.WriteLine("enter amount of sqfeet");
                        s = Console.ReadLine();
                        feet = double.Parse(s);
                        Console.WriteLine("feet={0},miles={1},acres={2}", feet, miles = feet / 27878400, acres = feet * 0.00002296);
                        break;
                    }
                case (int)choice3.miles:
                    {
                        Console.WriteLine("enter amount of sqmiles");
                        s = Console.ReadLine();
                        miles = double.Parse(s);
                        Console.WriteLine("feet={0},miles={1},acres={2}", miles * 27878400, miles, miles * 640);
                        break;
                    }
                case (int)choice3.acres:
                    {
                        Console.WriteLine("enter amount of sqacres");
                        s = Console.ReadLine();
                        acres = double.Parse(s);
                        Console.WriteLine("feet={0},miles={1},acres={2}", acres * 43560, acres * 0.0015625, acres);
                        break;
                    }
            }
            return;
        }
    }
}
