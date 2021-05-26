using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TheMainMarket.Core.Specifications;

namespace TheMainMarket.Infrastructure.Specifications
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        public BaseSpecification()
        {
        }
        public BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>> Criteria { get; }

        public Expression<Func<TEntity, object>> OrderByAsc { get; private set; }
        public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }
        public List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> IncludeWithThenInclude { get; } = new List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>();
        protected void AddIncludeWithThenInclude(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> nestedInclude)
        {
            IncludeWithThenInclude.Add(nestedInclude);
        }
        protected void AddInclude(Expression<Func<TEntity, object>> include)
        {
            Includes.Add(include);
        }
        protected void AddOrderByAsc(Expression<Func<TEntity, object>> order)
        {
            OrderByAsc = order;
        }
        protected void AddOrderByDesc(Expression<Func<TEntity, object>> order)
        {
            OrderByDesc = order;
        }

        protected void ApplyPaging(int take, int skip)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
        }
    }
}