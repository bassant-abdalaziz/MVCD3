using Microsoft.AspNetCore.Mvc;
using MVCD3.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCD3.Controllers
{
    public class DepartmentController : Controller
    {
        private CompanyDBContext DB;
        public DepartmentController()
        {
            DB = new CompanyDBContext();

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetDepartment(int id)
        {
            Department department = DB.Departments.Include(d=>d.DepartmentLocations).Include(d=>d.Projects).SingleOrDefault(d => d.mngrSSN == id);
            
            if (department == null)
                return View("Error"); 
            else
                return View("GetDepartment", department);

        }
    }
}
