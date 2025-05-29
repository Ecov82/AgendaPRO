using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaPro.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do cliente deve ter no máximo 100 caracteres.")]
        public string ClientName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail do cliente é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string ClientEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data e hora do agendamento são obrigatórias.")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "É necessário selecionar um serviço.")]
        public int ServiceId { get; set; }

        public Service Service { get; set; } = null!;
    }
}
