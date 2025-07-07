namespace SmartEnterprise.CRMService.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; } // e.g. New, Contacted, Active
        public DateTime CreatedAt { get; set; }
    }
}
