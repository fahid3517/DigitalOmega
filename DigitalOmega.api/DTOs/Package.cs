using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class Package
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Abbreviation { get; set; }
        public int? Psus { get; set; }
        public short? Dvr { get; set; }
        public short? Box { get; set; }
        public short? Modem { get; set; }
        public short? Wifi { get; set; }
        public short? PortedHomePhone { get; set; }
        public short? NativeHomePhone { get; set; }
        public short? PortedMobile { get; set; }
        public short? NativeMobile { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public short? Active { get; set; }
        public DateTime? DeactivatedAt { get; set; }
        public string? DeactivatedBy { get; set; }

        public Guid? GId { get; set; }
    }
}
