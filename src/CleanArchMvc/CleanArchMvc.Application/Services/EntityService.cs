using AutoMapper;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public abstract class EntityService<TEntity, TEntityDTO, TRepository> : IEntityService<TEntity, TEntityDTO, TRepository>
        where TEntity : class, IEntity
        where TEntityDTO : class, IEntityDTO
        where TRepository : class, IEntityRepository<TEntity>
    {
        protected readonly TRepository _repository;
        protected readonly IMapper _mapper;
        public EntityService(TRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<TEntityDTO>> GetListAsync()
        {
            var entity = await _repository.GetListAsync();
            return _mapper.Map<IEnumerable<TEntityDTO>>(entity);
        }

        public async Task<TEntityDTO> GetByIdAsync(int? id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TEntityDTO>(entity);
        }

        public async Task CreateAsync(TEntityDTO entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            await _repository.CreateAsync(entity);
        }

        public async Task UpdateAsync(TEntityDTO entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            await _repository.UpdateAsync(entity);
        }

        public async Task RemoveAsync(int? id)
        {
            var entity = _repository.GetByIdAsync(id).Result;
            await _repository.RemoveAsync(entity);
        }
    }
}
