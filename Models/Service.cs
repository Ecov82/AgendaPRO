using System.ComponentModel.DataAnnotations;

namespace AgendaPro.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do servi�o � obrigat�rio.")]
        [StringLength(100, ErrorMessage = "O nome do servi�o deve ter no m�ximo 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descri��o deve ter no m�ximo 500 caracteres.")]
        public string? Description { get; set; }

        [Range(0.01, 9999.99, ErrorMessage = "O pre�o deve ser entre R$0,01 e R$9999,99.")]
        public decimal Price { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
