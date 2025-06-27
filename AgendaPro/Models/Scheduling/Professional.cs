using System.ComponentModel.DataAnnotations;

namespace AgendaPro.Models.Scheduling
{
    public class Professional
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Display(Name = "Nome")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "A profissão é obrigatória.")]
        [Display(Name = "Profissional")]
        public string Profession { get; set; } = null!;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; } = null!;

        [Phone(ErrorMessage = "Telefone inválido.")]
        [Display(Name = "Telefone")]
        public string Phone { get; set; } = null!;

        // Outros dados relevantes, como especializações, endereço etc.
    }
}
