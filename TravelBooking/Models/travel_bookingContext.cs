using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelBooking.Models
{
    public partial class travel_bookingContext : DbContext
    {
        public travel_bookingContext()
        {
        }

        public travel_bookingContext(DbContextOptions<travel_bookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FlightData> FlightData { get; set; }
        public virtual DbSet<FlightRoute> FlightRoute { get; set; }
        public virtual DbSet<Passenger> Passenger { get; set; }
        public virtual DbSet<TicketAmnt> TicketAmnt { get; set; }
        public virtual DbSet<TotalTicktCharge> TotalTicktCharge { get; set; }
        public virtual DbSet<Traveler> Traveler { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= ALFINASULFIKAR\\SQLEXPRESS; Initial Catalog= travel_booking; Integrated security=True");
            }
        }
       */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightData>(entity =>
            {
                entity.HasKey(e => e.FlightId)
                    .HasName("PK__flight_d__E373AB5DAC9D10FB");

                entity.ToTable("flight_data");

                entity.Property(e => e.FlightId)
                    .HasColumnName("flight_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdultCharge).HasColumnName("adult_charge");

                entity.Property(e => e.AirlineName)
                    .IsRequired()
                    .HasColumnName("airline_name")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.ArrivalTime)
                    .HasColumnName("arrival_time")
                    .HasColumnType("date");

                entity.Property(e => e.ChildCharge).HasColumnName("child_charge");

                entity.Property(e => e.DepartTime)
                    .HasColumnName("depart_time")
                    .HasColumnType("date");

                entity.Property(e => e.FlightRouteId).HasColumnName("flight_routeID");

                entity.HasOne(d => d.FlightRoute)
                    .WithMany(p => p.FlightData)
                    .HasForeignKey(d => d.FlightRouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__flight_da__fligh__5629CD9C");
            });

            modelBuilder.Entity<FlightRoute>(entity =>
            {
                entity.ToTable("flight_route");

                entity.Property(e => e.FlightRouteId)
                    .HasColumnName("flight_routeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartLocation)
                    .IsRequired()
                    .HasColumnName("depart_location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DestinLocation)
                    .IsRequired()
                    .HasColumnName("destin_location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TravelerId).HasColumnName("travelerID");

                entity.HasOne(d => d.Traveler)
                    .WithMany(p => p.FlightRoute)
                    .HasForeignKey(d => d.TravelerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__flight_ro__trave__534D60F1");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.PassengerListId)
                    .HasName("PK__passenge__4DC0007213522E34");

                entity.ToTable("passenger");

                entity.Property(e => e.PassengerListId)
                    .HasColumnName("passenger_listID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdultTotal).HasColumnName("adult_total");

                entity.Property(e => e.ChildTotal).HasColumnName("child_total");

                entity.Property(e => e.CoTravellrTotal).HasColumnName("co_travellr_total");

                entity.Property(e => e.FlightId).HasColumnName("flight_ID");

                entity.Property(e => e.TravelerId).HasColumnName("traveler_ID");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Passenger)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__passenger__fligh__5FB337D6");

                entity.HasOne(d => d.Traveler)
                    .WithMany(p => p.Passenger)
                    .HasForeignKey(d => d.TravelerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__passenger__trave__5EBF139D");
            });

            modelBuilder.Entity<TicketAmnt>(entity =>
            {
                entity.ToTable("ticket_amnt");

                entity.Property(e => e.TicketAmntId)
                    .HasColumnName("ticket_amntID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BaggageChrg).HasColumnName("baggage_chrg");

                entity.Property(e => e.FlightId).HasColumnName("flight_ID");

                entity.Property(e => e.HandlingChrg).HasColumnName("handling_chrg");

                entity.Property(e => e.TaxAmnt).HasColumnName("tax_amnt");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.TicketAmnt)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticket_am__fligh__59063A47");
            });

            modelBuilder.Entity<TotalTicktCharge>(entity =>
            {
                entity.HasKey(e => e.ChargeId)
                    .HasName("PK__total_ti__F71EF993D4006611");

                entity.ToTable("total_ticktCharge");

                entity.Property(e => e.ChargeId)
                    .HasColumnName("chargeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FlightId).HasColumnName("flight_ID");

                entity.Property(e => e.PassengerListId).HasColumnName("passenger_listID");

                entity.Property(e => e.TicketAmountId).HasColumnName("ticket_AmountID");

                entity.Property(e => e.TotalAmnt).HasColumnName("total_Amnt");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.TotalTicktCharge)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__total_tic__fligh__693CA210");

                entity.HasOne(d => d.PassengerList)
                    .WithMany(p => p.TotalTicktCharge)
                    .HasForeignKey(d => d.PassengerListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__total_tic__passe__6754599E");

                entity.HasOne(d => d.TicketAmount)
                    .WithMany(p => p.TotalTicktCharge)
                    .HasForeignKey(d => d.TicketAmountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__total_tic__ticke__68487DD7");
            });

            modelBuilder.Entity<Traveler>(entity =>
            {
                entity.ToTable("traveler");

                entity.Property(e => e.TravelerId)
                    .HasColumnName("travelerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TravelerName)
                    .IsRequired()
                    .HasColumnName("travelerName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
