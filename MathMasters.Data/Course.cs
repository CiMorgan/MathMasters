using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public string Name { get; set; }
        [Display(Name = "Course Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Available Times")]
        public List<ListOfTimes> Time { get; set; }
        [Required]
        [Display(Name = "Courses")]
        public virtual ICollection<Tutor> TutorList { get; set; }
    }
}
