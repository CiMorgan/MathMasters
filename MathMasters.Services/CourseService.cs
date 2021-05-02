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
                    Description = model.CourseDescription
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
                                    CourseId = e.Id,
                                    CourseName = e.Name
                                }
                        );

                return query.ToArray();
            }
        }
        //Get course by ID
        public DetailCourse GetCourseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<string> cList = new List<string>();
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.Id == id);
                //var entitySch =
                //    ctx
                //        .Schedules
                //        .Where(f => f.StudentId == id)
                //        .Select(f => f.Id).ToList();
                //if (entitySch != null)
                //{
                //    foreach (var schedule in entitySch)
                //    {
                //        //var courseName
                //    }
                //}
                return
                    new DetailCourse
                    {
                        CourseId = entity.Id,
                        CourseName = entity.Name,
                        CourseDescription = entity.Description
                        //CourseTutorList = 
                        //CourseStudentList =
                    };
            }
        }
        public bool UpdateCourse(EditCourse model)
        {
            //List<string> cList = new List<string>();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.Id == model.CourseId);
                entity.Name = model.CourseName;
                entity.Description = model.CourseDescription;
                return ctx.SaveChanges() > 0;
            }
        }
        public bool DeleteCourse(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.Id == courseId);

                ctx.Courses.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
