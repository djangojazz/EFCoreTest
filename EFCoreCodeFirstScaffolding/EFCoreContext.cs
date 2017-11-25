using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFCoreCodeFirstScaffolding.Models;

namespace EFCoreCodeFirstScaffolding
{
    public partial class EFCoreContext : DbContext
    {
        public EFCoreContext() { }

        public EFCoreContext(DbContextOptions<EFCoreContext> options)
            : base(options) {}

        public virtual DbSet<Aircraft> Aircraft { get; set; }
        public virtual DbSet<AircraftFlightOrFlightPlan> AircraftFlightOrFlightPlan { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<FlightPlan> FlightPlan { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.;Database=EFCore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "Core");
            });
        }
    }
}
