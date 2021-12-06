using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class CharterReportHistory
    {
        public string? FiscalMonth { get; set; }
        public string? AgentFullName { get; set; }
        public string? AgentSaleTechId { get; set; }
        public string? AccountNumber { get; set; }
        public string? Won { get; set; }
        public DateTime? SaleDate { get; set; }
        public DateTime? ConnectDate { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? DisconnectDate { get; set; }
        public string? CustomerName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? Mso { get; set; }
        public string? Psu { get; set; }
        public short? Connect { get; set; }
        public short? Cancel { get; set; }
        public short? Pending { get; set; }
        public short? Disconnect { get; set; }
        public DateTime? CloseDate { get; set; }
        public string? CancelationReason { get; set; }
        public DateTime? UpdateThrough { get; set; }
        public string? Manager { get; set; }
    }
}
