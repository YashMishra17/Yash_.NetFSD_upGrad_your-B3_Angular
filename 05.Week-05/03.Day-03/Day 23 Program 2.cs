/*Week - 05 / Day - 03/ Day - 23
using System.Numerics;

Week - 5(DAY - 3) Hands - On
Please download and refer shared Code template (LinqCodeTemplate) and solve problems as given below. 
(Please Refer Problem-1 Solved in the Code Template and solve rest of other problems in the same project accordingly)
Problem Level- 1 and 2:
1.Write a LINQ query to search and display all products with category “FMCG”.
2. Write a LINQ query to search and display all products with category “Grain”.
3. Write a LINQ query to sort products in ascending order by product code.
4. Write a LINQ query to sort products in ascending order by product Category.
5. Write a LINQ query to sort products in ascending order by product Mrp.
6. Write a LINQ query to sort products in descending order by product Mrp.
7. Write a LINQ query to display products group by product Category.
8. Write a LINQ query to display products group by product Mrp.
9. Write a LINQ query to display product detail with highest price in FMCG category.
10. Write a LINQ query to display count of total products.
11. Write a LINQ query to display count of total products with category FMCG.
12.Write a LINQ query to display Max price.
13.Write a LINQ query to display Min price.
14. Write a LINQ query to display whether all products are below Mrp Rs.30 or not.
15. Write a LINQ query to display whether any products are below Mrp Rs.30 or not.*/

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqCodeTemplate
{
    // Product Class (Data + Source)
    internal class Product
    {
        public int ProCode { get; set; }
        public string ProName { get; set; }
        public string ProCategory { get; set; }
        public double ProMrp { get; set; }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ProCode=1001,ProName="Colgate-100gm",ProCategory="FMCG",ProMrp=55 },
                new Product{ProCode=1002,ProName="Colgate-50gm",ProCategory="FMCG",ProMrp=30 },
                new Product{ProCode=1009,ProName="DaburRed-100gm",ProCategory="FMCG",ProMrp=50 },
                new Product{ProCode=1006,ProName="DaburRed-50gm",ProCategory="FMCG",ProMrp=28 },
                new Product{ProCode=1008,ProName="Himalaya Neem Face Wash",ProCategory="FMCG",ProMrp=70 },
                new Product{ProCode=1007,ProName="Niviea Face Wash",ProCategory="FMCG",ProMrp=120 },
                new Product{ProCode=1010,ProName="Daawat-Basmati",ProCategory="Grain",ProMrp=130 },
                new Product{ProCode=1011,ProName="Delhi Gate-Basmati",ProCategory="Grain",ProMrp=120 },
                new Product{ProCode=1014,ProName="Saffola-Oil",ProCategory="Edible-Oil",ProMrp=160 },
                new Product{ProCode=1016,ProName="Fortune-Oil",ProCategory="Edible-Oil",ProMrp=150 },
                new Product{ProCode=1018,ProName="Nescafe",ProCategory="FMCG",ProMrp=70 },
                new Product{ProCode=1019,ProName="Bru",ProCategory="FMCG",ProMrp=90},
                new Product{ProCode=1015,ProName="Parachut",ProCategory="Edible-Oil",ProMrp=60}
            };
        }
    }

    // Main Class (All LINQ Problems)
    internal class Program
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            // 1. FMCG Products
            Console.WriteLine("\n1. FMCG Products");
            var res1 = products.Where(p => p.ProCategory == "FMCG");
            foreach (var item in res1)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            // 2. Grain Products
            Console.WriteLine("\n2. Grain Products");
            var res2 = products.Where(p => p.ProCategory == "Grain");
            foreach (var item in res2)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            // 3. Sort by Product Code
            Console.WriteLine("\n3. Sort by Product Code");
            var res3 = products.OrderBy(p => p.ProCode);
            foreach (var item in res3)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}");

            // 4. Sort by Category
            Console.WriteLine("\n4. Sort by Category");
            var res4 = products.OrderBy(p => p.ProCategory);
            foreach (var item in res4)
                Console.WriteLine($"{item.ProCategory}\t{item.ProName}");

            // 5. Sort by MRP Ascending
            Console.WriteLine("\n5. Sort by MRP (Ascending)");
            var res5 = products.OrderBy(p => p.ProMrp);
            foreach (var item in res5)
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");

            // 6. Sort by MRP Descending
            Console.WriteLine("\n6. Sort by MRP (Descending)");
            var res6 = products.OrderByDescending(p => p.ProMrp);
            foreach (var item in res6)
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");

            // 7. Group by Category
            Console.WriteLine("\n7. Group by Category");
            var res7 = products.GroupBy(p => p.ProCategory);
            foreach (var group in res7)
            {
                Console.WriteLine("Category: " + group.Key);
                foreach (var item in group)
                    Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
            }

            // 8. Group by MRP
            Console.WriteLine("\n8. Group by MRP");
            var res8 = products.GroupBy(p => p.ProMrp);
            foreach (var group in res8)
            {
                Console.WriteLine("MRP: " + group.Key);
                foreach (var item in group)
                    Console.WriteLine($"{item.ProName}");
            }

            // 9. Highest price in FMCG
            Console.WriteLine("\n9. Highest Price in FMCG");
            var res9 = products
                .Where(p => p.ProCategory == "FMCG")
                .OrderByDescending(p => p.ProMrp)
                .FirstOrDefault();

            Console.WriteLine($"{res9.ProName}\t{res9.ProMrp}");

            // 10. Total Products Count
            Console.WriteLine("\n10. Total Product Count");
            Console.WriteLine(products.Count());

            // 11. FMCG Count
            Console.WriteLine("\n11. FMCG Product Count");
            Console.WriteLine(products.Count(p => p.ProCategory == "FMCG"));

            // 12. Max Price
            Console.WriteLine("\n12. Max Price");
            Console.WriteLine(products.Max(p => p.ProMrp));

            // 13. Min Price
            Console.WriteLine("\n13. Min Price");
            Console.WriteLine(products.Min(p => p.ProMrp));

            // 14. All below 30?
            Console.WriteLine("\n14. All products below 30?");
            Console.WriteLine(products.All(p => p.ProMrp < 30));

            // 15. Any below 30?
            Console.WriteLine("\n15. Any product below 30?");
            Console.WriteLine(products.Any(p => p.ProMrp < 30));

            Console.ReadLine();
        }
    }
}




