using MathMasters.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Models
{
    public class DetailTutor
    {
        [Display(Name = "ID")]
        public int TutorId { get; set; }
        [Display(Name = "First Name")]
        public string TutorFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string TutorLastName { get; set; }

        [Display(Name  = "Location")]
        public string Location { get; set; }

        //[Display(Name = "Available Time")]
        //public string TimeList { get; set; }

        [Display(Name = "Course List")]
        public List<string> TutorCourseList { get; set; }
        [Display(Name = "Student List")]
        public List<string> TutorStudentList { get; set; }
        [Display(Name = "Scheduled Tutoring Sessions")]
        public List<DateTime> TutorScheduleList { get; set; }
    }
}
