using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class RateCard
    {
        public int Id { get; set; }
        public string? Affiliate { get; set; }
        public string? Product { get; set; }
        public string? Psu { get; set; }
        public string? Commission { get; set; }
    }
}
