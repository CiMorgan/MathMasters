using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Models
{
    public class AllTutorList
    {
        public int TutorId { get; set; }
        [Display(Name = "Tutor Name")]
        public string TutorName { get; set; }
    }
}
