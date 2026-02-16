namespace Shared.Entities;

public class Consultant
{
    public Guid ConsultantId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    
    // Navigation property
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
