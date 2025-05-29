using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaPro.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente � obrigat�rio.")]
        [StringLength(100, ErrorMessage = "O nome do cliente deve ter no m�ximo 100 caracteres.")]
        public string ClientName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail do cliente � obrigat�rio.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inv�lido.")]
        public string ClientEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data e hora do agendamento s�o obrigat�rias.")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "� necess�rio selecionar um servi�o.")]
        public int ServiceId { get; set; }

        public Service Service { get; set; } = null!;
    }
}
