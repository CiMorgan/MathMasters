using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Data
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Rate")]
        public double Rate { get; set; }
        [Required]
        [Display(Name = "Day and Time")]
        public DateTime Time { get; set; }
        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("Tutor")]
        public int? TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
