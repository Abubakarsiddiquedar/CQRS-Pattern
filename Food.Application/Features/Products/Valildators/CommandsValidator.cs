using FluentValidation;
using Food.Application.Features.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application.Features.Products.Valildators
{
	public  class CommandsValidator : AbstractValidator<CreateProductCommand>
	{
		public CommandsValidator() 
		{
			RuleFor(x => x.Name)
				.NotNull()
				.NotEmpty().WithMessage("{PropertyName} is required")
				.Length(2, 10).WithMessage("{PropertyName} should be between 2 and 10");

			RuleFor(x => x.Rate)
				.NotNull()
				.NotEmpty().WithMessage("{PropertyName} is required")
				 .LessThan(500);
		}
	}
}
