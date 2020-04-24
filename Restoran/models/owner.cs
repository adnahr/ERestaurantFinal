using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }

        public Restaurant Restaurant { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Tel { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public DateTime? FireDate { get; set; }
    }
}
