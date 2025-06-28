using System.ComponentModel.DataAnnotations;

namespace AgendaPro.Models.Scheduling
{
    public class AppointmentType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Agendamento")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
