using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class Affiliate
    {
        public int Id { get; set; }
        public string? AffiliateId { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? GenericName { get; set; }
        public string? Address { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public short? Active { get; set; }
    }
}
