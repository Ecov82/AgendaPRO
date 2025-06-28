using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaPro.Models.Scheduling
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome � obrigat�rio.")]
        [Display(Name = "Nome")]
        public string ClientName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "E-mail inv�lido.")]
        [Display(Name = "E-mail")]
        public string? ClientEmail { get; set; }

        [Required(ErrorMessage = "O telefone � obrigat�rio.")]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data � obrigat�ria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "O hor�rio � obrigat�rio.")]
        [DataType(DataType.Time)]
        [Display(Name = "Hora")]
        public TimeSpan Time { get; set; }

        [Required(ErrorMessage = "O servi�o � obrigat�rio.")]
        [Display(Name = "Servi�o")]
        public int ServiceId { get; set; }

        public Service Service { get; set; } = null!;

        [Display(Name = "Status do Agendamento")]
        public int AppointmentStatusId { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; } = null!;

        [Display(Name = "Tipo de Agendamento")]
        public int AppointmentTypeId { get; set; }

        public AppointmentType AppointmentType { get; set; } = null!;

        [Display(Name = "Data de Cria��o")]
        public DateTime CreatedAt { get; set; }
    }
}
