using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TheMainMarket.Core.Specifications;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Specifications
{
    public sealed class SpecificationEvaluator<TModel> where TModel : class
    {
        public static IQueryable<TModel> EvaluateQuery(IQueryable<TModel> query, ISpecification<TModel> spec)
        {
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            if(spec.OrderByDesc != null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }
            if (spec.OrderByAsc != null)
            {
                query = query.OrderBy(spec.OrderByAsc);
            }
            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            query = spec.IncludeWithThenInclude.Aggregate(query, (current, include) => include(current));

            return query;
        }
    }
}
