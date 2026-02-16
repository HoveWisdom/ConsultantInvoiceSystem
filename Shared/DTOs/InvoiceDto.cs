namespace Shared.DTOs;

public class InvoiceDto
{
    public Guid InvoiceId { get; set; }
    public Guid ConsultantId { get; set; }
    public string ConsultantName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime SubmittedAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Description { get; set; }
}