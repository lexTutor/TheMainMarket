using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheMainMarket.Core.Repositories;
using TheMainMarket.Core.Specifications;
using TheMainMarket.DataAccess;
using TheMainMarket.Infrastructure.Specifications;
using TheMainMarket.Models;

namespace TheMainMarket.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>  : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> GetEntityBySpec(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<TEntity>> ListAllEntityBySpec(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity>.EvaluateQuery(_context.Set<TEntity>().AsQueryable(), spec);
        }

        public IQueryable<TEntity> ReturnProds()
        {
            return _context.Set<TEntity>();
        }
        public async Task<bool> DeleteAll(Expression<Func<TEntity, bool>> predicate)
        {
            var entitiesToDelete = _context.Set<TEntity>().Where(predicate).AsQueryable();
            _context.Set<TEntity>().RemoveRange(entitiesToDelete);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> AddEntity(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEntity(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddRangeAsync(ICollection<TEntity> entities)
        {
           _context.Set<TEntity>().AddRange(entities);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateEntity(TEntity entity)
        {
             _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}