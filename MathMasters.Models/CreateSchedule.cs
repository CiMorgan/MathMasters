using MathMasters.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int ScheduleTutorID { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int ScheduleCourseID { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime ScheduleDate { get; set; }

        [Required]
        [Display(Name = "Rate per hour")]
        public Double ScheduleRate { get; set; }

    }
}
