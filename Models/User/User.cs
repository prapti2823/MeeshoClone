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
        [Required]
        public string Password { get; set; }
        //[Required]
        //public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }
    }
}
