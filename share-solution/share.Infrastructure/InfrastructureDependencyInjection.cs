using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using share.Application.Interfaces.Services;
using share.Infrastructure.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Các config khác...
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
