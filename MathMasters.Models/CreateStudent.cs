using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Models
{
    public class CreateStudent
    {
        [Required]
        [Display(Name = "First Name")]
        public string StudentFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string StudentLastName { get; set; }
        [Required, Range(0, 13, ErrorMessage = "Please choose a number between 0 and 13, with 0 being Kindergarten and 13 being first year college.")]
        [Display(Name = "Grade Level")]
        public int StudentGradeLevel { get; set; }
    }
}
