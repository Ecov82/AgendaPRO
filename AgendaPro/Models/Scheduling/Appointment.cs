using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaPro.Models.Scheduling
{
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string ClientName { get; set; } = string.Empty;

        [Display(Name = "E-mail do Cliente")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string ClientEmail { get; set; } = string.Empty;

        [Display(Name = "Data e Hora")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Display(Name = "Serviço")]
        public int ServiceId { get; set; }

        public Service Service { get; set; } = null!;

        [Display(Name = "Status do Agendamento")]
        public int AppointmentStatusId { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; } = null!;

        [Display(Name = "Tipo de Agendamento")]
        public int AppointmentTypeId { get; set; }

        public AppointmentType AppointmentType { get; set; } = null!;
    }
}
