using System.ComponentModel.DataAnnotations;

namespace MeeshoClone.Models.User
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
        public string MobileNumber { get; set; }
        //[Required]
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
