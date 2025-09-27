using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using proyecto_programacion.Models; // <-- ¡ESTA ES LA LÍNEA QUE FALTABA!

namespace proyecto_programacion.Data;

// CAMBIO CLAVE:
// Heredamos de 'IdentityDbContext<Usuario>' en lugar de 'DbContext'.
// Esto le añade a nuestro contexto todas las tablas necesarias para manejar
// usuarios, roles, claims, etc., de forma automática.
public class ApplicationDbContext : IdentityDbContext<Usuario>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Tus tablas existentes para la gestión de activos se quedan exactamente igual.
    public DbSet<Activo> Activos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Ubicacion> Ubicaciones { get; set; }
}

