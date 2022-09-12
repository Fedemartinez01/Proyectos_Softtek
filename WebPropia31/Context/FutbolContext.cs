using Microsoft.EntityFrameworkCore;
using System.Threading;
using WebPropia31.Models;

namespace WebPropia31.Context
{
    public class FutbolContext : DbContext
    {
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }

        public FutbolContext(DbContextOptions<FutbolContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tabla EQUIPO
            modelBuilder.Entity<Equipo>(equipo =>
            {
                equipo.ToTable("Equipo");

                // Relaciones
                equipo.HasKey(p => p.IdEquipo);

                // Propiedades
                // (Maximo de caracteres, campos requeridos, etc)
            });

            // Tabla JUGADOR
            modelBuilder.Entity<Jugador>(jugador =>
            {
                jugador.ToTable("Jugador");

                // Relacion con equipo (Nose si está bien)
                jugador.HasKey(p => p.IdJugador);
                jugador.HasOne(p => p.Equipo).WithMany(p => p.Jugadores).HasForeignKey(p => p.IdEquipo);
                

                // Propiedades
            });
        }
    }
}
