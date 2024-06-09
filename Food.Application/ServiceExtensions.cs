using FluentValidation;
using Food.Application.Behaviour;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application
{
    public static class ServiceExtensions
	{
		public static void AddApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
		}
	}
}
