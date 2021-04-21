using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Models
{
    public class AllCourseList
    {
        public int CourseId { get; set; }
        [Display(Name = "Course")]
        public string CourseName { get; set; }
    }
}
