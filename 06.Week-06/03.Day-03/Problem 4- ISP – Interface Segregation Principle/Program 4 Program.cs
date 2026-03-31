using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            // Basic Printer
            IPrinter basic = new BasicPrinter();
            basic.Print();

            Console.WriteLine();

            // Advanced Printer
            AdvancedPrinter advanced = new AdvancedPrinter();
            advanced.Print();
            advanced.Scan();
            advanced.Fax();

            Console.ReadLine();
        }
    }
}