using System;

namespace InvoiceService.Models
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public Guid ConsultantId { get; set; }
        public decimal Amount { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string Status { get; set; } // Pending, Approved, Paid
    }
}