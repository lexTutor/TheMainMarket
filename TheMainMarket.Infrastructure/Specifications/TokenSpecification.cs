using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class TokenSpecification: BaseSpecification<Token>
    {
        public TokenSpecification(string refreshToken):base(Token=> Token.RefreshToken == refreshToken)
        {

        }
    }
}
