using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.DTO
{
    public class RUDTO
    {
        public string Tel { get; set; }

        public int EmployeeNo { get; set; }

        public DateTime OpeningDate { get; set; }

        public DateTime ClosingDate { get; set; }

        public int Capacity { get; set; }
        
        public int RestaurantId { get; set; }

        public int LocationId { get; set; }

        
    }
}
