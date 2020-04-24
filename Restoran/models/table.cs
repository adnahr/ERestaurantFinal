using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }

        public int NumOfChairs { get; set; }

        public TablePosition TablePosition { get; set; }

        public RestaurantUnit RestaurantUnit { get; set; }

        public User User { get; set; }
    }
}
