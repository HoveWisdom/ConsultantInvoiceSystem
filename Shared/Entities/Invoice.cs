namespace Shared.Entities;

public class Invoice
{
    public Guid InvoiceId { get; set; }
    public Guid ConsultantId { get; set; }
    public decimal Amount { get; set; }
    public DateTime SubmittedAt { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Paid
    public string? Description { get; set; }
    
    // Navigation properties
    public Consultant? Consultant { get; set; }
    public ICollection<Approval> Approvals { get; set; } = new List<Approval>();
    public Payment? Payment { get; set; }
}