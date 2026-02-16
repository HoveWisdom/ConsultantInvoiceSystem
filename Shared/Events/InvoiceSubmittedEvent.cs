namespace Shared.Events;

public class InvoiceSubmittedEvent
{
    public Guid InvoiceId { get; set; }
    public Guid ConsultantId { get; set; }
    public string ConsultantEmail { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime SubmittedAt { get; set; }
}