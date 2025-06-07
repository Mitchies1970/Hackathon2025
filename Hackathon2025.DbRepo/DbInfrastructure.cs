using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon2025.DbRepo
{
    public static class DbInfrastructure
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Hackathon2025.DbRepo.Data.HackathonDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<Query>();
            
            return services;
        }
    }
}
