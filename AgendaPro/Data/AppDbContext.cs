using AgendaPro.Models.Scheduling;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgendaPro.Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<Professional> Professionals { get; set; } = null!;
    public DbSet<Appointment> Appointments { get; set; } = null!;
    public DbSet<AppointmentStatus> AppointmentStatuses { get; set; } = null!;
    public DbSet<AppointmentType> AppointmentTypes { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.Price).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Service)
            .WithMany(s => s.Appointments!)
            .HasForeignKey(a => a.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public void Seed()
    {
        if (!Services.Any())
        {
            Services.AddRange(
                new Service { Name = "Consulta", Price = 100m },
                new Service { Name = "Vacinação", Price = 50m }
            );
        }

        if (!AppointmentStatuses.Any())
        {
            AppointmentStatuses.AddRange(
                new AppointmentStatus { Name = "Agendado" },
                new AppointmentStatus { Name = "Cancelado" },
                new AppointmentStatus { Name = "Concluído" }
            );
        }

        if (!AppointmentTypes.Any())
        {
            AppointmentTypes.AddRange(
                new AppointmentType { Name = "Presencial" },
                new AppointmentType { Name = "Online" }
            );
        }

        SaveChanges();
    }

}
