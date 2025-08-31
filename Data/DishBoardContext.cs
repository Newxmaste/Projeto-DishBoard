using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DishApi.Models;

namespace DishApi.Data;

public partial class DishBoardContext : DbContext
{
    public DishBoardContext()
    {
    }

    public DishBoardContext(DbContextOptions<DishBoardContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<RestaurantUser> RestaurantUsers { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<StatusOrder> StatusOrders { get; set; }

    public virtual DbSet<StatusProduct> StatusProducts { get; set; }

    public virtual DbSet<StatusReservation> StatusReservations { get; set; }

    public virtual DbSet<StatusTable> StatusTables { get; set; }

    public virtual DbSet<StatusWorker> StatusWorkers { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DishBoardConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__D54EE9B40FD316FE");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__465962292F66A36E");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("order_id");
            entity.Property(e => e.Details)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("details");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.ShiftsId).HasColumnName("shifts_id");
            entity.Property(e => e.StatusOrderId)
                .HasDefaultValue(1)
                .HasColumnName("statusOrder_id");
            entity.Property(e => e.TableId).HasColumnName("table_id");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Shifts).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShiftsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Order_Shifts");

            entity.HasOne(d => d.StatusOrder).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Order_Status");

            entity.HasOne(d => d.Table).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Order_Table");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Order_User");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });

            entity.ToTable("Order_Product");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unitPrice");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OP_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OP_Product");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__ED1FC9EA60B761E5");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("payment_id");
            entity.Property(e => e.AmountPaid)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amountPaid");
            entity.Property(e => e.ChangeAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("changeAmount");
            entity.Property(e => e.IsPaid)
                .HasDefaultValue(false)
                .HasColumnName("isPaid");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("paymentDate");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("paymentMethod");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Order");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__47027DF5F632307C");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imageURL");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("productName");
            entity.Property(e => e.StatusProductId)
                .HasDefaultValue(1)
                .HasColumnName("statusProduct_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Category");

            entity.HasOne(d => d.StatusProduct).WithMany(p => p.Products)
                .HasForeignKey(d => d.StatusProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Product_Status");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__779B7C58CADAAAF0");

            entity.ToTable("Report");

            entity.Property(e => e.ReportId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("report_id");
            entity.Property(e => e.ShiftsId).HasColumnName("shifts_id");
            entity.Property(e => e.TotalOrders).HasColumnName("totalOrders");
            entity.Property(e => e.TotalRevenue)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("totalRevenue");

            entity.HasOne(d => d.Shifts).WithMany(p => p.Reports)
                .HasForeignKey(d => d.ShiftsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Report_Shifts");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__31384C2999F09571");

            entity.ToTable("Reservation");

            entity.Property(e => e.ReservationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("reservation_id");
            entity.Property(e => e.CustomerLastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customerLastName");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customerPhone");
            entity.Property(e => e.EstimatedDuration).HasColumnName("estimatedDuration");
            entity.Property(e => e.NumberOfPeople).HasColumnName("numberOfPeople");
            entity.Property(e => e.ReservationTime)
                .HasColumnType("datetime")
                .HasColumnName("reservationTime");
            entity.Property(e => e.StatusReservationId)
                .HasDefaultValue(1)
                .HasColumnName("statusReservation_id");
            entity.Property(e => e.TableId).HasColumnName("table_id");

            entity.HasOne(d => d.StatusReservation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.StatusReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_Status");

            entity.HasOne(d => d.Table).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_Table");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RestaurantId).HasName("PK__Restaura__3B0FAA91A9957627");

            entity.ToTable("Restaurant");

            entity.Property(e => e.RestaurantId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("restaurant_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedByUserId).HasColumnName("createdBy_userId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Restaurants)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Restaurant_CreatedBy");
        });

        modelBuilder.Entity<RestaurantUser>(entity =>
        {
            entity.HasKey(e => new { e.RestaurantId, e.UserId }).HasName("PK__Restaura__D7B60B5E85A508BE");

            entity.ToTable("Restaurant_User");

            entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("Server")
                .HasColumnName("role");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.RestaurantUsers)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RU_Restaurant");

            entity.HasOne(d => d.User).WithMany(p => p.RestaurantUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RU_User");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftsId).HasName("PK__Shifts__0A178FA64C3B0625");

            entity.Property(e => e.ShiftsId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("shifts_id");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("endTime");
            entity.Property(e => e.ShiftType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("None")
                .HasColumnName("shiftType");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("startTime");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shifts_User");
        });

        modelBuilder.Entity<StatusOrder>(entity =>
        {
            entity.HasKey(e => e.StatusOrderId).HasName("PK__Status_O__AA359899EFC6E63C");

            entity.ToTable("Status_Order");

            entity.Property(e => e.StatusOrderId).HasColumnName("statusOrder_id");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nameStatus");
            entity.Property(e => e.ProductNote)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("productNote");
        });

        modelBuilder.Entity<StatusProduct>(entity =>
        {
            entity.HasKey(e => e.StatusProductId).HasName("PK__Status_P__CB89D3F94184927F");

            entity.ToTable("Status_Product");

            entity.Property(e => e.StatusProductId).HasColumnName("statusProduct_id");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nameStatus");
            entity.Property(e => e.ProductNote)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("productNote");
        });

        modelBuilder.Entity<StatusReservation>(entity =>
        {
            entity.HasKey(e => e.StatusReservationId).HasName("PK__Status_R__A4DECAE271DE0E70");

            entity.ToTable("Status_Reservation");

            entity.Property(e => e.StatusReservationId).HasColumnName("statusReservation_id");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nameStatus");
        });

        modelBuilder.Entity<StatusTable>(entity =>
        {
            entity.HasKey(e => e.StatusTableId).HasName("PK__Status_T__7BF8BE511222A509");

            entity.ToTable("Status_Table");

            entity.Property(e => e.StatusTableId).HasColumnName("statusTable_id");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nameStatus");
        });

        modelBuilder.Entity<StatusWorker>(entity =>
        {
            entity.HasKey(e => e.StatusWorkerId).HasName("PK__Status_W__FFAC7B7DF73961E0");

            entity.ToTable("Status_Worker");

            entity.Property(e => e.StatusWorkerId).HasColumnName("statusWorker_id");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nameStatus");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__Table__B21E8F240EECF642");

            entity.ToTable("Table");

            entity.HasIndex(e => e.TableNumber, "UQ__Table__21B232CE3477AF33").IsUnique();

            entity.Property(e => e.TableId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("table_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.StatusTableId)
                .HasDefaultValue(1)
                .HasColumnName("statusTable_id");
            entity.Property(e => e.TableNumber).HasColumnName("table_number");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.StatusTable).WithMany(p => p.Tables)
                .HasForeignKey(d => d.StatusTableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_Status");

            entity.HasOne(d => d.User).WithMany(p => p.Tables)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83F862D9A81");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__AB6E616460D78774").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__User__F3DBC5722B471D5F").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("passwordHash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.ProfileImage)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("profile_image");
            entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("Uncategorized")
                .HasColumnName("role");
            entity.Property(e => e.StatusWorkerId)
                .HasDefaultValue(1)
                .HasColumnName("statusWorker_id");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.StatusWorker).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusWorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_StatusWorker");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
