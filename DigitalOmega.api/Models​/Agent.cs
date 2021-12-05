using System;
using System.Collections.Generic;

namespace DigitalOmega.api.Models​
{
    public partial class Agent
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string? AgentName { get; set; }
        public string? Affiliate { get; set; }
    }
}
