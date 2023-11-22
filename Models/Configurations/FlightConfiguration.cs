using App.Models.Airline;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Models.Configurations {
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasOne(f => f.Airline)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirlineId)
                .IsRequired();

            builder.HasOne(f => f.FlightDetail)
                .WithOne(fd => fd.Flight)
                .HasForeignKey<FlightDetail>(fd => fd.FlightId)
                .IsRequired();
        }
    }
}