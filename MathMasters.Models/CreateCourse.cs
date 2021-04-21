using MathMasters.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Models
{
    public class CreateCourse
    {
        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Course Description")]
        [MaxLength(500, ErrorMessage = "There are too many characters in this field.")]
        public string CourseDescription { get; set; }
        [Required]
        [Display(Name = "Available Times")]
        public ListOfTimes CourseTime { get; set; }
    }
}
