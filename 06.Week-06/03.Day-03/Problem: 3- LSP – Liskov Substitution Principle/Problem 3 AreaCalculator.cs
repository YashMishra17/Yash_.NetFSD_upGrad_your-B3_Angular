using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class AreaCalculator
    {
        public void PrintArea(Shape shape)
        {
            Console.WriteLine("Area: " + shape.CalculateArea());
        }
    }
}