using System.ComponentModel.DataAnnotations;

namespace EmployAPI.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }    

    }
}
