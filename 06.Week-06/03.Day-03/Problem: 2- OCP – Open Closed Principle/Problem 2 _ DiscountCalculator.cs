using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class DiscountCalculator
    {
        public double GetFinalPrice(double amount, IDiscountStrategy strategy)
        {
            double discount = strategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }
}