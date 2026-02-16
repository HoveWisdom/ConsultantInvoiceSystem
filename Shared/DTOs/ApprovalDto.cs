namespace Shared.DTOs;

public class ApprovalDto
{
    public Guid InvoiceId { get; set; }
    public string Approver { get; set; } = string.Empty;
    public bool IsApproved { get; set; }
    public string? Comments { get; set; }
}