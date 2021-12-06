using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class PaymentStatus
    {
        public int Id { get; set; }
        public string? Affiliate { get; set; }
        public string? Won { get; set; }
        public string? Psu { get; set; }
        public short? Connect { get; set; }
        public short? Disconnect { get; set; }
        public short? Paid { get; set; }
        public short? Chargeback { get; set; }
        public DateTime? ConnectDate { get; set; }
        public DateTime? DisconnectDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime? ChargebackDate { get; set; }
    }
}
