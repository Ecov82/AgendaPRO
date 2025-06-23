namespace AgendaPro.Models.Scheduling
{
    public class Professional
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Profession { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        // Outros dados relevantes, como especializações, endereço etc.
    }
}
