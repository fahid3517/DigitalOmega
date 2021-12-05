using System;
using System.Collections.Generic;

namespace DigitalOmega.api.Models​
{
    public partial class Order
    {
        public Guid Id { get; set; }
        public Guid? AgentId { get; set; }
        public Guid? ProviderId { get; set; }
        public Guid? PreviousProviderId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AlternatePhoneNumber { get; set; }
        public string? Email { get; set; }
        public Guid? PackageDetailId { get; set; }
        public string? Btn { get; set; }
        public string? InstallationType { get; set; }
        public DateTime? SaleDate { get; set; }
        public TimeSpan? OrderInstallationTime { get; set; }
        public DateTime? OrderInstallationDate { get; set; }
        public string? SaleSource { get; set; }
        public string? AccountNumber { get; set; }
        public string? WorkOderNumber { get; set; }
        public string? OrderConfirmationNumber { get; set; }
        public string? PaymentType { get; set; }
        public string? Comment { get; set; }
    }
}
