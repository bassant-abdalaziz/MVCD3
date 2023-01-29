using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCD3.Models;

namespace MVCD3.Controllers
{
    public class TaghelpersController : Controller
    {
        private CompanyDBContext context;
        public TaghelpersController()
        {
            context = new CompanyDBContext();
        }
        public IActionResult Index()
        {
            List<Project> projects = context.Projects.ToList();
            return View(projects);
        }


        [HttpGet]
        public IActionResult Add()
        {
            List<Department> departments = context.Departments.ToList();
            ViewBag.Departments = new SelectList(departments, "Number", "Name");
            return View();

        }

        [HttpPost]
        public IActionResult Add(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int? id)
        {
            List<Department> departments = context.Departments.ToList();
            ViewBag.Departments = new SelectList(departments, "Number", "Name");
            if (id == null)
            {
                return View();
            }
            Project? project = context.Projects.SingleOrDefault(p => p.Number == id);
            return View(project);
        }

        public IActionResult EditDB(Project project)
        {
            Project? oldProject = context.Projects.SingleOrDefault(e => e.Number == project.Number);
            oldProject.Name = project.Name;
            oldProject.Location = project.Location;
            oldProject.DeptNum = project.DeptNum;

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            Project project = context.Projects.SingleOrDefault(e => e.Number == id);
            context.Projects.Remove(project);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
