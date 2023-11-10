using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using App.Models.Contacts;
using App.Models;
using App.Models.Airline;

namespace App.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            string connectionString = _configuration.GetConnectionString("AirlineReservationDb");
            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

        public DbSet<App.Models.Contacts.Contact> Contacts { get; set; }
        public DbSet<App.Models.Airline.Airline> Airlines { get; set; }
        public DbSet<App.Models.Airline.Airport> Airports { get; set; }
        public DbSet<App.Models.Airline.BoardingPass> BoardingPasses { get; set; }
        public DbSet<App.Models.Airline.Flight> Flights { get; set; }
        public DbSet<App.Models.Airline.FlightDetail> FlightDetails { get; set; }
        public DbSet<App.Models.Airline.FlightRoute> FlightRoutes { get; set; }
        public DbSet<App.Models.Airline.Ticket> Tickets { get; set; }
        public DbSet<App.Models.Airline.TicketClass> TicketClasses { get; set; }
        public DbSet<App.Models.Statistical.AnnualRevenue> AnnualRevenues { get; set; }
        public DbSet<App.Models.Statistical.Invoice> Invoices { get; set; }
        public DbSet<App.Models.Statistical.MonthlyRevenue> MonthlyRevenues { get; set; }
        public DbSet<App.Models.Statistical.UnitPrice> UnitPrices { get; set; }
    }
}