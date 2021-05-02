using MathMasters.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Models
{
    public class AllScheduleList
    {
        public int ScheduleId { get; set; }

        [Display(Name = "Course")]
        public string ScheduleCourse { get; set; }

        [Display(Name = "Tutor")]
        public string ScheduleTutor { get; set; }

        [Display(Name = "Time and Date")]
        public DateTime ScheduleDate { get; set; }
    }
}
