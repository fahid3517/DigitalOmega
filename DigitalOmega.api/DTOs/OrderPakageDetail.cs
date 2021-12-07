using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class OrderPakageDetail
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string? Pakage { get; set; }
        public int? Psus { get; set; }
        public int? Dvr { get; set; }
        public int? Box { get; set; }
        public short? Modem { get; set; }
        public short? Wifi { get; set; }
        public short? Ported { get; set; }
        public string? PortedNumbers { get; set; }
        public short? Native { get; set; }
        public string? NativeNumbers { get; set; }
        public short? PortedHomePhone { get; set; }
        public string? PortedHomePhoneNumbers { get; set; }
        public short? NativeHomePhone { get; set; }
        public string? NativeHomePhoneNumbers { get; set; }
        public short? PortedMobile { get; set; }
        public string? PortedMobileNumbers { get; set; }
        public short? NativeMobile { get; set; }
        public string? NativeMobileNumbers { get; set; }
        public string? NewDeviceDetail { get; set; }
        public string? NewImei { get; set; }
        public string? CustomerDevice { get; set; }
        public string? CustomerImei { get; set; }
        public int? NoOfDevices { get; set; }
        public string? DevicePackageName { get; set; }

        public Guid? PackageDetailId { get; set; }

        public Guid? OrderGId { get; set; }


    }
}
