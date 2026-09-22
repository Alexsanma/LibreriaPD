using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BibliotecaCatalogo.Application;

/// <summary>
/// Registro de dependencias de la capa de Aplicación.
/// Registra MediatR y escanea este ensamblado para descubrir
/// automáticamente todos los handlers de queries (CQRS).
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
