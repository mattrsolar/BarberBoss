using BarberBoss.Application.UseCases.Create;
using Microsoft.Extensions.DependencyInjection;


namespace BarberBoss.Application
{
    public static class DependencyInjectionExtension
    {

        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateBillingUseCase, CreateBillingUseCase>();
        }
    }
}
