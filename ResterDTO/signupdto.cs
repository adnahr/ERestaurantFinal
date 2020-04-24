using Restoran.models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SignUpDTO
{
    public class SignUpDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; } //Date of birth

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public RestaurantUnit RestaurantUnit { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }   

        public string Email { get; set; }
    }
}
