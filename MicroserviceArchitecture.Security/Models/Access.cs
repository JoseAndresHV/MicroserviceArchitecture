using System.ComponentModel.DataAnnotations;

namespace MicroserviceArchitecture.Security.Models
{
    public class Access
    {
        [Key]
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
