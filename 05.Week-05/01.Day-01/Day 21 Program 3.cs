/*DAY-1 Hands-On
 * Week - 05 / Day - 21
Level-2 Problem 1: Online Shopping Cart System
Scenario:
An e-commerce platform needs a flexible cart system where different product types calculate discounts differently.
Requirements:
1. Create a base class Product with properties Name and Price.
2. Create derived classes Electronics and Clothing.
3. Implement a virtual method CalculateDiscount().
4. Electronics get 5% discount, Clothing gets 15% discount.
5. Use encapsulation to protect price updates.
Technical Constraints:
• Use private fields with public properties.
• Apply inheritance and method overriding.
• Prevent negative price assignment.
Expectations:
• Demonstrate polymorphic behavior in cart processing.
• Apply data validation inside properties.
• Calculate and display final price after discount.
Learning Outcome:
• Combine encapsulation and polymorphism.
• Design extensible product hierarchy.
• Implement business logic in overridden methods.
Sample Input: Electronics Price = 20000
Sample Output: Final Price after 5% discount = 19000
*/


using System;

// Base class
class Product
{
    // Private fields (data hiding)
    private string name;
    private double price;

    // Property for Name
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Property for Price with validation
    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Price cannot be negative");
            price = value;
        }
    }

    // Virtual method for discount calculation
    public virtual double CalculateDiscount()
    {
        return Price; // default (no discount)
    }
}

// Derived class: Electronics
class Electronics : Product
{
    // Override discount calculation
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.05); // 5% discount
    }
}

// Derived class: Clothing
class Clothing : Product
{
    // Override discount calculation
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.15); // 15% discount
    }
}

// Main Program
class Program
{
    static void Main()
    {
        // Base class reference (polymorphism)
        Product electronicItem = new Electronics();
        electronicItem.Name = "Laptop";
        electronicItem.Price = 20000;

        Product clothingItem = new Clothing();
        clothingItem.Name = "Jacket";
        clothingItem.Price = 5000;

        // Display final prices
        Console.WriteLine("Electronics Final Price after 5% discount = "
            + electronicItem.CalculateDiscount());

        Console.WriteLine("Clothing Final Price after 15% discount = "
            + clothingItem.CalculateDiscount());
    }
}