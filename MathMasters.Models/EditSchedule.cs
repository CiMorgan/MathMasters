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
    public class EditSchedule
    {
        [Display(Name = "ScheduleID")]
        public int ScheduleId { get; set; }

        [Required]
        [Display(Name = "Tutor")]
        public string ScheduleTutorID { get; set; }

        [Required]
        [Display(Name = "Course")]
        public string ScheduleCourseID { get; set; }

        public ListOfLocations ScheduleLocation { get; set; }


        [Display(Name = "Day")]
        public string ScheduleDay { get; set; }

        [Display(Name = "Date")]
        public DateTime ScheduleDate { get; set; }
        public IEnumerable<SelectListItem> AvailableDays { get; set; }
        public IEnumerable<SelectListItem> AvailableTutors { get; set; }
        public IEnumerable<SelectListItem> AvailableCourses { get; set; }
    }
}
