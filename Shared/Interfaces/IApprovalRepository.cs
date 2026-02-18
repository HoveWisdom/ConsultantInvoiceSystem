namespace Shared.Interfaces;

using Shared.Entities;

public interface IApprovalRepository
{
    Task<Approval?> GetByIdAsync(Guid approvalId);
    Task<IEnumerable<Approval>> GetByInvoiceIdAsync(Guid invoiceId);
    Task<Approval> CreateAsync(Approval approval);
    Task UpdateAsync(Approval approval);
}