using CleanArchitecture.Application.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.ApplicationRegistrar
{
    public static class ApplicationRegistrar
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(typeof(ApplicationRegistrar).Assembly);
                conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            // FluentValidation
            services.AddValidatorsFromAssembly(typeof(ApplicationRegistrar).Assembly);

            return services;
        }
    }
}