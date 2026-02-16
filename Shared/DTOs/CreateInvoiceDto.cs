namespace Shared.DTOs;

public class CreateInvoiceDto
{
    public Guid ConsultantId { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
}