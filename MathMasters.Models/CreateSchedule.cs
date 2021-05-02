using MathMasters.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MathMasters.Models
{

    public class CreateSchedule
    {
        [Required]
        [Display(Name = "Student ID")]
        public int ScheduleStudentID { get; set; }

        [Required]
        [Display(Name = "Location")]
        public ListOfLocations ScheduleLocation { get; set; }

        [Required]
        [Display(Name = "Tutor")]
        public string ScheduleTutorID { get; set; }

        [Required]
        [Display(Name = "Course")]
        public string ScheduleCourseID { get; set; }


        [Display(Name = "Day")]
        public string ScheduleDay { get; set; }


        [Display(Name = "Date")]
        public DateTime ScheduleDate { get; set; }

        [Required]
        [Display(Name = "Rate per hour")]
        public Double ScheduleRate { get; set; }

        public IEnumerable<SelectListItem> AvailableDays { get; set; }

        public IEnumerable<SelectListItem> AvailableTutors { get; set; }
        public IEnumerable<SelectListItem> AvailableCourses { get; set; }
    }
}
