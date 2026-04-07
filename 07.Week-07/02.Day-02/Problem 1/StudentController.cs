/*Week-7 (DAY-2) Hands-On
Problem 1 (Level-1): Student Registration &Display
Scenario:
A small institute wants a simple web page where users can enter student details and see the submitted data on another page.
Requirements:
1.Create a form to accept: 
Student Name 
Age 
Course 
2. Submit the form using HttpPost 
3.Redirect to another action method to display entered data 
4.  Pass data using ViewBag OR ViewData

Technical Constraints
1.  Use Attribute-based routing 
2.  Do NOT use Model or Database 
3.  Use only ViewBag/ViewData for state management 
4.  Use separate actions for: 
GET → Display form 
POST → Handle submission
Expectations
1. Clean separation of GET and POST actions 
2. Correct usage of ViewBag/ViewData 
3. Proper routing using attributes 
4.Data displayed correctly after submission
Learning Outcome
1.  Understanding of HttpGet vs HttpPost 
2. Basics of state management using ViewBag/ ViewData
3.Hands - on with attribute routing*/

using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        // GET → Display Form
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        // POST → Handle Submission
        [HttpPost("register")]
        public IActionResult Register(string studentName, int age, string course)
        {
            return RedirectToAction("Display", new
            {
                name = studentName,
                age = age,
                course = course
            });
        }

        // GET → Display Output
        [HttpGet("display")]
        public IActionResult Display(string name, int age, string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View();
        }
    }
}
