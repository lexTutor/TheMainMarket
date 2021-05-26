using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class CartSpecification: BaseSpecification<Cart>
    {
        public CartSpecification(string Id): base(Cart=> Cart.UserId == Id)
        {
            AddIncludeWithThenInclude(carts => carts
            .Include(cart => cart.CartProducts)
            .ThenInclude(cartProduct => cartProduct.Product)
            .ThenInclude(product=> product.Category));
        }
    }
}
