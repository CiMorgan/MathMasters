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
                return ctx.SaveChanges() > 0;
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
            string Name = "";
            string Desc = "";
            List<int> stListint = new List<int>();
            List<int> tListint = new List<int>();
            List<String> stList = new List<String>();
            List<String> tList = new List<string>();
            using (var ctxSch = new ApplicationDbContext())
            {
                var entity =
                    ctxSch.Courses.Single(d => d.Id == id);
                Name = entity.Name;
                Desc = entity.Description;
            }
            using (var ctxSch = new ApplicationDbContext())
            {
                var entitySch =
                    ctxSch
                        .Schedules
                        .Where(e => e.CourseId == id);
                if (entitySch != null)
                {
                    foreach (var schedule in entitySch)
                    {
                        if (stListint.IndexOf(schedule.StudentId) == -1)
                        {
                            stListint.Add(schedule.StudentId);
                        }
                        if (stListint.IndexOf(schedule.TutorId) == -1)
                        {
                            tListint.Add(schedule.TutorId);
                        }                            
                    }
                }
            }
            foreach (var number in stListint)
            {
                using (var ctxst = new ApplicationDbContext())
                {
                    var entitySt =
                        ctxst
                            .Students
                            .Single(f => f.Id == number);
                    stList.Add(entitySt.Id+"-"+entitySt.LastName+", "+entitySt.FirstName+"    ");
                }
            }
            foreach (var number in tListint)
            {
                using (var ctxT = new ApplicationDbContext())
                {
                    var entityT =
                        ctxT
                            .Tutors
                            .Single(g => g.Id == number);
                    tList.Add(entityT.Id + "-" + entityT.LastName + ", " + entityT.FirstName+"    ");
                }
            }

           return
                new DetailCourse
                {
                    CourseId = id,
                    CourseName = Name,
                    CourseDescription = Desc,
                    CourseTutorList = tList,
                    CourseStudentList = stList
                };
        }
        public bool UpdateCourse(EditCourse model)
        {
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
