using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get;  set; }

        public Category(string name)
            : this(0, name)
        { }

        public Category(int id, string name)
        {
            ValidationDomain(id, name);
        }

        public void Update(string name)
        {
            ValidationDomain(this.Id, name);
        }

        private void ValidationDomain(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid value");

            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is Required");

            DomainExceptionValidation.When(name.Length < 3, "Name is too short");

            Id = id;
            Name = name;
        }
    }
}
