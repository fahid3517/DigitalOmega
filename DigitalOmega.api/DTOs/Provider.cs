using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class Provider
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public short? Active { get; set; }
        public DateTime? DeactivatedAt { get; set; }
        public string? DeactivatedBy { get; set; }

        public Guid? GId { get; set; }

    }
}
