using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class WorkPlace
    {
        [Key]
        public int WPId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Salary { get; set; }

        public int OvertimeBonus { get; set; }

        public int Hours { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}
