using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Infra.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService : IEntityService<Product, ProductDTO, IProductRepository>
    {
        Task<ProductDTO> GetProductCategoryAsync(int? id);
    }
}
