﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application;
public static class Installer
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());// Aca levanta todos los handler que hereden de IRequestHandler
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());// todos los que hereden de Profile
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
       
    }
}
