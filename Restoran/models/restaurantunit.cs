using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class RestaurantUnit
    {
        [Key]
        public int UnitId { get; set; }

        public string Tel { get; set; }

        public int EmployeeNo { get; set; }

        public DateTime OpeningDate { get; set; }

        public DateTime ClosingDate { get; set; }

        public int Capacity { get; set; }

        public Restaurant Restaurant { get; set; }

        //public int LocationFK { get; set; }
     
        public Location Location { get; set; }

        public List<UnitMenu> UnitMenus { get; set; }

        public List<Schedule> schedules { get; set; }

        public List<Bill> Bills { get; set; }

        public List<Order> Orders { get; set; }

        public List<User> Users { get; set; }

        public List<Table> Tables { get; set; }
    }
}
