using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Insurance_Project.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Hi> His { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-UK4IOQ9N\\SQLEXPRESS;Database=project3;user id=sa;password=tien1912;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Table1");

            entity.ToTable("Account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.ToTable("Contract");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountInsurance).HasColumnName("amount_insurance");
            entity.Property(e => e.ContractNumber)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("contract_number");
            entity.Property(e => e.DateEnd)
                .HasColumnType("date")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("date")
                .HasColumnName("date_start");
            entity.Property(e => e.IdCustomer).HasColumnName("id_customer");
            entity.Property(e => e.IdTypeInsurance).HasColumnName("id_type_insurance");
            entity.Property(e => e.Note)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.Premium).HasColumnName("premium");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Customer");

            entity.HasOne(d => d.IdTypeInsuranceNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdTypeInsurance)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Insurance");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer);

            entity.ToTable("Customer");

            entity.Property(e => e.IdCustomer).HasColumnName("id_customer");
            entity.Property(e => e.Adress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("adress");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.Created)
                .HasColumnType("date")
                .HasColumnName("created");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Identification).HasColumnName("identification");
            entity.Property(e => e.NameCustomer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_customer");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.ProfilePhoto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("profile_photo");
            entity.Property(e => e.Securitycode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("securitycode");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Hi>(entity =>
        {
            entity.HasKey(e => e.AccId).HasName("PK_Account");

            entity.ToTable("Hi");

            entity.Property(e => e.AccId).HasColumnName("AccID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.ToTable("History");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.DatePayment)
                .HasColumnType("date")
                .HasColumnName("date_payment");
            entity.Property(e => e.IdContract).HasColumnName("id_contract");
            entity.Property(e => e.MethodPayment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("method_payment");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Note)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.IdContractNavigation).WithMany(p => p.Histories)
                .HasForeignKey(d => d.IdContract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_History_Contract");

            entity.HasOne(d => d.IdContract1).WithMany(p => p.Histories)
                .HasForeignKey(d => d.IdContract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_History_Payment");
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.HasKey(e => e.IdInsurance).HasName("PK_Home_Insurance");

            entity.ToTable("Insurance");

            entity.Property(e => e.IdInsurance)
                .ValueGeneratedNever()
                .HasColumnName("id_insurance");
            entity.Property(e => e.DateEnd)
                .HasColumnType("date")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("date")
                .HasColumnName("date_start");
            entity.Property(e => e.IdCustomer)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_customer");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.Optiondate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("optiondate");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.TypeInsurance).HasColumnName("type_insurance");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.IdContract);

            entity.ToTable("Payment");

            entity.Property(e => e.IdContract)
                .ValueGeneratedNever()
                .HasColumnName("id_contract");
            entity.Property(e => e.AmountPayment).HasColumnName("amount_payment");
            entity.Property(e => e.DatePayment)
                .HasColumnType("date")
                .HasColumnName("date_payment");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdCustomer).HasColumnName("id_customer");
            entity.Property(e => e.NameCustomer)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name_customer");
            entity.Property(e => e.StatusPayment).HasColumnName("status_payment");
            entity.Property(e => e.TypePayment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("type_payment");

            entity.HasOne(d => d.IdContractNavigation).WithOne(p => p.Payment)
                .HasForeignKey<Payment>(d => d.IdContract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Contract1");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Customer");
        });

        modelBuilder.Entity<TransactionDetail>(entity =>
        {
            entity.HasKey(e => e.TransId);

            entity.Property(e => e.TransId).HasColumnName("TransID");
            entity.Property(e => e.AccId).HasColumnName("AccID");
            entity.Property(e => e.DateOfTrans).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
