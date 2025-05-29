namespace AgendaPro.Models
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // Outros campos podem ser adicionados aqui conforme necessário

        // Inicialização direta evita null em tempo de execução
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

