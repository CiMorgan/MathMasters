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
                                    ScheduleTutor=e.Tutor.LastName,
                                    ScheduleDate = e.Time
                                }
                        );

                return query.ToArray();
            }
        }
        //Create a new tutoring session. Location selected first to allow selection of tutors from that location only.
        //public void CreateLibrary(CreateSchedule model)
        //{
        //    CreateSchedule(model);
        //}
        //public void CreateCenter(CreateSchedule model)
        //{
        //    CreateSchedule(model);
        //}
        //public void CreateSchool(CreateSchedule model)
        //{
        //    CreateSchedule(model);
        //}
        public bool CreateSchedule(CreateSchedule model)
        {
            int position = model.ScheduleTutorID.IndexOf("-");
            int tutorNum = Int32.Parse(model.ScheduleTutorID.Substring(0, position));
            int DaySelPos = model.ScheduleDay.IndexOf(":");
            string DaySel = model.ScheduleDay.Substring(DaySelPos - 1);
            int hour = 3;

            if (DaySel == "3:00") { hour = 3; };
            if (DaySel == "5:00") { hour = 5; };
            if (DaySel == "1:00") { hour = 1; };

            DateTime sch = new DateTime(model.ScheduleDate.Year, model.ScheduleDate.Month, model.ScheduleDate.Day, hour, 0, 0);

            model.ScheduleRate = 20;
            var entity =
                new Schedule()
                {
                    StudentId = model.ScheduleStudentID,
                    TutorId = tutorNum,
                    CourseId = model.ScheduleCourseID,
                    Time = sch,
                    Rate = model.ScheduleRate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Schedules.Add(entity);
                return ctx.SaveChanges() > 1;
            }
        }

        //Get All Schedules


    }
}
