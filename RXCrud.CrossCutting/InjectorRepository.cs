using RXCrud.Data.Repositories;
using RXCrud.Domain.Interfaces.Data;
using Microsoft.Extensions.DependencyInjection;

namespace RXCrud.CrossCutting
{
    public static class InjectorRepository
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}