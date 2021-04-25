using MathMasters.Data;
using MathMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Services
{
    public class StudentService
    {
        private readonly Guid _userId;

        public StudentService(Guid userId)
        {
            _userId = userId;
        }

        //Create new student
        public bool CreateStudent(CreateStudent model)
        {
            var entity =
                new Student()
                {
                    FirstName = model.StudentFirstName,
                    LastName = model.StudentLastName,
                    GradeLevel = model.StudentGradeLevel
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Students.Add(entity);
                return ctx.SaveChanges() > 1;
            }
        }

        //Get All Students
        public IEnumerable<AllStudentList> GetAllStudents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Students
                        .Select(
                            e =>
                                new AllStudentList
                                {
                                    StudentId = e.Id,
                                    StudentName=e.LastName + "," + " "+ e.FirstName,
                                    StudentGradeLevel=e.GradeLevel
                                }
                        );

                return query.ToArray();
            }
        }
        //Get student by ID
        public DetailStudent GetStudentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<string> cList = new List<string>();
                var entity =
                    ctx
                        .Students
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
                    new DetailStudent
                    {
                        StudentId=entity.Id,
                        StudentFirstName=entity.FirstName,
                        StudentLastName=entity.LastName,
                        StudentGradeLevel=entity.GradeLevel
                        //StudentCourseList=,
                        //StudentTutorList
                        //StudentScheduleList

                    };
            }
        }
        public bool UpdateStudent(EditStudent model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Students
                        .Single(e => e.Id == model.StudentId);
                entity.FirstName = model.StudentFirstName;
                entity.LastName = model.StudentLastName;
                entity.GradeLevel = model.StudentGradeLevel;
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
