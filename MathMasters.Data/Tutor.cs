using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Data
{
    public enum ListOfTimes
    {
        MonWed1530,
        MonWed1730,
        TuesThurs1530,
        TuesThurs1730,
        Sat1100,
        Sat1300
    }

    public enum ListOfLocations
    {
        Library,
        CommunityCenter,
        School
    }
    public class Tutor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Available Times")]
        public List<ListOfTimes> Time { get; set; }
        [Required]
        [Display(Name = "Location")]
        public ListOfLocations Location { get; set; }
        [Required]
        [Display(Name = "Courses")]
        public virtual ICollection<Course> CourseList { get; set; }
    }
}
