﻿using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Andreani.Errors.Extensions.ServiceBuilder
{
    [ExcludeFromCodeCoverage]
    public static class ServiceBuilderExtencion
    {
        public static void AddErrorManager(this IServiceCollection services)
        {
            services.AddSingleton(new ErrorManagerConfiguration().Configure(new ErrorManager()));
        }
    }
}
