using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            AreaCalculator calculator = new AreaCalculator();

            // Rectangle
            Shape rect = new Rectangle
            {
                Width = 5,
                Height = 4
            };

            calculator.PrintArea(rect);

            // Circle
            Shape circle = new Circle
            {
                Radius = 3
            };

            calculator.PrintArea(circle);

            Console.ReadLine();
        }
    }
}
