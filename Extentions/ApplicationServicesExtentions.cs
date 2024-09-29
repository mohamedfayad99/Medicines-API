using EMedicineBE.DBContext;
using EMedicineBE.Services;
using Microsoft.EntityFrameworkCore;

namespace EMedicineBE.Extentions
{
    public static class ApplicationServicesExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration) {

            services.AddDbContext<ApplicationDB>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped<IMedicinesRepository, MedicinesRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());          //  services.AddScoped<IMedicinesRepository, MedicinesRepository>();

            return services;
        }
    }
}
