using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Create;
using BarberBoss.Application.UseCases.GetAll;
using Microsoft.Extensions.DependencyInjection;


namespace BarberBoss.Application
{
    public static class DependencyInjectionExtension
    {

        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);

            AddUseCases(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(AutoMapping));
        }


        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateBillingUseCase, CreateBillingUseCase>();
            services.AddScoped<IGetAllBillingUseCase, GetAllBillingUseCase>();
        }
    }
}
