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
                                    TutorName = e.LastName + "," + " " + e.FirstName
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
