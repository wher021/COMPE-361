using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Willy Herrera 812806170  */

namespace ConversionProgram
{
    class Length1
    {
        enum choice1 { meters = 1, feet, miles };
        public static void Length(int choice)
        {
            string s;
            double m, f, mil;

            Console.WriteLine("choose 1.Meters 2.Feet 3.Miles");
            s = Console.ReadLine();
            choice = int.Parse(s);
            switch (choice)
            {
                case (int)choice1.meters:
                    {
                        Console.WriteLine("enter amount of Meters");
                        s = Console.ReadLine();
                        m = double.Parse(s);
                        double feet = m * 3.28084;
                        double miles = m / 1609.34;
                        Console.WriteLine("meters={0},feet={1},miles={2}", m, feet, miles);
                        break;
                    }
                case (int)choice1.feet:
                    {
                        Console.WriteLine("enter amount of Feet");
                        s = Console.ReadLine();
                        f = double.Parse(s);
                        Console.WriteLine("meters={0},feet={1},miles={2}", m = (f / 3.2808), f, mil = (m / 1000 * 0.62137));
                        break;
                    }
                case (int)choice1.miles:
                    {
                        Console.WriteLine("enter amount of Miles");
                        s = Console.ReadLine();
                        mil = double.Parse(s);
                        Console.WriteLine("meters={0},feet={1},miles={2}", m = (mil * 1609.34), f = (mil * 5280), mil);
                        break;
                    }
                default:
                    Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                    break;
            }
            return;


        }
    }
}
