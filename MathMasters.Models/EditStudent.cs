using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Models
{
    public class EditStudent
    {
        [Display(Name = "ID")]
        public int StudentId { get; set; }
        [Display(Name = "First Name")]
        public string StudentFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string StudentLastName { get; set; }
        [Display(Name = "Grade Level")]
        public int StudentGradeLevel { get; set; }
    }
}
