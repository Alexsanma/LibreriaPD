using BibliotecaCatalogo.Application;
using BibliotecaCatalogo.Infrastructure;
using BibliotecaCatalogo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- Registro de capas (Clean Architecture) ---
builder.Services.AddApplication();                       // MediatR + casos de uso (CQRS)
builder.Services.AddInfrastructure(builder.Configuration); // EF Core + SQL Server

// --- Servicios web ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Aplica las migraciones pendientes y crea/siembra la base de datos al iniciar.
// (Requiere haber creado antes la migración inicial: ver README.)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
