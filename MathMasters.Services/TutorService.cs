using MathMasters.Data;
using MathMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Services
{
    public class TutorService
    {
        private readonly Guid _userId;

        public TutorService(Guid userId)
        {
            _userId = userId;
        }
        //Create new tutor
        public bool CreateTutor(CreateTutor model)
        {
            var newList = new List<ListOfTimes>(1) { model.TutorTime };
            var entity =
                new Tutor()
                {
                    FirstName = model.TutorFirstName,
                    LastName = model.TutorLastName,
                    Time = newList,
                    Location = model.TutorLocation
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tutors.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }
        //Get All tutors
        public IEnumerable<AllTutorList> GetAllTutors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tutors
                        .Select(
                            e =>
                                new AllTutorList
                                {
                                    TutorId = e.Id,
                                    TutorName = e.LastName + "," + " " + e.FirstName
                                }
                        );

                return query.ToArray();
            }
        }
        //Get course by ID
        public DetailTutor GetTutorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<string> cList = new List<string>();
                var entity =
                    ctx
                        .Tutors
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
                    new DetailTutor
                    {
                        TutorId = entity.Id,
                        TutorFirstName = entity.FirstName,
                        TutorLastName = entity.LastName,
                        //TutorCourseList = 
                        //TutorStudentList =
                        //TutorScheduleList =
                    };
            }
        }
        public bool UpdateTutor(EditTutor model)
        {
            //List<string> cList = new List<string>();
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Tutors
                        .Single(e => e.Id == model.TutorId);
                entity.FirstName = model.TutorFirstName;
                entity.LastName = model.TutorLastName;
                //entity.CourseList = model.TutorCourseList;
                return ctx.SaveChanges() > 0;
            }
        }
        public bool DeleteTutor(int tutorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tutors
                        .Single(e => e.Id == tutorId);

                ctx.Tutors.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
