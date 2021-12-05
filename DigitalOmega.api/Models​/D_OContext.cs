using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DigitalOmega.api.Models​
{
    public partial class D_OContext : DbContext
    {
        public D_OContext()
        {
        }

        public D_OContext(DbContextOptions<D_OContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; } = null!;
        public virtual DbSet<Dispositon> Dispositons { get; set; } = null!;
        public virtual DbSet<InstallationType> InstallationTypes { get; set; } = null!;
        public virtual DbSet<Ip> Ips { get; set; } = null!;
        public virtual DbSet<NewHomePhone> NewHomePhones { get; set; } = null!;
        public virtual DbSet<NewMobile> NewMobiles { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Package> Packages { get; set; } = null!;
        public virtual DbSet<PackageDetail> PackageDetails { get; set; } = null!;
        public virtual DbSet<PortedHomePhone> PortedHomePhones { get; set; } = null!;
        public virtual DbSet<PortedMobile> PortedMobiles { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=desktop-seldjir;Initial Catalog=D_O;MultipleActiveResultSets=true;User ID=fahid;Password=1234;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("Agent");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Affiliate).HasMaxLength(100);

                entity.Property(e => e.AgentName).HasMaxLength(100);
            });

            modelBuilder.Entity<Dispositon>(entity =>
            {
                entity.ToTable("Dispositon");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DispoStatus).HasMaxLength(200);

                entity.Property(e => e.StatusName).HasMaxLength(100);
            });

            modelBuilder.Entity<InstallationType>(entity =>
            {
                entity.ToTable("InstallationType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InstallationType1)
                    .HasMaxLength(50)
                    .HasColumnName("InstallationType");
            });

            modelBuilder.Entity<Ip>(entity =>
            {
                entity.ToTable("IP");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ip1)
                    .HasMaxLength(100)
                    .HasColumnName("IP");
            });

            modelBuilder.Entity<NewHomePhone>(entity =>
            {
                entity.ToTable("NewHomePhone");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.NewHomePhone1)
                    .HasMaxLength(100)
                    .HasColumnName("NewHomePhone");
            });

            modelBuilder.Entity<NewMobile>(entity =>
            {
                entity.ToTable("NewMobile");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NewMobile1)
                    .HasMaxLength(100)
                    .HasColumnName("NewMobile");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountNumber).HasMaxLength(100);

                entity.Property(e => e.Address1).HasMaxLength(500);

                entity.Property(e => e.Address2).HasMaxLength(500);

                entity.Property(e => e.AlternatePhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Btn)
                    .HasMaxLength(100)
                    .HasColumnName("BTN");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Comment).HasMaxLength(1000);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.InstallationType).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.OrderConfirmationNumber).HasMaxLength(50);

                entity.Property(e => e.OrderInstallationDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentType).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.SaleDate).HasColumnType("datetime");

                entity.Property(e => e.SaleSource).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.WorkOderNumber).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(50);
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Package");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Abbreviation).HasMaxLength(500);

                entity.Property(e => e.PackageName).HasMaxLength(100);

                entity.Property(e => e.Psus)
                    .HasMaxLength(500)
                    .HasColumnName("PSUs");
            });

            modelBuilder.Entity<PackageDetail>(entity =>
            {
                entity.ToTable("PackageDetail");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Box).HasColumnName("BOX");

                entity.Property(e => e.Dvr).HasColumnName("DVR");

                entity.Property(e => e.Psus).HasColumnName("PSUs");
            });

            modelBuilder.Entity<PortedHomePhone>(entity =>
            {
                entity.ToTable("PortedHomePhone");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.PortedHomePhone1)
                    .HasMaxLength(100)
                    .HasColumnName("PortedHomePhone");
            });

            modelBuilder.Entity<PortedMobile>(entity =>
            {
                entity.ToTable("PortedMobile");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PortedMobile1)
                    .HasMaxLength(100)
                    .HasColumnName("PortedMobile");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProviderName).HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleName).HasMaxLength(100);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StateName).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
