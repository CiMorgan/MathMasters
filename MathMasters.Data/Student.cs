using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, Range(0,13, ErrorMessage = "Please choose a number between 0 and 13, with 0 being Kindergarten and 13 being first year college.")]
        [Display(Name = "Grade Level")]
        public int GradeLevel { get; set; }
    }
}
