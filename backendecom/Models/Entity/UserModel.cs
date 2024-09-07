using System.ComponentModel.DataAnnotations;

namespace backendecom.Models.Entity
{
    public class UserModel
    {
        public Guid Id { get; set; }

        [Required] //this are called attributes they are the metadata 
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(100)]
        public string? PasswordHash { get; set; }

        [Required]
        [StringLength(20)] // Adjust the length as needed
        public string? Role { get; set; }

        [Required]
        [StringLength(20)]
        [MinLength(5)]
        public string? UserId { get; set; }
    }
}