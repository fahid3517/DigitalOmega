using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DigitalOmega.api.DTOs
{
    public partial class do_insightContext : DbContext
    {
        public do_insightContext()
        {
        }

        public do_insightContext(DbContextOptions<do_insightContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Affiliate> Affiliates { get; set; } = null!;
        public virtual DbSet<Agent> Agents { get; set; } = null!;
        public virtual DbSet<CharterPaymentFile> CharterPaymentFiles { get; set; } = null!;
        public virtual DbSet<CharterReport> CharterReports { get; set; } = null!;
        public virtual DbSet<CharterReportHistory> CharterReportHistories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Disposition> Dispositions { get; set; } = null!;
        public virtual DbSet<Ip> Ips { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderPakageDetail> OrderPakageDetails { get; set; } = null!;
        public virtual DbSet<Package> Packages { get; set; } = null!;
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; } = null!;
        public virtual DbSet<ProductsConnected> ProductsConnecteds { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<RateCard> RateCards { get; set; } = null!;
        public virtual DbSet<Raw> Raws { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-SELDJIR;Initial Catalog=do_insight;MultipleActiveResultSets=true;User ID=fahid;Password=1234;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Affiliate>(entity =>
            {
                entity.ToTable("affiliates", "do_insight");

                entity.HasIndex(e => e.AffiliateId, "affiliates$affiliate_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.AffiliateId)
                    .HasMaxLength(255)
                    .HasColumnName("affiliate_id");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.GenericName)
                    .HasMaxLength(255)
                    .HasColumnName("generic_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(0)
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("updated_by");

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("agents", "do_insight");

                entity.HasIndex(e => e.AgentId, "agents$agent_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Affiliate)
                    .HasMaxLength(225)
                    .HasColumnName("affiliate");

                entity.Property(e => e.AgentId)
                    .HasMaxLength(255)
                    .HasColumnName("agent_id");

                entity.Property(e => e.AgentName)
                    .HasMaxLength(255)
                    .HasColumnName("agent_name");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.DeactivatedAt)
                    .HasPrecision(0)
                    .HasColumnName("deactivated_at");

                entity.Property(e => e.DeactivatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("deactivated_by");

                entity.Property(e => e.DialerId)
                    .HasMaxLength(255)
                    .HasColumnName("dialer_id");

                entity.Property(e => e.Live)
                    .HasColumnName("live")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LiveDate)
                    .HasColumnType("date")
                    .HasColumnName("live_date");

                entity.Property(e => e.RealName)
                    .HasMaxLength(255)
                    .HasColumnName("real_name");

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<CharterPaymentFile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("charter_payment_file", "do_insight");

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(255)
                    .HasColumnName("Account_No");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(255)
                    .HasColumnName("Address_Line_2");

                entity.Property(e => e.AffiliateName)
                    .HasMaxLength(255)
                    .HasColumnName("Affiliate_Name");

                entity.Property(e => e.BonusAmount)
                    .HasMaxLength(255)
                    .HasColumnName("Bonus_Amount");

                entity.Property(e => e.BountyAmount)
                    .HasMaxLength(255)
                    .HasColumnName("Bounty_Amount");

                entity.Property(e => e.BountyRate)
                    .HasMaxLength(255)
                    .HasColumnName("Bounty_Rate");

                entity.Property(e => e.BundleName)
                    .HasMaxLength(255)
                    .HasColumnName("Bundle_Name");

                entity.Property(e => e.ChrSalesId)
                    .HasMaxLength(255)
                    .HasColumnName("CHR_Sales_ID");

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.ClosedDate)
                    .HasMaxLength(255)
                    .HasColumnName("Closed_Date");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.Direction).HasMaxLength(255);

                entity.Property(e => e.Directory).HasMaxLength(255);

                entity.Property(e => e.DueDate)
                    .HasMaxLength(255)
                    .HasColumnName("Due_Date");

                entity.Property(e => e.FiscalMonth)
                    .HasMaxLength(255)
                    .HasColumnName("Fiscal_Month");

                entity.Property(e => e.InternetPsu)
                    .HasMaxLength(255)
                    .HasColumnName("Internet_PSU");

                entity.Property(e => e.LegacyMso)
                    .HasMaxLength(255)
                    .HasColumnName("Legacy_MSO");

                entity.Property(e => e.LineBonus)
                    .HasMaxLength(255)
                    .HasColumnName("Line_Bonus");

                entity.Property(e => e.MobileBounty)
                    .HasMaxLength(255)
                    .HasColumnName("Mobile_Bounty");

                entity.Property(e => e.MobileLines)
                    .HasMaxLength(255)
                    .HasColumnName("Mobile_Lines");

                entity.Property(e => e.MobilePsu)
                    .HasMaxLength(255)
                    .HasColumnName("Mobile_PSU");

                entity.Property(e => e.PaymentFileDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_file_date");

                entity.Property(e => e.PaymentTier)
                    .HasMaxLength(255)
                    .HasColumnName("Payment_Tier");

                entity.Property(e => e.Proration).HasMaxLength(255);

                entity.Property(e => e.Quantity).HasMaxLength(255);

                entity.Property(e => e.SalesPerson)
                    .HasMaxLength(255)
                    .HasColumnName("Sales_Person");

                entity.Property(e => e.Smpp)
                    .HasMaxLength(255)
                    .HasColumnName("SMPP");

                entity.Property(e => e.SmppBonus)
                    .HasMaxLength(255)
                    .HasColumnName("SMPP_Bonus");

                entity.Property(e => e.State).HasMaxLength(255);

                entity.Property(e => e.Transid)
                    .HasMaxLength(255)
                    .HasColumnName("TRANSID");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(255)
                    .HasColumnName("Vendor_ID");

                entity.Property(e => e.VideoPsu)
                    .HasMaxLength(255)
                    .HasColumnName("Video_PSU");

                entity.Property(e => e.VoicePsu)
                    .HasMaxLength(255)
                    .HasColumnName("Voice_PSU");

                entity.Property(e => e.WoNumber)
                    .HasMaxLength(255)
                    .HasColumnName("WO_Number");

                entity.Property(e => e.Zip).HasMaxLength(255);
            });

            modelBuilder.Entity<CharterReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("charter_report", "do_insight");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(255)
                    .HasColumnName("account_number");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(255)
                    .HasColumnName("address_line_1");

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(255)
                    .HasColumnName("address_line_2");

                entity.Property(e => e.AgentFullName)
                    .HasMaxLength(255)
                    .HasColumnName("agent_full_name");

                entity.Property(e => e.AgentSaleTechId)
                    .HasMaxLength(255)
                    .HasColumnName("agent_sale_tech_id");

                entity.Property(e => e.Cancel).HasColumnName("cancel");

                entity.Property(e => e.CancelationReason)
                    .HasMaxLength(255)
                    .HasColumnName("cancelation_reason");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("date")
                    .HasColumnName("close_date");

                entity.Property(e => e.Connect).HasColumnName("connect");

                entity.Property(e => e.ConnectDate)
                    .HasColumnType("date")
                    .HasColumnName("connect_date");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_name");

                entity.Property(e => e.Disconnect).HasColumnName("disconnect");

                entity.Property(e => e.DisconnectDate)
                    .HasColumnType("date")
                    .HasColumnName("disconnect_date");

                entity.Property(e => e.FiscalMonth)
                    .HasMaxLength(255)
                    .HasColumnName("fiscal_month");

                entity.Property(e => e.Manager)
                    .HasMaxLength(255)
                    .HasColumnName("manager");

                entity.Property(e => e.Mso)
                    .HasMaxLength(255)
                    .HasColumnName("mso");

                entity.Property(e => e.Pending).HasColumnName("pending");

                entity.Property(e => e.Psu)
                    .HasMaxLength(255)
                    .HasColumnName("psu");

                entity.Property(e => e.SaleDate)
                    .HasColumnType("date")
                    .HasColumnName("sale_date");

                entity.Property(e => e.ScheduleDate)
                    .HasColumnType("date")
                    .HasColumnName("schedule_date");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");

                entity.Property(e => e.UpdateThrough)
                    .HasColumnType("date")
                    .HasColumnName("update_through");

                entity.Property(e => e.Won)
                    .HasMaxLength(255)
                    .HasColumnName("won");

                entity.Property(e => e.Zip)
                    .HasMaxLength(255)
                    .HasColumnName("zip");
            });

            modelBuilder.Entity<CharterReportHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("charter_report_history", "do_insight");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(255)
                    .HasColumnName("account_number");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(255)
                    .HasColumnName("address_line_1");

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(255)
                    .HasColumnName("address_line_2");

                entity.Property(e => e.AgentFullName)
                    .HasMaxLength(255)
                    .HasColumnName("agent_full_name");

                entity.Property(e => e.AgentSaleTechId)
                    .HasMaxLength(255)
                    .HasColumnName("agent_sale_tech_id");

                entity.Property(e => e.Cancel).HasColumnName("cancel");

                entity.Property(e => e.CancelationReason)
                    .HasMaxLength(255)
                    .HasColumnName("cancelation_reason");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("date")
                    .HasColumnName("close_date");

                entity.Property(e => e.Connect).HasColumnName("connect");

                entity.Property(e => e.ConnectDate)
                    .HasColumnType("date")
                    .HasColumnName("connect_date");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_name");

                entity.Property(e => e.Disconnect).HasColumnName("disconnect");

                entity.Property(e => e.DisconnectDate)
                    .HasColumnType("date")
                    .HasColumnName("disconnect_date");

                entity.Property(e => e.FiscalMonth)
                    .HasMaxLength(255)
                    .HasColumnName("fiscal_month");

                entity.Property(e => e.Manager)
                    .HasMaxLength(255)
                    .HasColumnName("manager");

                entity.Property(e => e.Mso)
                    .HasMaxLength(255)
                    .HasColumnName("mso");

                entity.Property(e => e.Pending).HasColumnName("pending");

                entity.Property(e => e.Psu)
                    .HasMaxLength(255)
                    .HasColumnName("psu");

                entity.Property(e => e.SaleDate)
                    .HasColumnType("date")
                    .HasColumnName("sale_date");

                entity.Property(e => e.ScheduleDate)
                    .HasColumnType("date")
                    .HasColumnName("schedule_date");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");

                entity.Property(e => e.UpdateThrough)
                    .HasColumnType("date")
                    .HasColumnName("update_through");

                entity.Property(e => e.Won)
                    .HasMaxLength(255)
                    .HasColumnName("won");

                entity.Property(e => e.Zip)
                    .HasMaxLength(255)
                    .HasColumnName("zip");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers", "do_insight");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(255)
                    .HasColumnName("account_number");

                entity.Property(e => e.Address1)
                    .HasMaxLength(255)
                    .HasColumnName("address1");

                entity.Property(e => e.Address2)
                    .HasMaxLength(255)
                    .HasColumnName("address2");

                entity.Property(e => e.Agent)
                    .HasMaxLength(255)
                    .HasColumnName("agent");

                entity.Property(e => e.AltPhone)
                    .HasMaxLength(255)
                    .HasColumnName("alt_phone");

                entity.Property(e => e.Appartment)
                    .HasMaxLength(255)
                    .HasColumnName("appartment");

                entity.Property(e => e.CallChannel)
                    .HasMaxLength(255)
                    .HasColumnName("call_channel");

                entity.Property(e => e.CallId)
                    .HasMaxLength(255)
                    .HasColumnName("call_id");

                entity.Property(e => e.CallbackComments)
                    .HasMaxLength(255)
                    .HasColumnName("callback_comments");

                entity.Property(e => e.CallbackDatetime)
                    .HasPrecision(0)
                    .HasColumnName("callback_datetime");

                entity.Property(e => e.CallbackType)
                    .HasMaxLength(255)
                    .HasColumnName("callback_type");

                entity.Property(e => e.Campaign)
                    .HasMaxLength(255)
                    .HasColumnName("campaign");

                entity.Property(e => e.Channel)
                    .HasMaxLength(255)
                    .HasColumnName("channel");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .HasColumnName("comments");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CustDateTime)
                    .HasPrecision(0)
                    .HasColumnName("cust_date_time");

                entity.Property(e => e.DialedLabel)
                    .HasMaxLength(255)
                    .HasColumnName("dialed_label");

                entity.Property(e => e.DispoStatus)
                    .HasMaxLength(255)
                    .HasColumnName("dispo_status");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(255)
                    .HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.LeadId)
                    .HasMaxLength(255)
                    .HasColumnName("lead_id");

                entity.Property(e => e.ListId)
                    .HasMaxLength(255)
                    .HasColumnName("list_id");

                entity.Property(e => e.MiddleInitial)
                    .HasMaxLength(255)
                    .HasColumnName("middle_initial");

                entity.Property(e => e.PhoneCode)
                    .HasMaxLength(255)
                    .HasColumnName("phone_code");

                entity.Property(e => e.PhoneLogin)
                    .HasMaxLength(255)
                    .HasColumnName("phone_login");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .HasColumnName("postal_code");

                entity.Property(e => e.PreviousProvider)
                    .HasMaxLength(255)
                    .HasColumnName("previous_provider");

                entity.Property(e => e.Provider)
                    .HasMaxLength(255)
                    .HasColumnName("provider");

                entity.Property(e => e.QueGroup)
                    .HasMaxLength(255)
                    .HasColumnName("que_group");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .HasColumnName("street");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UserGroup)
                    .HasMaxLength(255)
                    .HasColumnName("user_group");

                entity.Property(e => e.VendorLeadCode)
                    .HasMaxLength(255)
                    .HasColumnName("vendor_lead_code");
            });

            modelBuilder.Entity<Disposition>(entity =>
            {
                entity.ToTable("dispositions", "do_insight");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(255)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Ip>(entity =>
            {
                entity.ToTable("ips", "do_insight");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.Ip1)
                    .HasMaxLength(255)
                    .HasColumnName("ip");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders", "do_insight");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(255)
                    .HasColumnName("account_number");

                entity.Property(e => e.ActualInstallationDate)
                    .HasColumnType("date")
                    .HasColumnName("actual_installation_date");

                entity.Property(e => e.Affiliate)
                    .HasMaxLength(255)
                    .HasColumnName("affiliate");

                entity.Property(e => e.Agent)
                    .HasMaxLength(255)
                    .HasColumnName("agent");

                entity.Property(e => e.AgentId)
                    .HasMaxLength(255)
                    .HasColumnName("agent_id");

                entity.Property(e => e.Btn)
                    .HasMaxLength(255)
                    .HasColumnName("btn");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DisconnectDate)
                    .HasColumnType("date")
                    .HasColumnName("disconnect_date");

                entity.Property(e => e.FiscalMonth)
                    .HasMaxLength(255)
                    .HasColumnName("fiscal_month");

                entity.Property(e => e.InstallationType)
                    .HasMaxLength(255)
                    .HasColumnName("installation_type");

                entity.Property(e => e.Mso)
                    .HasMaxLength(255)
                    .HasColumnName("mso");

                entity.Property(e => e.OrderConfirmationNumber)
                    .HasMaxLength(255)
                    .HasColumnName("order_confirmation_number");

                entity.Property(e => e.OrderInstallationDate)
                    .HasColumnType("date")
                    .HasColumnName("order_installation_date");

                entity.Property(e => e.OrderInstallationTime)
                    .HasMaxLength(255)
                    .HasColumnName("order_installation_time");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(255)
                    .HasColumnName("order_status");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(255)
                    .HasColumnName("payment_type");

                entity.Property(e => e.Provider)
                    .HasMaxLength(255)
                    .HasColumnName("provider");

                entity.Property(e => e.SaleDate)
                    .HasColumnType("date")
                    .HasColumnName("sale_date");

                entity.Property(e => e.SaleSource)
                    .HasMaxLength(255)
                    .HasColumnName("sale_source");

                entity.Property(e => e.SaleTechCode)
                    .HasMaxLength(255)
                    .HasColumnName("sale_tech_code");

                entity.Property(e => e.WorkOrderNumber)
                    .HasMaxLength(255)
                    .HasColumnName("work_order_number");
            });

            modelBuilder.Entity<OrderPakageDetail>(entity =>
            {
                entity.ToTable("order_pakage_details", "do_insight");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Box).HasColumnName("box");

                entity.Property(e => e.CustomerDevice)
                    .HasMaxLength(255)
                    .HasColumnName("customer_device");

                entity.Property(e => e.CustomerImei)
                    .HasMaxLength(255)
                    .HasColumnName("customer_imei");

                entity.Property(e => e.DevicePackageName)
                    .HasMaxLength(255)
                    .HasColumnName("device_package_name");

                entity.Property(e => e.Dvr).HasColumnName("dvr");

                entity.Property(e => e.Modem).HasColumnName("modem");

                entity.Property(e => e.Native).HasColumnName("native");

                entity.Property(e => e.NativeHomePhone).HasColumnName("native_home_phone");

                entity.Property(e => e.NativeHomePhoneNumbers)
                    .HasMaxLength(255)
                    .HasColumnName("native_home_phone_numbers");

                entity.Property(e => e.NativeMobile).HasColumnName("native_mobile");

                entity.Property(e => e.NativeMobileNumbers)
                    .HasMaxLength(255)
                    .HasColumnName("native_mobile_numbers");

                entity.Property(e => e.NativeNumbers)
                    .HasMaxLength(255)
                    .HasColumnName("native_numbers");

                entity.Property(e => e.NewDeviceDetail)
                    .HasMaxLength(255)
                    .HasColumnName("new_device_detail");

                entity.Property(e => e.NewImei)
                    .HasMaxLength(255)
                    .HasColumnName("new_imei");

                entity.Property(e => e.NoOfDevices).HasColumnName("no_of_devices");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Pakage)
                    .HasMaxLength(255)
                    .HasColumnName("pakage");

                entity.Property(e => e.Ported).HasColumnName("ported");

                entity.Property(e => e.PortedHomePhone).HasColumnName("ported_home_phone");

                entity.Property(e => e.PortedHomePhoneNumbers)
                    .HasMaxLength(255)
                    .HasColumnName("ported_home_phone_numbers");

                entity.Property(e => e.PortedMobile).HasColumnName("ported_mobile");

                entity.Property(e => e.PortedMobileNumbers)
                    .HasMaxLength(255)
                    .HasColumnName("ported_mobile_numbers");

                entity.Property(e => e.PortedNumbers)
                    .HasMaxLength(255)
                    .HasColumnName("ported_numbers");

                entity.Property(e => e.Psus).HasColumnName("psus");

                entity.Property(e => e.Wifi).HasColumnName("wifi");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("packages", "do_insight");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(255)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Box).HasColumnName("box");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.DeactivatedAt)
                    .HasPrecision(0)
                    .HasColumnName("deactivated_at");

                entity.Property(e => e.DeactivatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("deactivated_by");

                entity.Property(e => e.Dvr).HasColumnName("dvr");

                entity.Property(e => e.Modem).HasColumnName("modem");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NativeHomePhone).HasColumnName("native_home_phone");

                entity.Property(e => e.NativeMobile).HasColumnName("native_mobile");

                entity.Property(e => e.PortedHomePhone).HasColumnName("ported_home_phone");

                entity.Property(e => e.PortedMobile).HasColumnName("ported_mobile");

                entity.Property(e => e.Psus).HasColumnName("psus");

                entity.Property(e => e.Wifi).HasColumnName("wifi");
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.ToTable("payment_status", "do_insight");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Affiliate)
                    .HasMaxLength(255)
                    .HasColumnName("affiliate");

                entity.Property(e => e.Chargeback)
                    .HasColumnName("chargeback")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ChargebackDate)
                    .HasColumnType("date")
                    .HasColumnName("chargeback_date");

                entity.Property(e => e.Connect)
                    .HasColumnName("connect")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConnectDate)
                    .HasColumnType("date")
                    .HasColumnName("connect_date");

                entity.Property(e => e.Disconnect)
                    .HasColumnName("disconnect")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DisconnectDate)
                    .HasColumnType("date")
                    .HasColumnName("disconnect_date");

                entity.Property(e => e.Paid)
                    .HasColumnName("paid")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PaidDate)
                    .HasColumnType("date")
                    .HasColumnName("paid_date");

                entity.Property(e => e.Psu)
                    .HasMaxLength(255)
                    .HasColumnName("psu");

                entity.Property(e => e.Won)
                    .HasMaxLength(255)
                    .HasColumnName("won");
            });

            modelBuilder.Entity<ProductsConnected>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("products_connected", "do_insight");

                entity.Property(e => e.ConnectDate)
                    .HasColumnType("date")
                    .HasColumnName("connect_date");

                entity.Property(e => e.Psu)
                    .HasMaxLength(255)
                    .HasColumnName("psu");

                entity.Property(e => e.Won)
                    .HasMaxLength(255)
                    .HasColumnName("won");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("providers", "do_insight");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.DeactivatedAt)
                    .HasPrecision(0)
                    .HasColumnName("deactivated_at");

                entity.Property(e => e.DeactivatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("deactivated_by");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RateCard>(entity =>
            {
                entity.ToTable("rate_card", "do_insight");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Affiliate)
                    .HasMaxLength(255)
                    .HasColumnName("affiliate");

                entity.Property(e => e.Commission)
                    .HasMaxLength(255)
                    .HasColumnName("commission");

                entity.Property(e => e.Product)
                    .HasMaxLength(255)
                    .HasColumnName("product");

                entity.Property(e => e.Psu)
                    .HasMaxLength(255)
                    .HasColumnName("psu");
            });

            modelBuilder.Entity<Raw>(entity =>
            {
                entity.ToTable("raw", "do_insight");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Won)
                    .HasMaxLength(255)
                    .HasColumnName("won");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("table");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "do_insight");

                entity.HasIndex(e => e.UserId, "users$user_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(0)
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.DeactivatedAt)
                    .HasPrecision(0)
                    .HasColumnName("deactivated_at");

                entity.Property(e => e.DeactivatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("deactivated_by");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
