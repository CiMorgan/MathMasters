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

            var entity =
                new Tutor()
                {
                    FirstName = model.TutorFirstName,
                    LastName = model.TutorLastName,
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
        public DetailTutor GetTutorById(int id)
        {
            string FirstName = "";
            string LastName = "";
            ListOfLocations location = new ListOfLocations();
            List<int> stListint = new List<int>();
            List<int> cListint = new List<int>();
            List<String> stList = new List<String>();
            List<String> cList = new List<string>();
            List<DateTime> dList = new List<DateTime>();
            using (var ctxSch = new ApplicationDbContext())
            {
                var entitySch =
                    ctxSch
                        .Schedules
                        .Where(e => e.TutorId == id);
                if (entitySch != null)
                {
                    foreach (var schedule in entitySch)
                    {
                        stListint.Add(schedule.StudentId);
                        cListint.Add(schedule.CourseId);
                        dList.Add(schedule.Time);
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
                            .Single(g => g.Id == number);
                    stList.Add(entitySt.LastName+", ");
                }
            }
            foreach (var number in cListint)
            {
                using (var ctxC = new ApplicationDbContext())
                {
                    var entityC =
                        ctxC
                            .Courses
                            .Single(h => h.Id == number);
                    cList.Add(entityC.Name+", ");
                }
            }
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tutors
                        .Single(f => f.Id == id);
                FirstName = entity.FirstName;
                LastName = entity.LastName;
                location = entity.Location;         
            }
            return
                    new DetailTutor
                    {
                        TutorId = id,
                        TutorFirstName = FirstName,
                        TutorLastName = LastName,
                        Location = location,
                        TutorCourseList = cList,
                        TutorStudentList = stList,
                        TutorScheduleList = dList
                    };                  
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
                entity.Location = model.Location; 
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
