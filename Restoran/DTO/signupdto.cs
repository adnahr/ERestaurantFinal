using Restoran.models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Restoran.DTO
{
    public class SignUpDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; } //Date of birth

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public int RestaurantUnit { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }   

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
