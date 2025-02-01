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
        //[Required]
        public System.DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
