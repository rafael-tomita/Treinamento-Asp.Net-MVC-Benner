using System.ComponentModel.DataAnnotations;

namespace TreinamentoBenner.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}