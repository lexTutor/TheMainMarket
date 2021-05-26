using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.Core.Specifications
{
    public interface ISpecification<TModel> where TModel : class
    {
        Expression<Func<TModel, bool>> Criteria { get; }
        List<Expression<Func<TModel, object>>> Includes { get; }
        public List<Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>>> IncludeWithThenInclude { get;}
        Expression<Func<TModel, object>> OrderByAsc { get; }
        Expression<Func<TModel, object>> OrderByDesc { get; }
        int Take { get;  }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
