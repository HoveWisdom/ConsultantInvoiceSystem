namespace Shared.Interfaces;

using Shared.Entities;

public interface IInvoiceRepository
{
    Task<Invoice?> GetByIdAsync(Guid invoiceId);
    Task<IEnumerable<Invoice>> GetAllAsync();
    Task<IEnumerable<Invoice>> GetByConsultantIdAsync(Guid consultantId);
    Task<Invoice> CreateAsync(Invoice invoice);
    Task UpdateAsync(Invoice invoice);
    Task DeleteAsync(Guid invoiceId);
}