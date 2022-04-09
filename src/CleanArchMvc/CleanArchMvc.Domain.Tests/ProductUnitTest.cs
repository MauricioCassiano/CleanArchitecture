using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Criando Produto com Status valido")]
        public void CreateProduct_WithValidParameters_ResultObjValidState()
        {
            Action action = () => new Product(1, "Product 01","Product description", 10,5,"image");
            action.Should()
               .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando Produto com Status valido sem id")]
        public void CreateProduct_WithValidParametersMissingId_ResultObjValidState()
        {
            Action action = () => new Product("Product 01", "Product description", 10, 5, "image");
            action.Should()
               .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando Produto com Status valido sem id")]
        public void CreateProduct_MissingWithImageParameters_ResultObjValidState()
        {
            Action action = () => new Product("Product 01", "Product description", 10, 5, null);
            action.Should()
               .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Criando Produto com nome em branco")]
        public void CreateProduct_MissingNameParameter_ResultObjinvalidState()
        {
            Action action = () => new Product("", "Product description", 10, 5, "image"); ;
            action.Should()
               .Throw<DomainExceptionValidation>()
               .WithMessage("Name is Required");
        }

        [Fact(DisplayName = "Criando Produto com nome em branco")]
        public void CreateProduct_MissingDescriptionParameter_ResultObjinvalidState()
        {
            Action action = () => new Product("Product", "", 10, 5, "image"); ;
            action.Should()
               .Throw<DomainExceptionValidation>()
               .WithMessage("Description is Required");
        }


        [Theory]
        [InlineData(-5)]
        public void CreateProduct_NegativeStockParameter_ResultObjinvalidState(int value)
        {
            Action action = () => new Product("Product 01", "Product description", 10, value, "image"); ;
            action.Should()
               .Throw<DomainExceptionValidation>()
               .WithMessage("Invalid stock value");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_NegativePriceParameter_ResultObjinvalidState(int value)
        {
            Action action = () => new Product("Product 01", "Product description", value, 5, "image"); ;
            action.Should()
               .Throw<DomainExceptionValidation>()
               .WithMessage("Invalid price value");
        }

    }
}
