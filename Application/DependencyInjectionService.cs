using Application.Services.Persona;
using Microsoft.Extensions.DependencyInjection;


namespace Application
{
    public static class DependencyInjectionService
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            // Persona
            services.AddTransient<IPersonaServices, PersonaServices>();


            return services;
        }

    }
}
