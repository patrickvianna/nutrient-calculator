using nutrienteCalculator.App.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace nutrienteCalculator.App.Interfaces.Repository
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> InsertAsync(T iten);
        Task<T> UpdateAsync(T iten);
        Task<T> SaveAsync(T iten);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        IQueryable<T> SelectByCondition(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
    }
}
