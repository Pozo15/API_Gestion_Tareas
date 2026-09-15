# MiPrimeraAPI - Sistema de Gestión de Tareas

API REST para gestión de tareas construida con ASP.NET Core 8 y Entity Framework Core.

## Descripción

Sistema de gestión de tareas que permite:
- CRUD de Usuarios, Tareas y Categorías
- Autenticación JWT (Login y Registro)
- Relaciones entre entidades
- Validaciones de datos
- Manejo global de errores

## Tecnologías

- **ASP.NET Core 8.0** - Framework web
- **Entity Framework Core 8.0** - ORM para base de datos
- **SQL Server** - Base de datos
- **JWT Bearer** - Autenticación
- **BCrypt** - Hash de contraseñas
- **Swagger** - Documentación de la API

## Estructura del Proyecto

```
MiPrimeraAPI/
├── Controllers/          # Endpoints de la API
│   ├── AuthController.cs       # Login y Registro
│   ├── UsuariosController.cs   # CRUD Usuarios
│   ├── TareasController.cs     # CRUD Tareas
│   └── CategoriasController.cs # CRUD Categorías
├── Data/
│   └── AppDbContext.cs    # Contexto de base de datos
├── Filters/
│   └── GlobalExceptionFilter.cs # Manejo de errores
├── Models/
│   ├── Usuario.cs         # Modelo de Usuario
│   ├── Tarea.cs           # Modelo de Tarea
│   ├── Categoria.cs       # Modelo de Categoría
│   └── LoginModel.cs      # Modelo para Login
├── Services/
│   └── JwtService.cs      # Servicio JWT
├── Migrations/            # Migraciones de EF Core
├── Program.cs             # Configuración principal
└── appsettings.json       # Configuración de la aplicación
```

## Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)

## Instalación

### 1. Clonar el repositorio

```bash
git clone https://github.com/TU-USUARIO/MiPrimeraAPI.git
cd MiPrimeraAPI
```

### 2. Instalar dependencias

```bash
dotnet restore
```

### 3. Configurar base de datos

Editar `appsettings.json` con tu cadena de conexión:

```json
{
  "ConnectionStrings": {
    "ConexionSQL": "Server=.;Database=MiPrimeraApiDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### 4. Ejecutar migraciones

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Ejecutar la API

```bash
dotnet run
```

La API estará disponible en: `https://localhost:7193`

## Endpoints

### Autenticación

| Método | Ruta | Descripción |
|--------|------|-------------|
| POST | `/api/auth/Register` | Registrar usuario |
| POST | `/api/auth/Login` | Iniciar sesión |

### Usuarios (requiere token)

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/usuarios` | Obtener todos los usuarios |
| GET | `/api/usuarios/{id}` | Obtener usuario por ID |
| POST | `/api/usuarios` | Crear usuario |
| PUT | `/api/usuarios/{id}` | Actualizar usuario |
| DELETE | `/api/usuarios/{id}` | Eliminar usuario |

### Tareas (requiere token)

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/tareas` | Obtener todas las tareas |
| GET | `/api/tareas/{id}` | Obtener tarea por ID |
| GET | `/api/tareas/pendientes` | Tareas pendientes |
| GET | `/api/tareas/urgentes` | Tareas con prioridad alta |
| GET | `/api/tareas/usuario/{id}` | Tareas de un usuario |
| POST | `/api/tareas` | Crear tarea |
| PUT | `/api/tareas/{id}` | Actualizar tarea |
| DELETE | `/api/tareas/{id}` | Eliminar tarea |

### Categorías (requiere token)

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/categorias` | Obtener todas las categorías |
| GET | `/api/categorias/{id}` | Obtener categoría por ID |
| POST | `/api/categorias` | Crear categoría |
| PUT | `/api/categorias/{id}` | Actualizar categoría |
| DELETE | `/api/categorias/{id}` | Eliminar categoría |

## Uso de la API

### 1. Registrar usuario

```http
POST /api/auth/Register
Content-Type: application/json

{
  "email": "usuario@email.com",
  "passwordHash": "mi contraseña"
}
```

### 2. Iniciar sesión

```http
POST /api/auth/Login
Content-Type: application/json

{
  "email": "usuario@email.com",
  "password": "mi contraseña"
}
```

Respuesta:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### 3. Usar endpoints protegidos

Agregar el header de autorización:
```
Authorization: Bearer [tu_token]
```

## Temas Aprendidos

- [x] Arquitectura de APIs REST
- [x] Entity Framework Core y Migraciones
- [x] CRUD completo
- [x] Autenticación JWT
- [x] Validaciones con Data Annotations
- [x] Manejo de errores con Filtros Globales
- [x] LINQ (consultas)
- [x] Git y GitHub

## Autor

Edwin Pozo - 2026

## Licencia

Este proyecto es academico.
