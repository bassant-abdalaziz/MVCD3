using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCD3.Models;

namespace MVCD3.Controllers
{
    public class WorksOnProjectController : Controller
    {
        private CompanyDBContext DB;
        public WorksOnProjectController()
        {
            DB = new CompanyDBContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(int id)
        {
            List<Project> projects = DB.Projects.Where(p => p.DeptNum == id).ToList();
            List<Employee> employees = DB.Employees.Where(p => p.deptId == id).ToList();

            ViewBag.emps = employees;

            return View(projects);
        }

        WorksOnProject worksOnProject;
        public IActionResult AddDB(List<int> Projects, List<int> Employees)
        {

            foreach (var Project in Projects)
            {
                foreach (var employee in Employees)
                {
                    WorksOnProject worksOnProject = new WorksOnProject()
                    {
                        EmpSSN = employee,
                        projNum = Project
                    };
                    worksOnProject = DB.WorksOnProjects.Include(wop => wop.Project).SingleOrDefault(wop => wop.EmpSSN == worksOnProject.EmpSSN);
                    DB.WorksOnProjects.Add(worksOnProject);
                    DB.SaveChanges();
                }

            }

            ViewBag.emps = Employees;
            ViewBag.mgrSSN = (int)HttpContext.Session.GetInt32("SSN");

            return View(worksOnProject);
        }


        public IActionResult EditEmpHours()
        {
            List<Employee> employees = DB.Employees.ToList();
            ViewBag.employees = new SelectList(employees, "SSN", "Fname");
            return View();
        }

        public IActionResult EditEmpHoursDb(WorksOnProject worksOnProject)
        {
            DB.WorksOnProjects.Update(worksOnProject);
            DB.SaveChanges();
            return View();
        }

        public IActionResult EmpHour(int id)
        {
            List<Project>? projects = DB.WorksOnProjects.Include(w => w.Project).Where(w => w.EmpSSN == id).Select(w => w.Project).ToList();
            ViewBag.projects = new SelectList(projects, "Number", "Name");
            if (projects.Count > 0)
            {
                WorksOnProject worksOnProject = new WorksOnProject()
                {
                    Hours = DB.WorksOnProjects.SingleOrDefault(w => (w.EmpSSN == id) && (w.projNum == projects[0].Number)).Hours
                };
                return PartialView("_ProjectsList", worksOnProject);
            }
            return PartialView("_ProjectsList");
        }

        public IActionResult EmpProject(int id, int projNum)
        {
            WorksOnProject? worksOnProject = DB.WorksOnProjects.SingleOrDefault(wop => wop.EmpSSN == id && wop.projNum == projNum);
            return PartialView("_hour", worksOnProject);
        }

 

    }
}
