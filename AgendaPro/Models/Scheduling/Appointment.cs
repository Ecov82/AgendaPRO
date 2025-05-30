using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaPro.Models.Scheduling
{
    public class Appointment
    {
        public int Id { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public string ClientEmail { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public int ServiceId { get; set; }

        public Service Service { get; set; } = null!;

        public int AppointmentStatusId { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; } = null!;

        public int AppointmentTypeId { get; set; }

        public AppointmentType AppointmentType { get; set; } = null!;
    }
}
