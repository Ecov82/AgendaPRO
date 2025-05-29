namespace AgendaPro.Models
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // Outros campos podem ser adicionados aqui conforme necess�rio

        // Inicializa��o direta evita null em tempo de execu��o
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

