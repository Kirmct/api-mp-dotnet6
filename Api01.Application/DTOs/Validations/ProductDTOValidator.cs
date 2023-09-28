using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api01.Application.DTOs.Validations;

public class ProductDTOValidator : AbstractValidator<ProductDTO>
{
    public ProductDTOValidator()
    {
        RuleFor(x => x.CodeErp)
            .NotEmpty()
            .NotNull()
            .WithMessage("CodeErp deve ser imformado!");

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name deve ser informado!");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price deve ser informado!");
                         
    }
}
