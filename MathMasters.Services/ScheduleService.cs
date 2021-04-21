using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMasters.Services
{
    class ScheduleService
    {
        private readonly Guid _userId;

        public ScheduleService(Guid userId)
        {
            _userId = userId;
        }
    }
}
