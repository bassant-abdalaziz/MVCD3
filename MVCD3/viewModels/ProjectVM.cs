using Microsoft.AspNetCore.Mvc;
using MVCD3.Models;
using System.ComponentModel.DataAnnotations;
namespace MVCD3.viewModels
{
    public class ProjectVM
    {
        [Key]
        public int Number { get; set; }
        [Required]
        [MinLength(5)]
        [Display (Name= "Project Name")]
        public string? Name { get; set; }

        [Display(Name = "Project Location")]
        [Required]
        [Remote("ValidateLocation", "customValidation",ErrorMessage = "Location Must be Cairo or Giza or Alex")]
        public string? Location { get; set; }


        [Compare("Location")]
        public string? confirmLocation { get; set; }
    }
}
