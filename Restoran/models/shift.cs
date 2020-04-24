using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }

        public string Name { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public List<Schedule> Schedules { get; set; }

        public List<User> Users { get; set; }
    }
}
