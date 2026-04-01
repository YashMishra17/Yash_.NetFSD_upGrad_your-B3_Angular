using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication19.Controllers
{
    public class EmpController : Controller
    {

        public static List<Employee> employees = new List<Employee>
            {
                new Employee { Empno = 101, Ename = "Amit", Job = "Manager", Salary = 50000, Deptno = 10 },
                new Employee { Empno = 102, Ename = "Neha", Job = "Developer", Salary = 40000, Deptno = 20 },
                new Employee { Empno = 103, Ename = "Raj", Job = "Tester", Salary = 35000, Deptno = 20 },
                new Employee { Empno = 104, Ename = "Sneha", Job = "HR", Salary = 30000, Deptno = 30 },
                new Employee { Empno = 105, Ename = "Karan", Job = "Analyst", Salary = 45000, Deptno = 10 }
            };

        public IActionResult Index()
        {

            return View(employees);
        }

        public IActionResult Details(int id)
        {
            Employee empObj = employees.FirstOrDefault(item => item.Empno == id);
            return View(empObj);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            employees.Add(obj);
            //  ViewBag.Message = "New Employee Creation Successfully";
            // return RedirectToAction("Index","Home");    // Home controller Index
            return RedirectToAction("Index");   //  Current Controller Index 
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee empObj = employees.FirstOrDefault(item => item.Empno == id);
            return View(empObj);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            var existEmp = employees.FirstOrDefault(x => x.Empno == emp.Empno);

            //  employees.Remove(existEmp);
            //  employees.Add(emp);

            existEmp.Ename = emp.Ename;
            existEmp.Salary = emp.Salary;
            existEmp.Job = emp.Job;
            existEmp.Deptno = emp.Deptno;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee empObj = employees.FirstOrDefault(item => item.Empno == id);
            return View(empObj);
        }

        [HttpPost]
        [ActionName("Delete")]      //  Mapping Delete Request to DeleteConfirm Action Method
        public IActionResult DeleteConfirm(int id)
        {
            Employee empObj = employees.FirstOrDefault(item => item.Empno == id);
            employees.Remove(empObj);

            return RedirectToAction("Index");
        }
    }
}
