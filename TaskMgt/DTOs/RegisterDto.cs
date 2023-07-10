using System.ComponentModel.DataAnnotations;

namespace TaskMgt.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [MinLength(9, ErrorMessage = "Password too short. Mix caapital letters and numbers to avoid error")]
        public string Password { get; set; }
    }
}
