using System.ComponentModel.DataAnnotations;

namespace AgendaPro.Models.Scheduling
{
    public class AppointmentStatus
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
