using FluentValidation;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.Name).MaximumLength(2);
            RuleFor(x=>x.Name).MaximumLength(50);
            RuleFor(x=>x.Name).NotNull();
        }
    }
}
