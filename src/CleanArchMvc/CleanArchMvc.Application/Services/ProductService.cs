using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : EntityService<Product, ProductDTO, IProductRepository>, IProductService
    {
        public ProductService(IProductRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {}
        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(entity);
        }
    }
}
