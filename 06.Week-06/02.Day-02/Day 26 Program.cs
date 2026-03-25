using ConsoleApp1;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            ProductDAL dal = new ProductDAL();

            while (true)
            {
                Console.WriteLine("\n1. Insert");
                Console.WriteLine("2. View");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Exit");

                Console.Write("Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Product p1 = new Product();

                        Console.Write("Name: ");
                        p1.ProductName = Console.ReadLine();

                        Console.Write("Category: ");
                        p1.Category = Console.ReadLine();

                        Console.Write("Price: ");
                        p1.Price = Convert.ToDecimal(Console.ReadLine());

                        dal.InsertProduct(p1);
                        break;

                    case 2:
                        var list = dal.GetProducts();
                        foreach (var p in list)
                        {
                            Console.WriteLine($"{p.ProductId} | {p.ProductName} | {p.Category} | {p.Price}");
                        }
                        break;

                    case 3:
                        Product p2 = new Product();

                        Console.Write("ID: ");
                        p2.ProductId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Name: ");
                        p2.ProductName = Console.ReadLine();

                        Console.Write("Category: ");
                        p2.Category = Console.ReadLine();

                        Console.Write("Price: ");
                        p2.Price = Convert.ToDecimal(Console.ReadLine());

                        dal.UpdateProduct(p2);
                        break;

                    case 4:
                        Console.Write("ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        dal.DeleteProduct(id);
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}