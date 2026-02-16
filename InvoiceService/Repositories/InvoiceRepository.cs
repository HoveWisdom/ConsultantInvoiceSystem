using System;
using System.Threading.Tasks;
using InvoiceService.Models;
using InvoiceService.Data;
using Microsoft.EntityFrameworkCore;

namespace InvoiceService.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceDbContext _db;

        public InvoiceRepository(InvoiceDbContext db) { _db = db; }

        public async Task<Invoice> AddAsync(Invoice invoice)
        {
            _db.Invoices.Add(invoice);
            await _db.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> GetAsync(Guid invoiceId)
        {
            return await _db.Invoices.AsNoTracking().FirstOrDefaultAsync(x => x.InvoiceId == invoiceId);
        }
    }
}