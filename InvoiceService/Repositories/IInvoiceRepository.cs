using System;
using System.Threading.Tasks;
using InvoiceService.Models;

namespace InvoiceService.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice> AddAsync(Invoice invoice);
        // For queries and more operations
        Task<Invoice> GetAsync(Guid invoiceId);
    }
}