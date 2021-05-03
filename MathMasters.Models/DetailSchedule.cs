using MathMasters.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Models
{
    public class DetailSchedule
    {
        [Display(Name = "ScheduleID")]
        public int ScheduleId { get; set; }

        [Display(Name = "Day and Time")]
        public string ScheduleTime { get; set; }

        [Display(Name = "Day and Time")]
        public DateTime TimeSchedule { get; set; }

        [Display(Name = "Rate")]
        public double ScheduleRate { get; set; }

        [Display(Name = "Location")]
        public string ScheduleLocation { get; set; }
        public ListOfLocations LocationSchedule { get; set; }

        [Display(Name = "Course")]
        public string ScheduleCourse { get; set; }

        [Display(Name="Student")]
        public string ScheduleStudent { get; set; }

        [Display(Name = "Tutor")]
        public string ScheduleTutor { get; set; }
    }
}
