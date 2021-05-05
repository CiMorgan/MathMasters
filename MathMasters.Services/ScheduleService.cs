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
    public class ScheduleService
    {
        private readonly Guid _userId;

        public ScheduleService(Guid userId)
        {
            _userId = userId;
        }
        //Get All Schedules for Index View
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
        //Create a new schedule - separated by location in Controller
        public bool CreateSchedule(CreateSchedule model)
        {
            int position = model.ScheduleTutorID.IndexOf("-");
            int tutorNum = Int32.Parse(model.ScheduleTutorID.Substring(0, position));
            int coursePosition = model.ScheduleCourseID.IndexOf("-");
            int courseNum = Int32.Parse(model.ScheduleCourseID.Substring(0, coursePosition));
            int DaySelPos = model.ScheduleDay.IndexOf(":");
            string DaySel = model.ScheduleDay.Substring(DaySelPos - 1);
            int hour = 3;

            if (DaySel == "3:00") { hour = 15; };
            if (DaySel == "5:00") { hour = 17; };
            if (DaySel == "1:00") { hour = 13; };

            DateTime sch = new DateTime(model.ScheduleDate.Year, model.ScheduleDate.Month, model.ScheduleDate.Day, hour, 0, 0);

            model.ScheduleRate = 20;
            var entity =
                new Schedule()
                {
                    StudentId = model.ScheduleStudentID,
                    TutorId = tutorNum,
                    CourseId = courseNum,
                    Time = sch,
                    Rate = model.ScheduleRate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Schedules.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }
        //Get details of each scheduled tutoring session
        public DetailSchedule GetScheduleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schedules
                        .Single(e => e.Id == id);
                string location = Enum.GetName(typeof(ListOfLocations), entity.Tutor.Location);
                string studentName = entity.Student.LastName + ", " + entity.Student.FirstName;
                string tutorName = entity.Tutor.LastName + ", " + entity.Tutor.FirstName;
                string whenSchedule = entity.Time.ToString("f", CultureInfo.CreateSpecificCulture("en-US"));
                return
                    new DetailSchedule
                    {
                        ScheduleId = entity.Id,
                        ScheduleTime = whenSchedule,
                        TimeSchedule = entity.Time,
                        ScheduleRate = entity.Rate,
                        LocationSchedule = entity.Tutor.Location,
                        ScheduleLocation =location,
                        ScheduleCourse=entity.Course.Name,
                        ScheduleStudent=studentName,
                        ScheduleTutor = tutorName,
                    };
            }
        }
        //Update schedule
        public bool UpdateSchedule(EditSchedule model)
        {
            int position = model.ScheduleTutorID.IndexOf("-");
            int tutorNum = Int32.Parse(model.ScheduleTutorID.Substring(0, position));
            int coursePosition = model.ScheduleCourseID.IndexOf("-");
            int courseNum = Int32.Parse(model.ScheduleCourseID.Substring(0, coursePosition));
            int DaySelPos = model.ScheduleDay.IndexOf(":");
            string DaySel = model.ScheduleDay.Substring(DaySelPos - 1);
            int hour = 3;

            if (DaySel == "3:00") { hour = 15; };
            if (DaySel == "5:00") { hour = 17; };
            if (DaySel == "1:00") { hour = 13; };
            DateTime sch = new DateTime(model.ScheduleDate.Year, model.ScheduleDate.Month, model.ScheduleDate.Day, hour, 0, 0);

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schedules
                        .Single(e => e.Id == model.ScheduleId);
                entity.TutorId = tutorNum;
                entity.CourseId = courseNum;
                entity.Time = sch;
                return ctx.SaveChanges() > 0;
            }
        }
        //Delete schedule
        public bool DeleteSchedule(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schedules
                        .Single(e => e.Id == id);

                ctx.Schedules.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
