using MathMasters.Data;
using MathMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Services
{
    public class ScheduleService
    {
        private readonly Guid _userId;

        public ScheduleService(Guid userId)
        {
            _userId = userId;
        }
        public IEnumerable<AllScheduleList> GetAllSchedules()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Schedules
                        .Select(
                            e =>
                                new AllScheduleList
                                {
                                    ScheduleId = e.Id,
                                    ScheduleCourse = e.Course.Name,
                                    ScheduleStudent = e.Student.LastName + ", " + e.Student.FirstName,
                                    ScheduleDate = e.Time
                                }
                        );

                return query.ToArray();
            }
        }
        //Create new schedule

        public bool CreateSchedule(CreateSchedule model)
        {
            var tutorList = GetTutorByLocation(model.ScheduleLocation);
            model.ScheduleRate = 20;
            var entity =
                new Schedule()
                {
                    StudentId = model.ScheduleStudentID,
                    TutorId = model.ScheduleTutorID,
                    CourseId = model.ScheduleCourseID,
                    Time = model.ScheduleDate,
                    Rate = model.ScheduleRate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Schedules.Add(entity);
                return ctx.SaveChanges() > 1;
            }
        }

        //Get All tutors

        public List<Tutor> GetTutorByLocation(ListOfLocations location)
        {
            var tList = new List<Tutor>();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tutors
                        .Where(e => e.Location == location);

                        foreach (Tutor tutor in entity)
                        {
                            tList.Add(tutor);
                        }
                    return tList;
            }
        }
        public List<Course> AllCourses()
        {
            var cList = new List<Course>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Courses;
                foreach (Course course in query)
                {
                    cList.Add(course);
                }
                return cList;
            }
        }
    }
}
