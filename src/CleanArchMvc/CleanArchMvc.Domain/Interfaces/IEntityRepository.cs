using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IEntityRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<TEntity> GetByIdAsync(int? id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> RemoveAsync(TEntity entity);
    }
}
