using App.Models.Airline;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Models.Configurations {
    public class FlightDetailConfiguration : IEntityTypeConfiguration<FlightDetail>
    {
        public void Configure(EntityTypeBuilder<FlightDetail> builder)
        {
            // Additional configurations for FlightDetail entity...
        }
    }
}