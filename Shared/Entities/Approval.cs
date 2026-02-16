namespace Shared.Entities;

public class Approval
{
    public Guid ApprovalId { get; set; }
    public Guid InvoiceId { get; set; }
    public string Approver { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
    public DateTime? DecisionDate { get; set; }
    public string? Comments { get; set; }
    
    // Navigation property
    public Invoice? Invoice { get; set; }
}