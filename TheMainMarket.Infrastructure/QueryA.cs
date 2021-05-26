using HotChocolate;
using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheMainMarket.Core.Repositories;
using TheMainMarket.DataAccess;
using TheMainMarket.Infrastructure.Repositories;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure
{
    public class QueryA
    {
        private readonly IGenericRepository<Product> _repo;

        public QueryA(IGenericRepository<Product> repo)
        {
            _repo = repo;
        }

        public async System.Threading.Tasks.Task<IReadOnlyList<Product>> GetProductsAsync([Service] AppDbContext context)
        {
            return await  _repo.ListAllEntityBySpec(new ProductSpecification());
        }
    }
}