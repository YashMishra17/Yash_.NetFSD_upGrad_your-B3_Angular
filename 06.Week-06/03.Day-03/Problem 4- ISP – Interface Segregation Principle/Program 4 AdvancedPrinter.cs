using ConsoleApp1;
using System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Advanced Printer: Printing document...");
        }

        public void Scan()
        {
            Console.WriteLine("Advanced Printer: Scanning document...");
        }

        public void Fax()
        {
            Console.WriteLine("Advanced Printer: Sending fax...");
        }
    }
}
