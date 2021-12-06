using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class Ip
    {
        public int Id { get; set; }
        public string? Ip1 { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}
