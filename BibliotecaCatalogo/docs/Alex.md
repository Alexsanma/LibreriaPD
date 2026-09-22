# Alexander — Base compartida e integración

Tu parte es el **esqueleto** sobre el que trabajan los demás. Ya está construida en este repo;
aquí queda documentado qué incluye y los pasos que te corresponden para dejar `main` funcionando.

## Qué construiste
- Solución `.sln` con 4 proyectos y la regla de dependencias de Clean Architecture.
- **Domain**: `BaseEntity`, `Book`, `Author`, `Category`.
- **Application (común)**: `IApplicationDbContext`, `DependencyInjection` (MediatR).
- **Infrastructure**: `ApplicationDbContext`, configuraciones EF Core y datos semilla (`HasData`).
- **WebApi**: `Program.cs`, `BooksController` (3 endpoints cableados), Swagger, `appsettings`.

## Tus pasos (una sola vez)

1. Instala la herramienta EF (si no la tienes):
   ```bash
   dotnet tool install --global dotnet-ef
   ```
2. Restaura y compila para verificar que todo cierra:
   ```bash
   dotnet restore
   dotnet build
   ```
3. Crea la **migración inicial** (crea el esquema + los datos semilla):
   ```bash
   dotnet ef migrations add InitialCreate -p src/BibliotecaCatalogo.Infrastructure -s src/BibliotecaCatalogo.WebApi
   ```
   Esto genera la carpeta `src/BibliotecaCatalogo.Infrastructure/Migrations/` — **súbela al repo**.
4. Ejecuta y prueba:
   ```bash
   dotnet run --project src/BibliotecaCatalogo.WebApi
   ```
   Abre `https://localhost:7080/swagger`. Los endpoints existen; los de Sara/Robledo/Tobón
   responderán error hasta que implementen su handler (es lo esperado).
5. Sube a GitHub y avisa al equipo para que hagan `git pull` y empiecen su parte.

## Nota
`Program.cs` llama a `context.Database.Migrate()` al iniciar: una vez que la migración está en el
repo, cualquiera que clone solo tiene que ejecutar y la base se crea y se siembra sola.
