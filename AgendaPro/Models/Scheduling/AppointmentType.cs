namespace AgendaPro.Models.Scheduling
{
    public class AppointmentType
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
