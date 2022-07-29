using FluentValidation;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.ValidationRules.FluentValidation
{
    public class SellerValidator:AbstractValidator<Seller>
    {
        public SellerValidator()
        {
            RuleFor(x => x.Name).MaximumLength(60);
            RuleFor(x => x.Name).NotNull();
            
            

        }
    }
}
