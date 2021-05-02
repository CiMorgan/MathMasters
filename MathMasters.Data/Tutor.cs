using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Data
{
    public enum ListOfTimes
    {
        MonWed1500,
        MonWed1700,
        TuesThurs1500,
        TuesThurs1700,
        Sat1300,
        Sat1500
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
        [Display(Name = "Location")]
        public ListOfLocations Location { get; set; }

        [Display(Name = "Courses")]
        public virtual ICollection<Course> CourseList { get; set; }

        public Tutor()
        {
            CourseList = new HashSet<Course>();
        }
    }
}
