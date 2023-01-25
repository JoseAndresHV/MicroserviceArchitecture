using System.ComponentModel.DataAnnotations;

namespace MicroserviceArchitecture.Account.Models
{
    public class Customer
    {
        [Key]
        public int IdCustomer { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
