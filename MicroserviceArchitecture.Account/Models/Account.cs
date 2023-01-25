using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroserviceArchitecture.Account.Models
{
    public class Account
    {
        [Key]
        public int IdAccount { get; set; }
        public decimal TotalAmount { get; set; }
        [ForeignKey(nameof(Customer))]
        public int IdCustomer { get; set; }
        public Customer Customer { get; set; } = default!;
    }
}
