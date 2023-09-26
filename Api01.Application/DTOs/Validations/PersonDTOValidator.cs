using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api01.Application.DTOs.Validations;

//fluent joga essa mensagem dentro do ResultSerice
public class PersonDTOValidator : AbstractValidator<PersonDTO>
{
	public PersonDTOValidator()
	{
		RuleFor(x => x.Document)
			.NotEmpty()
			.NotNull()
			.WithMessage("Document deve ser informado!");

		RuleFor(x => x.Name)
			.NotEmpty()
			.NotNull()
			.WithMessage("Name deve ser informado!");

		RuleFor(x => x.Phone)
			.NotEmpty()
			.NotNull()
			.WithMessage("Phone deve ser informado!");
	}
}
