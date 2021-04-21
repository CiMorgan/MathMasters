using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Models
{
    public class DetailCourse
    {
        [Display(Name = "ID")]
        public int CourseId { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }
        [Display(Name = "Tutor List")]
        public List<string> CourseTutorList { get; set; }
        [Display(Name = "Student List")]
        public List<string> CourseStudentList { get; set; }
    }
}
