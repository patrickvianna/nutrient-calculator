using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nutrienteCalculator.App.Data.Context;
using nutrienteCalculator.App.Entities.Models;
using nutrienteCalculator.App.Interfaces.Repository;

namespace nutrienteCalculator.App.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected DataContext Context { get; set; }

        private DbSet<T> _dataset;

        public Repository(DataContext repositoryContext)
        {
            Context = repositoryContext;
            _dataset = Context.Set<T>();
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                    return false;

                _dataset.Remove(result);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T iten)
        {
            try
            {
                if (iten.Id == Guid.Empty)
                    iten.Id = Guid.NewGuid();

                iten.CreateAt = DateTime.UtcNow;
                await _dataset.AddAsync(iten);

                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iten;
        }

        public async Task<T> UpdateAsync(T iten)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(iten.Id));
                if (result == null)
                    return null;

                iten.UpdateAt = DateTime.UtcNow;
                iten.CreateAt = result.CreateAt;

                Context.Entry(result).CurrentValues.SetValues(iten);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iten;
        }

        public async Task<T> SaveAsync(T iten)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(iten.Id));
                if (result == null)
                {
                    iten.Id = Guid.NewGuid();

                    iten.CreateAt = DateTime.UtcNow;
                    await _dataset.AddAsync(iten);
                }
                else
                {
                    iten.UpdateAt = DateTime.UtcNow;
                    iten.CreateAt = result.CreateAt;

                    Context.Entry(result).CurrentValues.SetValues(iten);
                }
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iten;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> SelectByCondition(Expression<Func<T, bool>> expression)
        {
            return _dataset.Where(expression).AsNoTracking();
        }
    }
}
