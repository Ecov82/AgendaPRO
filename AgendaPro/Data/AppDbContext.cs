using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AgendaPro.Models.Scheduling; // CORRETO para acessar Service, Appointment, etc.


namespace AgendaPro.Data;


public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<Appointment> Appointments { get; set; } = null!;
    public DbSet<AppointmentStatus> AppointmentStatuses { get; set; } = null!;
    public DbSet<AppointmentType> AppointmentTypes { get; set; } = null!;

    // Fix for IDE0290: Use primary constructor
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração para evitar truncamento no decimal Price
        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.Price).HasPrecision(18, 2);
        });

        // Relacionamento Appointment -> Service
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Service)
            .WithMany(static s => s.Appointments!) // Adicionado operador de null-forgiving para corrigir CS1662
            .HasForeignKey(a => a.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
