using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : EntityService<Category, CategoryDTO, ICategoryRepository>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository, IMapper mapper) 
            : base(repository, mapper)
        { }
    }
}
