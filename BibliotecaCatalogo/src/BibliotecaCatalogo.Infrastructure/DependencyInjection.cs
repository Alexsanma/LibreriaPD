using BibliotecaCatalogo.Application.Common.Interfaces;
using BibliotecaCatalogo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BibliotecaCatalogo.Infrastructure;

/// <summary>
/// Registro de dependencias de la capa de Infraestructura.
/// Configura el DbContext con SQL Server y lo expone como IApplicationDbContext.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        // La capa de Aplicación depende de la abstracción, no del tipo concreto.
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
