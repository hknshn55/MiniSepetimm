using FluentValidation;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.ValidationRules.FluentValidation
{
    public class PictureValidator:AbstractValidator<Picture>
    {
        public PictureValidator()
        {
            RuleFor(x => x.ProductId).NotNull();
        }
    }
}
