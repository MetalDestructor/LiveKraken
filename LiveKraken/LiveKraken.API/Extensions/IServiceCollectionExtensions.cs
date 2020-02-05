using LiveKraken.DataServices;
using LiveKraken.DataServices.Interfaces;
using LiveKraken.Services;
using LiveKraken.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveKraken.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var authParams = configuration.GetSection("Jwt")
                .Get<AuthParameters>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStreamService, StreamService>();
            services.AddScoped<IAuthService>(x => new AuthService(authParams));
            services.AddSingleton<IAuthUtils, AuthUtils>();
        }
    }
}
