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
        [Display(Name = "Date")]
        public DateTime ScheduleDate { get; set; }
    }
}
