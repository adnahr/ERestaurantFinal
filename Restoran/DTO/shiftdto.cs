using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.DTO
{
    public class ShiftDTO
    {
        public string  Name { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public int Seconds { get; set; }

        public int HoursEnd { get; set; }

        public int MinutesEnd { get; set; }

        public int SecondsEnd { get; set; }
    }
}
