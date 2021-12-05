using System;
using System.Collections.Generic;

namespace DigitalOmega.api.Models​
{
    public partial class PackageDetail
    {
        public Guid Id { get; set; }
        public Guid? PackageId { get; set; }
        public double? Psus { get; set; }
        public double? Dvr { get; set; }
        public double? Box { get; set; }
        public bool? Modem { get; set; }
        public bool? Wifi { get; set; }
        public Guid? PortedHomePhoneId { get; set; }
        public Guid? NewHomePhoneId { get; set; }
        public Guid? PortedMobileId { get; set; }
        public Guid? NewMobileId { get; set; }
    }
}
