using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TouristAgency.Models;

public partial class TouristAgencyContext : DbContext
{
    public TouristAgencyContext()
    {
    }

    public TouristAgencyContext(DbContextOptions<TouristAgencyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Excursion> Excursions { get; set; }

    public virtual DbSet<ExcursionAgency> ExcursionAgencies { get; set; }

    public virtual DbSet<ExpensesIncome> ExpensesIncomes { get; set; }

    public virtual DbSet<FinancialReport> FinancialReports { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelAccommodation> HotelAccommodations { get; set; }

    public virtual DbSet<HotelCategory> HotelCategories { get; set; }

    public virtual DbSet<Luggage> Luggage { get; set; }

    public virtual DbSet<PopularExcursion> PopularExcursions { get; set; }

    public virtual DbSet<Tourist> Tourists { get; set; }

    public virtual DbSet<TouristAccommodation> TouristAccommodations { get; set; }

    public virtual DbSet<TouristCategory> TouristCategories { get; set; }

    public virtual DbSet<TouristsFlight> TouristsFlights { get; set; }

    public virtual DbSet<Travel> Travels { get; set; }

    public virtual DbSet<GetHotelAccommodations> GetHotelAccommodationss { get; set; }
    public virtual DbSet<GetTouristCountByCountryAndPeriod> GetTouristCountByCountryAndPeriods { get; set; }
    public virtual DbSet<GetOccupiedRoomsByHotelAndPeriod> GetOccupiedRoomsByHotelAndPeriods { get; set; }
   public virtual DbSet<GetTotalTouristsWithExcursionsByPeriod> GetTotalTouristsWithExcursionsByPeriods { get; set; }
   public virtual DbSet<GetFlightLoadingData> GetFlightLoadingDatas { get; set; }
   public virtual DbSet<GetCargoStatistics> GetCargoStatistics { get; set; }
   public virtual DbSet<GetFinancialReportForGroupAndCategory> GetFinancialReportForGroupAndCategories { get; set; }
    public virtual DbSet<GetExpensesIncomesForPeriod> GetExpensesIncomesForPeriods { get; set; }
   public virtual DbSet<GetLuggageStatistics> GetLuggageStatistics { get; set; }
    public virtual DbSet<CalculateTouristRatio> CalculateTouristRatios { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1ULUPV2;Database=TouristAgency;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.CargoId).HasName("PK__Cargo__982828C4017E105B");

            entity.ToTable("Cargo", "FlightInfo");

            entity.Property(e => e.CargoId)
                .ValueGeneratedNever()
                .HasColumnName("cargo_id");
            entity.Property(e => e.CargoType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cargo_type");
            entity.Property(e => e.CargoWeight)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cargo_weight");
            entity.Property(e => e.FlightId).HasColumnName("flight_id");

            entity.HasOne(d => d.Flight).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.FlightId)
                .HasConstraintName("FK__Cargo__flight_id__45F365D3");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Countrie__7E8CD05547629843");

            entity.ToTable("Countries", "CommonInfo");

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnName("country_id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<Excursion>(entity =>
        {
            entity.HasKey(e => e.ExcursionId).HasName("PK__Excursio__4E6B1B9C24DE02F1");

            entity.ToTable("Excursions", "ExcursionInfo");

            entity.Property(e => e.ExcursionId)
                .ValueGeneratedNever()
                .HasColumnName("excursion_id");
            entity.Property(e => e.AgencyId).HasColumnName("agency_id");
            entity.Property(e => e.ExcursionCost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("excursion_cost");
            entity.Property(e => e.ExcursionDate)
                .HasColumnType("date")
                .HasColumnName("excursion_date");
            entity.Property(e => e.ExcursionDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("excursion_description");
            entity.Property(e => e.ExcursionName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("excursion_name");

            entity.HasOne(d => d.Agency).WithMany(p => p.Excursions)
                .HasForeignKey(d => d.AgencyId)
                .HasConstraintName("FK__Excursion__agenc__48CFD27E");
        });

        modelBuilder.Entity<ExcursionAgency>(entity =>
        {
            entity.HasKey(e => e.AgencyId).HasName("PK__Excursio__7224EBF8BC6D7AB7");

            entity.ToTable("ExcursionAgencies", "AgencyInfo");

            entity.Property(e => e.AgencyId)
                .ValueGeneratedNever()
                .HasColumnName("agency_id");
            entity.Property(e => e.AgencyAddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("agency_address");
            entity.Property(e => e.AgencyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("agency_name");
            entity.Property(e => e.AgencyPhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("agency_phone_number");
        });

        modelBuilder.Entity<ExpensesIncome>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__Expenses__BFCFB4DD5B77A6F1");

            entity.ToTable("ExpensesIncomes", "FinancialInfo");

            entity.Property(e => e.RecordId)
                .ValueGeneratedNever()
                .HasColumnName("record_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ExpenseIncomeType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("expense_income_type");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("service_name");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("date")
                .HasColumnName("transaction_date");
        });

        modelBuilder.Entity<FinancialReport>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Financia__779B7C58D6472700");

            entity.ToTable("FinancialReport", "FinancialInfo");

            entity.Property(e => e.ReportId)
                .ValueGeneratedNever()
                .HasColumnName("report_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category_name");
            entity.Property(e => e.GroupName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("group_name");
            entity.Property(e => e.NetProfit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("net_profit");
            entity.Property(e => e.ReportDate)
                .HasColumnType("date")
                .HasColumnName("report_date");
            entity.Property(e => e.TotalExpenses)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_expenses");
            entity.Property(e => e.TotalIncome)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_income");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__Flights__E3705765B51C135C");

            entity.ToTable("Flights", "FlightInfo");

            entity.Property(e => e.FlightId)
                .ValueGeneratedNever()
                .HasColumnName("flight_id");
            entity.Property(e => e.AircraftType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aircraft_type");
            entity.Property(e => e.ArrivalDate)
                .HasColumnType("date")
                .HasColumnName("arrival_date");
            entity.Property(e => e.DepartureDate)
                .HasColumnType("date")
                .HasColumnName("departure_date");
            entity.Property(e => e.FlightNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("flight_number");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotels__45FE7E266A9B97B2");

            entity.ToTable("Hotels", "HotelInfo");

            entity.Property(e => e.HotelId)
                .ValueGeneratedNever()
                .HasColumnName("hotel_id");
            entity.Property(e => e.HotelAddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("hotel_address");
            entity.Property(e => e.HotelCategoryId).HasColumnName("hotel_category_id");
            entity.Property(e => e.HotelName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("hotel_name");

            entity.HasOne(d => d.HotelCategory).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.HotelCategoryId)
                .HasConstraintName("FK__Hotels__hotel_ca__5441852A");
        });

        modelBuilder.Entity<HotelAccommodation>(entity =>
        {
            entity.HasKey(e => e.RoomNumber).HasName("PK__HotelAcc__FE22F61A66E44958");

            entity.ToTable("HotelAccommodations", "HotelInfo", tb => tb.HasTrigger("update_check_out_date"));

            entity.Property(e => e.RoomNumber)
                .ValueGeneratedNever()
                .HasColumnName("room_number");
            entity.Property(e => e.CheckInDate)
                .HasColumnType("date")
                .HasColumnName("check_in_date");
            entity.Property(e => e.CheckOutDate)
                .HasColumnType("date")
                .HasColumnName("check_out_date");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.RoomPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("room_price");
            entity.Property(e => e.RoomType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("room_type");
            entity.Property(e => e.TouristId).HasColumnName("tourist_id");

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelAccommodations)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK__HotelAcco__hotel__787EE5A0");

            entity.HasOne(d => d.Tourist).WithMany(p => p.HotelAccommodations)
                .HasForeignKey(d => d.TouristId)
                .HasConstraintName("FK__HotelAcco__touri__778AC167");
        });

        modelBuilder.Entity<HotelCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__HotelCat__D54EE9B4660E8F78");

            entity.ToTable("HotelCategories", "HotelInfo");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Luggage>(entity =>
        {
            entity.HasKey(e => e.LuggageId).HasName("PK__Luggage__00F3B170620E2FC8");

            entity.ToTable("Luggage", "TouristInfo");

            entity.Property(e => e.LuggageId)
                .ValueGeneratedNever()
                .HasColumnName("luggage_id");
            entity.Property(e => e.LuggageType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("luggage_type");
            entity.Property(e => e.LuggageWeight)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("luggage_weight");
        });

        modelBuilder.Entity<PopularExcursion>(entity =>
        {
            entity.HasKey(e => e.ExcursionId).HasName("PK__PopularE__4E6B1B9C4F76052B");

            entity.ToTable("PopularExcursions", "FlightInfo");

            entity.Property(e => e.ExcursionId)
                .ValueGeneratedNever()
                .HasColumnName("excursion_id");
            entity.Property(e => e.ExcursionRating).HasColumnName("excursion_rating");
        });

        modelBuilder.Entity<Tourist>(entity =>
        {
            entity.HasKey(e => e.TouristId).HasName("PK__Tourists__83DD92C957F3E7C5");

            entity.ToTable("Tourists", "TouristInfo");

            entity.HasIndex(e => e.Name, "IX_TouristName");

            entity.Property(e => e.TouristId)
                .ValueGeneratedNever()
                .HasColumnName("tourist_id");
            entity.Property(e => e.CountryOfResidence)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country_of_residence");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("passport_number");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
            entity.Property(e => e.TouristCategoryId).HasColumnName("tourist_category_id");

            entity.HasOne(d => d.TouristCategory).WithMany(p => p.Tourists)
                .HasForeignKey(d => d.TouristCategoryId)
                .HasConstraintName("FK__Tourists__touris__619B8048");

            entity.HasMany(d => d.Excursions).WithMany(p => p.Tourists)
                .UsingEntity<Dictionary<string, object>>(
                    "TouristsAndExcursion",
                    r => r.HasOne<Excursion>().WithMany()
                        .HasForeignKey("ExcursionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TouristsA__excur__73BA3083"),
                    l => l.HasOne<Tourist>().WithMany()
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TouristsA__touri__72C60C4A"),
                    j =>
                    {
                        j.HasKey("TouristId", "ExcursionId").HasName("PK__Tourists__573B2370E2D3E51A");
                        j.ToTable("TouristsAndExcursions", "TouristInfo");
                        j.IndexerProperty<int>("TouristId").HasColumnName("tourist_id");
                        j.IndexerProperty<int>("ExcursionId").HasColumnName("excursion_id");
                    });

            entity.HasMany(d => d.Luggage).WithMany(p => p.Tourists)
                .UsingEntity<Dictionary<string, object>>(
                    "TouristsAndLuggage",
                    r => r.HasOne<Luggage>().WithMany()
                        .HasForeignKey("LuggageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TouristsA__lugga__6FE99F9F"),
                    l => l.HasOne<Tourist>().WithMany()
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TouristsA__touri__6EF57B66"),
                    j =>
                    {
                        j.HasKey("TouristId", "LuggageId").HasName("PK__Tourists__93D2A9DED909E64E");
                        j.ToTable("TouristsAndLuggage", "TouristInfo", tb => tb.HasTrigger("tr_check_luggage_weight"));
                        j.IndexerProperty<int>("TouristId").HasColumnName("tourist_id");
                        j.IndexerProperty<int>("LuggageId").HasColumnName("luggage_id");
                    });
        });

        modelBuilder.Entity<TouristAccommodation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TouristAccommodations", "TouristInfo");

            entity.HasIndex(e => new { e.CheckInDate, e.CheckOutDate }, "IX_TouristAccommodations_CheckIn_CheckOut");

            entity.Property(e => e.CheckInDate)
                .HasColumnType("date")
                .HasColumnName("check_in_date");
            entity.Property(e => e.CheckOutDate)
                .HasColumnType("date")
                .HasColumnName("check_out_date");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.TouristId).HasColumnName("tourist_id");

            entity.HasOne(d => d.Hotel).WithMany()
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK__TouristAc__hotel__6A30C649");

            entity.HasOne(d => d.Tourist).WithMany()
                .HasForeignKey(d => d.TouristId)
                .HasConstraintName("FK__TouristAc__touri__6B24EA82");
        });

        modelBuilder.Entity<TouristCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__TouristC__D54EE9B4DC990D0A");

            entity.ToTable("TouristCategories", "TouristInfo");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<TouristsFlight>(entity =>
        {
            entity.HasKey(e => e.TouristFlightId).HasName("PK__Tourists__BBC65D50FB3D697C");

            entity.ToTable("TouristsFlights", "FlightInfo");

            entity.Property(e => e.TouristFlightId)
                .ValueGeneratedNever()
                .HasColumnName("tourist_flight_id");
            entity.Property(e => e.FlightId).HasColumnName("flight_id");
            entity.Property(e => e.TouristId).HasColumnName("tourist_id");

            entity.HasOne(d => d.Flight).WithMany(p => p.TouristsFlights)
                .HasForeignKey(d => d.FlightId)
                .HasConstraintName("FK__TouristsF__fligh__7C4F7684");

            entity.HasOne(d => d.Tourist).WithMany(p => p.TouristsFlights)
                .HasForeignKey(d => d.TouristId)
                .HasConstraintName("FK__TouristsF__touri__7D439ABD");
        });

        modelBuilder.Entity<Travel>(entity =>
        {
            entity.HasKey(e => e.TravelId).HasName("PK__Travels__BF088B5CC7782F1D");

            entity.ToTable("Travels", "TouristInfo", tb => tb.HasTrigger("UpdateTravelEndDate"));

            entity.HasIndex(e => e.TouristId, "IX_Tourist_TravelID");

            entity.Property(e => e.TravelId)
                .ValueGeneratedNever()
                .HasColumnName("travel_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.TouristId).HasColumnName("tourist_id");
            entity.Property(e => e.TravelEndDate)
                .HasColumnType("date")
                .HasColumnName("travel_end_date");
            entity.Property(e => e.TravelStartDate)
                .HasColumnType("date")
                .HasColumnName("travel_start_date");

            entity.HasOne(d => d.Country).WithMany(p => p.Travels)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Travels__country__6477ECF3");

            entity.HasOne(d => d.Tourist).WithMany(p => p.Travels)
                .HasForeignKey(d => d.TouristId)
                .HasConstraintName("FK__Travels__tourist__656C112C");
        });

        modelBuilder.Entity<GetHotelAccommodations>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetTouristCountByCountryAndPeriod>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetOccupiedRoomsByHotelAndPeriod>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetTotalTouristsWithExcursionsByPeriod>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetFlightLoadingData>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetCargoStatistics>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetFinancialReportForGroupAndCategory>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetExpensesIncomesForPeriod>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<GetLuggageStatistics>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<CalculateTouristRatio>(entity =>
        {
            entity.HasNoKey();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
