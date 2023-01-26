namespace MicroserviceArchitecture.History.DTOs
{
    public class HistoryResponse
    {
        public int IdTransaction { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = null!;
        public string CreationDate { get; set; } = null!;
        public int AccountId { get; set; }
    }
}
