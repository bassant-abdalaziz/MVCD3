using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCD3.Models;
using MVCD3.viewModels;

namespace MVCD3.Controllers
{
    public class ValidationProjController : Controller
    {
        private CompanyDBContext context;
        public ValidationProjController()
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
            return View();

        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public IActionResult Add(ProjectVM project)
        {
            
            if (ModelState.IsValid) {
                Project project1 = new Project()
                {
                    Name = project.Name,
                    Location = project.Location,
                };

                context.Projects.Add(project1);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
         return View();
        }
    }
}
