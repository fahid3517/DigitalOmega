using System;
using System.Collections.Generic;

namespace DigitalOmega.api.Models​
{
    public partial class Dispositon
    {
        public Guid Id { get; set; }
        public string? DispoStatus { get; set; }
        public string? StatusName { get; set; }
    }
}
