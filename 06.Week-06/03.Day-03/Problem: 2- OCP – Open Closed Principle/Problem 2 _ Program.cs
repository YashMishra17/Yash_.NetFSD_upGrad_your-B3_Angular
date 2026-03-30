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
            DiscountCalculator calculator = new DiscountCalculator();

            Console.Write("Enter Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Choose Customer Type:");
            Console.WriteLine("1. Regular");
            Console.WriteLine("2. Premium");
            Console.WriteLine("3. VIP");

            int choice = Convert.ToInt32(Console.ReadLine());

            IDiscountStrategy strategy = choice switch
            {
                1 => new RegularCustomerDiscount(),
                2 => new PremiumCustomerDiscount(),
                3 => new VipCustomerDiscount(),
                _ => null
            };

            if (strategy == null)
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            double finalPrice = calculator.GetFinalPrice(amount, strategy);

            Console.WriteLine($"Final Price: {finalPrice}");
            Console.ReadLine();
        }
    }
}
