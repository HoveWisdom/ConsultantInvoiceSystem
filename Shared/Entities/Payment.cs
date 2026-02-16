namespace Shared.Entities;

public class Payment
{
    public Guid PaymentId { get; set; }
    public Guid InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Processing, Completed, Failed
    public DateTime? PaidAt { get; set; }
    public string? TransactionReference { get; set; }
    
    // Navigation property
    public Invoice? Invoice { get; set; }
}