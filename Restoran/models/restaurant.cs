using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        public string TelOfficial { get; set; }

        public DateTime OpeningDate { get; set; }

        public DateTime? ClosingDate { get; set; }

        public int GeneralEmployeeNo { get; set; }

        public List<Owner> Owners { get; set; }

        public List<RestaurantUnit> RestaurantUnits { get; set; }
    }
}
