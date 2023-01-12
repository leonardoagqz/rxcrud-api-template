using RXCrud.Service.Services;
using RXCrud.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace RXCrud.CrossCutting
{
    public static class InjectorService
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}