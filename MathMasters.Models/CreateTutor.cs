using MathMasters.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Models
{
    public class CreateTutor
    {
        [Required]
        [Display(Name = "First Name")]
        public string TutorFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string TutorLastName { get; set; }

        [Required]
        [Display(Name = "Location")]
        public ListOfLocations TutorLocation { get; set; }
    }
}
