using FluentValidation;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x=>x.Adress).NotNull();
            RuleFor(x=>x.Adress).MinimumLength(1);
            RuleFor(x => x.Adress).MaximumLength(50);
            RuleFor(x => x.PhoneNumber).Length (11,11);
            RuleFor(x => x.FirstName).MaximumLength(25);
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).MaximumLength(25);
        }
    }
}
