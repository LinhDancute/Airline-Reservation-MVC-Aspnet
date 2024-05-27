using App.Models.Airline;
using App.Models.Statistical;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Models.Configurations {
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>

    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            // NhanVien - HoaDon : n-1
            builder.HasOne(bp => bp.Staff)
                .WithMany(f => f.Invoices)
                .HasForeignKey(bp => bp.StaffId)
                .IsRequired();

            // DoanhThuThang - HoaDon : n-1
            builder
                .HasOne(pdc => pdc.MonthlyRevenue)
                .WithMany(f => f.Invoices)
                .HasForeignKey(pdc => pdc.MonthlyRevenueId)
                .IsRequired();

            // KhachHang - HoaDon : n-1
            builder.HasOne(kh => kh.Passenger)
                   .WithMany(hd => hd.Invoices)
                   .HasForeignKey(dt => dt.PassengerId)
                   .IsRequired();
        }
    }
}
