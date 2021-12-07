using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class Disposition
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public string? StatusName { get; set; }
        public short Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public Guid? GId { get; set; }
    }
}
