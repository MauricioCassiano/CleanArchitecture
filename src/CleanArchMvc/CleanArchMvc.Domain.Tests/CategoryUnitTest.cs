using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;


using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName ="Criando Categoria com Status valido")]
        public void CreateCategory_WithValidParameters_ResultObjValidState() 
        {
             Action action = () => new Category(1, "Category Name");
            action.Should()
               .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando Categoria com Status valido")]
        public void CreateCategory_WithOnlyNameParameters_ResultObjValidState()
        {
            Action action = () => new Category("Category Name");
            action.Should()
               .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando Categoria com Id invalido")]
        public void CreateCategory_NegativeIdParameter_ResultObjinvalidState()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
               .Throw<DomainExceptionValidation>()
               .WithMessage("Invalid value");
        }

        [Fact(DisplayName = "Criando Categoria com nome curto")]
        public void CreateCategory_WithNameShort_ResultObjValidState()
        {
            Action action = () => new Category("Ca");
            action.Should()
               .Throw<DomainExceptionValidation>()
               .WithMessage("Name is too short");
        }

        [Fact(DisplayName = "Criando Categoria com nome em branco")]
        public void CreateCategory_WithMissingName_ResultObjValidState()
        {
            Action action = () => new Category("");
            action.Should()
               .Throw<DomainExceptionValidation>()
               .WithMessage("Name is Required");
        }
    }
}
