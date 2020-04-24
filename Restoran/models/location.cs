using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class Location
    {
        [Key]
        public int id { get; set; }

        public string StreetName { get; set; }

        public int StreetNo { get; set; }

        public string Description { get; set; }

        public int CountryFK { get; set;  }
        public Country Country { get; set; }

        public int CityFK { get; set; }
        public City City { get; set; }

    }
}
