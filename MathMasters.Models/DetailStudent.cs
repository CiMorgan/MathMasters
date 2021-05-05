using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Models
{
    public class DetailStudent
    {
        [Display(Name= "ID")]
        public int StudentId { get; set; }
        [Display(Name = "First Name")]
        public string StudentFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string StudentLastName { get; set; }
        [Display(Name = "Grade Level")]
        public int StudentGradeLevel { get; set; }
        [Display(Name = "Course List")]
        public List<string> StudentCourseList { get; set; }
        [Display(Name = "Tutor List")]
        public List<string> StudentTutorList { get; set; }
        [Display(Name = "Scheduled Tutoring Sessions")]
        public List<string> StudentScheduleList { get; set; }
    }
}
