using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Interfaces
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
