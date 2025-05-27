using System.ComponentModel.DataAnnotations;

namespace GameStore.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Nombre(s)")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Apellido(s)")]
        public string? LastName { get; set; }
    }
}
