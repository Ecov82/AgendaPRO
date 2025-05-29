using System;

namespace AgendaPro.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public string ClientEmail { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public int ServiceId { get; set; }

        // Inicialização com null! indica ao compilador que será atribuído em tempo de execução (EF Core)
        public Service Service { get; set; } = null!;
    }
}
