using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCD3.Models;
using MVCD3.viewModels;
namespace MVCD3.Controllers
{
    public class HtmlHelperController : Controller
    {
        private CompanyDBContext context;
        public HtmlHelperController()
        {
            context = new CompanyDBContext();
        }

        public IActionResult Index()
        {
            List<Department> departments = context.Departments.Include(d => d.DepartmentLocations).ToList();

            return View(departments);
        }


        public IActionResult Add()
        {
            List<Employee> employeeManager = context.Employees.Include(m=> m.DepartmentManege).ToList();
            ViewBag.empManager = new SelectList(employeeManager, "SSN", "Fname");
            return View();
        }

        public IActionResult AddDb(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Department dept = context.Departments.SingleOrDefault(i => i.Number == id);
            List<Employee> employeeManager = context.Employees.Include(m => m.DepartmentManege).ToList();
            ViewBag.empManager = new SelectList(employeeManager, "SSN", "Fname");
            
            return View(dept);
        }

        public IActionResult EditDb(Department department)
        {
            context.Departments.Update(department);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Department department = context.Departments.SingleOrDefault(d => d.Number == id);
            context.Departments.Remove(department);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
