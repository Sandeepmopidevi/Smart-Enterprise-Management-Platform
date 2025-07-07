namespace SmartEnterprise.FinanceService.Models
{
    public class FinanceEntry
    {
        public int Id { get; set; }
        public string Type { get; set; } // Income / Expense
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
