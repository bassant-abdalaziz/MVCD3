using System.ComponentModel.DataAnnotations.Schema;

namespace MVCD3.Models
{
    public class WorksOnProject
    {
        public string? Hours { get; set; }

        [ForeignKey("Employee")]
        public int EmpSSN { get; set; }
        public virtual Employee? Employees { get; set; }

        [ForeignKey("Project")]
        public int projNum { get; set; }
        public virtual Project? Project { get; set; }
    }
}
