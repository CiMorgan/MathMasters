using MathMasters.Data;
using MathMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Services
{
    public class CourseService
    {
        private readonly Guid _userId;

        public CourseService(Guid userId)
        {
            _userId = userId;
        }
        //Create new student
        public bool CreateCourse(CreateCourse model)
        {
            var newList = new List<ListOfTimes>(1) { model.CourseTime };
            var entity =
                new Course()
                {
                    Name = model.CourseName,
                    Description = model.CourseDescription,
                    Time = newList
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Courses.Add(entity);
                return ctx.SaveChanges() > 1;
            }
        }
        //Get All Courses
        public IEnumerable<AllCourseList> GetAllCourses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Courses
                        .Select(
                            e =>
                                new AllCourseList
                                {
                                    CourseName = e.Name
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
