# Biblioteca – Catálogo (Seguimiento 1)

Sistema de consulta del catálogo de una biblioteca (libros, autores y categorías),
construido con **Clean Architecture + DDD + CQRS**, persistencia en **SQL Server con EF Core**
y expuesto como **API REST**.

> Solo lectura: para esta primera versión **no** se registra, modifica ni elimina información.

## Casos de uso (CQRS)

| # | Caso de uso | Endpoint | Responsable |
|---|-------------|----------|-------------|
| 1 | Consultar todos los libros | `GET /api/books` | **Sara** |
| 2 | Consultar un libro por ID | `GET /api/books/{id}` | **Robledo** |
| 3 | Consultar libros por categoría | `GET /api/books/category/{categoryId}` | **Tobón** |
| — | Base compartida (Domain, Infraestructura, host, wiring) | — | **Alexander** |

La repartición detallada está en [`docs/DISTRIBUCION.md`](docs/DISTRIBUCION.md), y cada quien tiene su guía:
[Alex](docs/Alex.md) · [Sara](docs/Sara.md) · [Robledo](docs/Robledo.md) · [Tobón](docs/Tobon.md).

## Arquitectura

Regla de dependencias (hacia adentro): **WebApi → Infrastructure → Application → Domain**.

```
src/
├── BibliotecaCatalogo.Domain          # Entidades y reglas del negocio (sin dependencias)
│   ├── Common/BaseEntity.cs
│   └── Entities/                       # Book, Author, Category
├── BibliotecaCatalogo.Application      # Casos de uso (CQRS con MediatR)
│   ├── Common/Interfaces/              # IApplicationDbContext (abstracción de datos)
│   └── Books/Queries/
│       ├── GetAllBooks/                # Query 1  (Sara)
│       ├── GetBookById/                # Query 2  (Robledo)
│       └── GetBooksByCategory/         # Query 3  (Tobón)
├── BibliotecaCatalogo.Infrastructure   # EF Core + SQL Server (implementa IApplicationDbContext)
│   └── Persistence/                    # ApplicationDbContext, Configurations, seed (HasData)
└── BibliotecaCatalogo.WebApi           # API REST (punto de entrada / composición)
    └── Controllers/BooksController.cs
```

**¿Por qué así?**
- **Domain** no conoce EF Core ni la web: solo el negocio.
- **Application** define *qué* se consulta (queries + handlers) y depende de la abstracción `IApplicationDbContext`, no de SQL Server.
- **Infrastructure** decide *cómo* se persiste (EF Core + SQL Server) e implementa esa abstracción.
- **WebApi** solo recibe la petición HTTP y delega en MediatR (`ISender.Send`).

## Requisitos

- .NET SDK **8.0**
- SQL Server (vale **LocalDB**, que viene con Visual Studio) o SQL Server Express/Developer
- Herramienta EF Core: `dotnet tool install --global dotnet-ef`

## Puesta en marcha

1. **Clonar** y abrir `BibliotecaCatalogo.sln` en Visual Studio (o usar la CLI).

2. **Cadena de conexión** — por defecto usa LocalDB (ver `src/BibliotecaCatalogo.WebApi/appsettings.json`):
   ```
   Server=(localdb)\MSSQLLocalDB;Database=BibliotecaCatalogo;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True
   ```
   Si usas otra instancia, cámbiala ahí (p. ej. `Server=localhost;...;User Id=sa;Password=TuClave;`).

3. **Crear la migración inicial** (una sola vez; la hace **Alex** y se sube al repo):
   ```bash
   dotnet ef migrations add InitialCreate -p src/BibliotecaCatalogo.Infrastructure -s src/BibliotecaCatalogo.WebApi
   ```

4. **Ejecutar la API** (aplica migraciones y siembra datos automáticamente al iniciar):
   ```bash
   dotnet run --project src/BibliotecaCatalogo.WebApi
   ```
   > Si ya existe la migración en el repo, no hace falta el paso 3: al ejecutar, la base se crea y se llena sola.

5. **Probar** en Swagger: `https://localhost:7080/swagger`.

## Datos de ejemplo (semilla)

Se cargan automáticamente 4 autores, 4 categorías y 7 libros (ver `Persistence/Configurations`).
Ejemplos para probar los endpoints:
- `GET /api/books` → los 7 libros.
- `GET /api/books/5` → *Clean Code*.
- `GET /api/books/category/2` → libros de *Fantasía* (El Hobbit, El Señor de los Anillos).

## Estado de las partes

- [x] Base compartida (Alex): Domain, Infraestructura, host, controller, seed.
- [ ] Query 1 – Todos los libros (Sara): `GetAllBooksQueryHandler`.
- [ ] Query 2 – Libro por ID (Robledo): `GetBookByIdQueryHandler`.
- [ ] Query 3 – Libros por categoría (Tobón): `GetBooksByCategoryQueryHandler`.

Cada handler pendiente tiene un `// TODO` con los pasos y la consulta sugerida, y la solución
de referencia en su archivo de `docs/`.

## Flujo de trabajo con Git

Cada quien trabaja en su rama y abre Pull Request a `main`:
```bash
git checkout -b feature/query1-sara      # (o query2-robledo, query3-tobon)
# ...implementar tu handler...
git add .
git commit -m "feat(books): implementa Query 1 - consultar todos los libros"
git push -u origin feature/query1-sara
```
Como cada quien toca un archivo distinto (su handler), **no hay conflictos** entre las partes.
