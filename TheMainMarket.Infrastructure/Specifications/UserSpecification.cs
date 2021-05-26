using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class UserSpecification: BaseSpecification<User>
    {
        public UserSpecification()
        {

        }

        public UserSpecification(string Id): base(User=> User.Id == Id)
        {
        }
    }
}
