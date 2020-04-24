using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        
        public int OvertimeHours { get; set; } 

        public RestaurantUnit RestaurantUnit { get; set; }

        public Shift Shift { get; set; }

        public WorkPlace WorkPlace { get; set; }
        public String Id { get; set; }
        public User User { get; set; }
        public List<User> Users { get; set; }
    }
}
