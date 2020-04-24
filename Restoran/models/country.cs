using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class Country
    {
       [Key]
        public int CountryId { get; set; }

        [Required]
        [Column("CountryName")]
        public string Name { get; set; }

        public Location Location { get; set; }

    }
}
