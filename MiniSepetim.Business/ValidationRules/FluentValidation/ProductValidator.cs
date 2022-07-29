using FluentValidation;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100);
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.SellerId).NotNull();
        }
    }
}
