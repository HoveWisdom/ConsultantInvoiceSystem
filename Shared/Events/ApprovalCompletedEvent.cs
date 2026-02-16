namespace Shared.Events;

public class ApprovalCompletedEvent
{
    public Guid InvoiceId { get; set; }
    public Guid ApprovalId { get; set; }
    public bool IsApproved { get; set; }
    public string Approver { get; set; } = string.Empty;
    public DateTime DecisionDate { get; set; }
    public string? Comments { get; set; }
}