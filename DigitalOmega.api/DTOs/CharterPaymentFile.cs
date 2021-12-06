using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class CharterPaymentFile
    {
        public string? LegacyMso { get; set; }
        public string? FiscalMonth { get; set; }
        public string? ClosedDate { get; set; }
        public string? DueDate { get; set; }
        public string? ChrSalesId { get; set; }
        public string? AffiliateName { get; set; }
        public string? AccountNo { get; set; }
        public string? WoNumber { get; set; }
        public string? BundleName { get; set; }
        public string? PaymentTier { get; set; }
        public string? BountyRate { get; set; }
        public string? Proration { get; set; }
        public string? BonusAmount { get; set; }
        public string? BountyAmount { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? VendorId { get; set; }
        public string? VideoPsu { get; set; }
        public string? InternetPsu { get; set; }
        public string? VoicePsu { get; set; }
        public string? Quantity { get; set; }
        public string? Direction { get; set; }
        public string? MobilePsu { get; set; }
        public string? MobileLines { get; set; }
        public string? Smpp { get; set; }
        public string? MobileBounty { get; set; }
        public string? LineBonus { get; set; }
        public string? SmppBonus { get; set; }
        public string? SalesPerson { get; set; }
        public string? Transid { get; set; }
        public string? Directory { get; set; }
        public DateTime? PaymentFileDate { get; set; }
    }
}
