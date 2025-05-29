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

        // Inicializa��o com null! indica ao compilador que ser� atribu�do em tempo de execu��o (EF Core)
        public Service Service { get; set; } = null!;
    }
}
