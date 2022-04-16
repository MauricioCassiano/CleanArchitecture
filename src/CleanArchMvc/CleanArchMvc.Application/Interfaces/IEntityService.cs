using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public  interface IEntityService<TEntity, TEntityDTO, TRepository>
        where TEntity : class, IEntity
        where TEntityDTO : class, IEntityDTO
        where TRepository : class, IEntityRepository<TEntity>
    {
        Task<IEnumerable<TEntityDTO>> GetListAsync();
        Task<TEntityDTO> GetByIdAsync(int? id);
        Task CreateAsync(TEntityDTO entity);
        Task UpdateAsync(TEntityDTO entity);
        Task RemoveAsync(int? id);

    }
}
