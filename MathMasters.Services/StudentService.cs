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
                                    StudentName=e.LastName + "," + " "+ e.FirstName,
                                    StudentGradeLevel=e.GradeLevel
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
