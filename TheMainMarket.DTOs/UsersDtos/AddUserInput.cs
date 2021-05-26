using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMainMarket.DTOs.UsersDtos
{
    public class AddUserInput
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }

        public string UserName {
            get { return Email; }
            set { }
        }
    }
}
