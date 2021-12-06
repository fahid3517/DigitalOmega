using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class Agent
    {
        public int Id { get; set; }
        public string? AgentId { get; set; }
        public string? Affiliate { get; set; }
        public string? UserId { get; set; }
        public string? RealName { get; set; }
        public string? AgentName { get; set; }
        public short? Live { get; set; }
        public DateTime? LiveDate { get; set; }
        public string? DialerId { get; set; }
        public short? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DeactivatedAt { get; set; }
        public string? DeactivatedBy { get; set; }

        public Guid? GId { get; set; }
    }
}
