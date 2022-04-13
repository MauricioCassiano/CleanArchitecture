using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public Product(string name, string description, decimal price, int stock, string image)
            : this (0, name, description, price, stock, image)
        { }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(id, name, description, price, stock, image);
        }
        public void Update(string name)
        {
            ValidationDomain(this.Id, name, this.Description, this.Price, this.Stock, this.Image);
        }
        private void ValidationDomain(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid value");

            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is Required");

            DomainExceptionValidation.When(name.Length < 3, "Name is too short");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is Required");

            DomainExceptionValidation.When(description.Length < 5, "Description is too short");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image?.Length > 250 , "image is too long, max 250 characters");

            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;

        }
    }
}
