namespace Shared.Events;

public class PaymentCompletedEvent
{
    public Guid PaymentId { get; set; }
    public Guid InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaidAt { get; set; }
    public string TransactionReference { get; set; } = string.Empty;
}