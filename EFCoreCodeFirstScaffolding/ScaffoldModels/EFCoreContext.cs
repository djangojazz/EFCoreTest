using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreCodeFirstScaffolding.ScaffoldModels
{
//    public partial class EFCoreContext : DbContext
//    {
//        public EFCoreContext() { }

//        public EFCoreContext(DbContextOptions<EFCoreContext> options)
//            : base(options) { }

//        public virtual DbSet<Aircraft> Aircraft { get; set; }
//        public virtual DbSet<AircraftFlightOrFlightPlan> AircraftFlightOrFlightPlan { get; set; }
//        public virtual DbSet<Flight> Flight { get; set; }
//        public virtual DbSet<FlightPlan> FlightPlan { get; set; }
//        public virtual DbSet<Users> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=.;Database=EFCore;Trusted_Connection=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Aircraft>(entity =>
//            {
//                entity.Property(e => e.AircraftName)
//                    .HasMaxLength(128)
//                    .IsUnicode(false);

//                entity.Property(e => e.DateCreated).HasColumnType("datetime");

//                entity.Property(e => e.ModifiedLast).HasColumnType("datetime");

//                entity.HasOne(d => d.CreatedBy)
//                    .WithMany(p => p.AircraftCreatedBy)
//                    .HasForeignKey(d => d.CreatedById)
//                    .HasConstraintName("FK_Aircraft_CoreUser_CreatedByUserId");

//                entity.HasOne(d => d.ModifiedBy)
//                    .WithMany(p => p.AircraftModifiedBy)
//                    .HasForeignKey(d => d.ModifiedById)
//                    .HasConstraintName("FK_Aircraft_CoreUser_ModifiedByUserId");
//            });

//            modelBuilder.Entity<AircraftFlightOrFlightPlan>(entity =>
//            {
//                entity.ToTable("Aircraft_FlightOrFlightPlan");

//                entity.Property(e => e.DateCreated).HasColumnType("datetime");

//                entity.Property(e => e.ModifiedLast).HasColumnType("datetime");

//                entity.Property(e => e.ReferencedTable)
//                    .IsRequired()
//                    .HasMaxLength(128)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.Aircraft)
//                    .WithMany(p => p.AircraftFlightOrFlightPlan)
//                    .HasForeignKey(d => d.AircraftId)
//                    .HasConstraintName("FK_AircraftFlightOrFlightPlan_Aircraft_AircraftId");

//                entity.HasOne(d => d.CreatedBy)
//                    .WithMany(p => p.AircraftFlightOrFlightPlanCreatedBy)
//                    .HasForeignKey(d => d.CreatedById)
//                    .HasConstraintName("FK_Aircraft_FlightOrFlightPlan_CoreUser_CreatedByUserId");

//                entity.HasOne(d => d.Flight)
//                    .WithMany(p => p.AircraftFlightOrFlightPlan)
//                    .HasForeignKey(d => d.FlightId)
//                    .HasConstraintName("FK_AircraftFlightOrFlightPlan_Flight_FlightId");

//                entity.HasOne(d => d.FlightPlan)
//                    .WithMany(p => p.AircraftFlightOrFlightPlan)
//                    .HasForeignKey(d => d.FlightPlanId)
//                    .HasConstraintName("FK_AircraftFlightOrFlightPlan_FlightPlan_FlightPlanId");

//                entity.HasOne(d => d.ModifiedBy)
//                    .WithMany(p => p.AircraftFlightOrFlightPlanModifiedBy)
//                    .HasForeignKey(d => d.ModifiedById)
//                    .HasConstraintName("FK_Aircraft_FlightOrFlightPlan_CoreUser_ModifiedByUserId");
//            });

//            modelBuilder.Entity<Flight>(entity =>
//            {
//                entity.Property(e => e.DateCreated).HasColumnType("datetime");

//                entity.Property(e => e.FlightAlias)
//                    .HasMaxLength(128)
//                    .IsUnicode(false);

//                entity.Property(e => e.ModifiedLast).HasColumnType("datetime");

//                entity.HasOne(d => d.CreatedBy)
//                    .WithMany(p => p.FlightCreatedBy)
//                    .HasForeignKey(d => d.CreatedById)
//                    .HasConstraintName("FK_Flight_CoreUser_CreatedByUserId");

//                entity.HasOne(d => d.ModifiedBy)
//                    .WithMany(p => p.FlightModifiedBy)
//                    .HasForeignKey(d => d.ModifiedById)
//                    .HasConstraintName("FK_Flight_CoreUser_ModifiedByUserId");
//            });

//            modelBuilder.Entity<FlightPlan>(entity =>
//            {
//                entity.Property(e => e.DateCreated).HasColumnType("datetime");

//                entity.Property(e => e.FlightPlanName)
//                    .HasMaxLength(128)
//                    .IsUnicode(false);

//                entity.Property(e => e.ModifiedLast).HasColumnType("datetime");

//                entity.HasOne(d => d.CreatedBy)
//                    .WithMany(p => p.FlightPlanCreatedBy)
//                    .HasForeignKey(d => d.CreatedById)
//                    .HasConstraintName("FK_FlightPlan_CoreUser_CreatedByUserId");

//                entity.HasOne(d => d.Flight)
//                    .WithMany(p => p.FlightPlan)
//                    .HasForeignKey(d => d.FlightId);

//                entity.HasOne(d => d.ModifiedBy)
//                    .WithMany(p => p.FlightPlanModifiedBy)
//                    .HasForeignKey(d => d.ModifiedById)
//                    .HasConstraintName("FK_FlightPlan_CoreUser_ModifiedByUserId");
//            });

//            modelBuilder.Entity<Users>(entity =>
//            {
//                entity.HasKey(e => e.UserId);

//                entity.ToTable("Users", "Core");

//                entity.Property(e => e.UserName)
//                    .HasMaxLength(64)
//                    .IsUnicode(false);
//            });
//        }
//    }
}
