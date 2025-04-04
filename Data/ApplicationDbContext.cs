using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Examen_parcia2.Models;

namespace Examen_parcia2.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<Campaña> Campaña { get; set; } 

public DbSet<Metrica> Metrica { get; set; } 

public DbSet<Objetivo> Objetivo { get; set; }

public DbSet<Presupuesto> Presupuesto { get; set; } 

public DbSet<Resultado> Resultado { get; set; }
}
