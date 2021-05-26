using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TheMainMarket.Models
{
    public class User: IdentityUser, IBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public bool IsProfileCompleted { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        //Navigational properties
        public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Token> Tokens { get; set; }
    }
}
