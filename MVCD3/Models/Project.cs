﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCD3.Models
{
    public class Project
    {
        [Key]
        public int Number { get; set; }
       
        public string? Name { get; set; }
      
        public string? Location { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Departments")]
        public int? DeptNum { get; set; }
        public virtual Department? Department { get; set; }
    }
}
