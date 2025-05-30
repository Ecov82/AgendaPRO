using System.ComponentModel.DataAnnotations;

namespace AgendaPro.Models.Scheduling
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do serviço é obrigatório.")]
        [StringLength(100, ErrorMessage = "No máximo 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "No máximo 500 caracteres.")]
        public string? Description { get; set; }

        [Range(0.01, 99999.99, ErrorMessage = "Preço inválido.")]
        public decimal Price { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
