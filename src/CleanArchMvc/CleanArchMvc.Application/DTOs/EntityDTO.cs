using CleanArchMvc.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs
{
    public class EntityDTO : IEntityDTO
    {
        public int Id { get; set; }
    }
}
