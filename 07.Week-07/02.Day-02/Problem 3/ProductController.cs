/*Problem 3 (Level-2): Product Entry with List Display
Scenario:
An admin wants to add multiple products and view them in a list on the same page.
Requirements:
1.  Create a form to input: 
Product Name 
Price 
Quantity 
2.  On submission: 
Add product to a List 
Display all products in tabular format 
3. Use ViewBag to store and display list
Technical Constraints
1.  Use Attribute-based routing 
2.  Use HttpPost for adding data 
3.  Maintain list temporarily (no database) 
4.  Use static list or TempData alternative NOT allowed
Expectations
1.  Data persists across multiple submissions (within session scope) 
2.  Table updates dynamically after each submission 
3.  Clean UI separation (form + table)
Learning Outcome
1.  Managing collections using ViewBag/ViewData 
2. Handling repeated form submissions 
3. Understanding limitations of ViewBag*/

///////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers.ProductEntry
{
    public class ProductController : Controller
    {
        // Static list → persists across requests (within app lifecycle)
        private static List<Product> products = new List<Product>();

        // GET → Show form + list
        [HttpGet("list")]
        public IActionResult Index()
        {
            ViewBag.Products = products;
            return View();
        }

        // POST → Add product
        [HttpPost("list")]
        public IActionResult Add(string name, decimal price, int quantity)
        {
            // Create product object
            Product p = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };

            products.Add(p);

            // Pass updated list
            ViewBag.Products = products;

            return View("Index");
        }
    }
    // Simple class (NOT a model for DB, just structure)
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
