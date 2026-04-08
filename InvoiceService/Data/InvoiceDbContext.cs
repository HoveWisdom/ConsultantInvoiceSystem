using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace InvoiceService.Data;

public class InvoiceDbContext : DbContext
{
    public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Consultant> Consultants { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<Approval> Approvals { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Consultant
        modelBuilder.Entity<Consultant>(entity =>
        {
            entity.HasKey(c => c.ConsultantId);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(200);
            entity.Property(c => c.Email).IsRequired().HasMaxLength(200);
            entity.HasIndex(c => c.Email).IsUnique();
        });

        // Configure Invoice
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(i => i.InvoiceId);
            entity.Property(i => i.Amount).HasColumnType("decimal(18,2)");
            entity.Property(i => i.Status).IsRequired().HasMaxLength(50);
            
            entity.HasOne(i => i.Consultant)
                  .WithMany(c => c.Invoices)
                  .HasForeignKey(i => i.ConsultantId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure Approval
        modelBuilder.Entity<Approval>(entity =>
        {
            entity.HasKey(a => a.ApprovalId);
            entity.Property(a => a.Approver).IsRequired().HasMaxLength(200);
            entity.Property(a => a.Status).IsRequired().HasMaxLength(50);
            
            entity.HasOne(a => a.Invoice)
                  .WithMany(i => i.Approvals)
                  .HasForeignKey(a => a.InvoiceId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure Payment
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(p => p.PaymentId);
            entity.Property(p => p.Amount).HasColumnType("decimal(18,2)");
            entity.Property(p => p.Status).IsRequired().HasMaxLength(50);
            
            entity.HasOne(p => p.Invoice)
                  .WithOne(i => i.Payment)
                  .HasForeignKey<Payment>(p => p.InvoiceId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}