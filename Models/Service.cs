using System.ComponentModel.DataAnnotations;

namespace AgendaPro.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do serviço é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do serviço deve ter no máximo 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Description { get; set; }

        [Range(0.01, 9999.99, ErrorMessage = "O preço deve ser entre R$0,01 e R$9999,99.")]
        public decimal Price { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
