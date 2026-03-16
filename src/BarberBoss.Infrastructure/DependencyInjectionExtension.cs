using BarberBoss.Domain.Repositories;
using BarberBoss.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BarberBoss.Infrastructure.Context.Repositories;

namespace BarberBoss.Infrastructure
{  

    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBillingsWriteOnlyRepository, BillingsRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 45));


            services.AddDbContext<BarberBossDbContext>(options =>
                options.UseMySql(connectionString, serverVersion));
        }
    }
}
