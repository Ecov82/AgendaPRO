using AgendaPro.Models;
using AgendaPro.Models.Scheduling;
using AgendaPro.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AgendaPro.Data;

public class AppDbContext : DbContext
{
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<Professional> Professionals { get; set; } = null!;
    public DbSet<Appointment> Appointments { get; set; } = null!;
    public DbSet<AppointmentStatus> AppointmentStatuses { get; set; } = null!;
    public DbSet<AppointmentType> AppointmentTypes { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

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

    // Método único de seed
    public void Seed()
    {
        // Criação do usuário mestre fixo
        if (!Users.Any(u => u.Email.ToLower() == "cleitoneco@gmail.com"))
        {
            Users.Add(new User
            {
                Name = "Administrador Mestre",
                Email = "cleitoneco@gmail.com",
                PasswordHash = PasswordHasher.ComputeHash("SenhaForte123!"),
                IsMaster = true
            });
        }

        // Seed de serviços
        if (!Services.Any())
        {
            Services.AddRange(
                new Service { Name = "Consulta", Price = 100m },
                new Service { Name = "Vacinação", Price = 50m }
            );
        }

        // Seed de status
        if (!AppointmentStatuses.Any())
        {
            AppointmentStatuses.AddRange(
                new AppointmentStatus { Name = "Agendado" },
                new AppointmentStatus { Name = "Cancelado" },
                new AppointmentStatus { Name = "Concluído" }
            );
        }

        // Seed de tipos
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
