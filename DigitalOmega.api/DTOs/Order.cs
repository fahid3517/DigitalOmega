using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string? Mso { get; set; }
        public string? AgentId { get; set; }
        public string? Agent { get; set; }
        public string? SaleTechCode { get; set; }
        public string? Provider { get; set; }
        public string? Affiliate { get; set; }
        public string? AccountNumber { get; set; }
        public string? Btn { get; set; }
        public string? WorkOrderNumber { get; set; }
        public string? OrderConfirmationNumber { get; set; }
        public string? PaymentType { get; set; }
        public DateTime? SaleDate { get; set; }
        public string? InstallationType { get; set; }
        public DateTime? OrderInstallationDate { get; set; }
        public string? OrderInstallationTime { get; set; }
        public DateTime? ActualInstallationDate { get; set; }
        public string? FiscalMonth { get; set; }
        public DateTime? DisconnectDate { get; set; }
        public string? SaleSource { get; set; }
        public string? OrderStatus { get; set; }
        public string? Comments { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public Guid? OrderId { get; set; }
        public  Guid? CustId { get; set; }
    }
}
