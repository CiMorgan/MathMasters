using MathMasters.Data;
using MathMasters.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                return ctx.SaveChanges() > 0;
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
            string FirstName = "";
            string LastName = "";
            int Grade = 0;
            List<int> cListint = new List<int>();
            List<string> cList = new List<string>();
            List<string> dList = new List<string>();
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Students
                        .Single(e => e.Id == id);
                FirstName = entity.FirstName;
                LastName = entity.LastName;
                Grade = entity.GradeLevel;
            }
            using (var ctxSch = new ApplicationDbContext())
            {
                var entitySch =
                    ctxSch
                        .Schedules
                        .Where(e => e.StudentId == id);
                if (entitySch != null)
                {
                    foreach (var schedule in entitySch)
                    {
                        cListint.Add(schedule.CourseId);
                        dList.Add(schedule.Id + "-" + schedule.Time.ToString("D", CultureInfo.CreateSpecificCulture("en-US")) + "   ");
                    }
                }
            }
            foreach (var number in cListint)
            {
                using (var ctxst = new ApplicationDbContext())
                {
                    var entitySt =
                        ctxst
                            .Courses
                            .Single(g => g.Id == number);
                    cList.Add(entitySt.Id + "-" + entitySt.Name + "    ");
                }
            }
            return
                    new DetailStudent
                    {
                        StudentId=id,
                        StudentFirstName=FirstName,
                        StudentLastName=LastName,
                        StudentGradeLevel=Grade,
                        StudentCourseList=cList,
                        StudentScheduleList=dList
                    };
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
        public bool DeleteStudent(int studentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Students
                        .Single(e => e.Id == studentId);

                ctx.Students.Remove(entity);

                return ctx.SaveChanges() >0 ;
            }
        }
    }
}
