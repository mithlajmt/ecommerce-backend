using System.ComponentModel.DataAnnotations;

namespace backendecom.Models.Dto
{
    public class SignupDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

    }
}
