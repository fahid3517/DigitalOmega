using System;
using System.Collections.Generic;

namespace DigitalOmega.api.Models​
{
    public partial class Package
    {
        public Guid Id { get; set; }
        public string? PackageName { get; set; }
        public string? Abbreviation { get; set; }
        public string? Psus { get; set; }
    }
}
