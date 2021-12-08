using DigitalOmega.api.Common;
using DigitalOmega.api.Request.PhoneNumber;
using Newtonsoft.Json;

namespace DigitalOmega.api.Request
{
    public class CreatePackageDetailRequest
    {

        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "orderid")]
        public int? OrderId { get; set; }

        [JsonProperty(PropertyName = "pakage")]
        public string? Pakage { get; set; }

        [JsonProperty(PropertyName = "psus")]
        public int? Psus { get; set; }

        [JsonProperty(PropertyName = "dvr")]
        public int? Dvr { get; set; }

        [JsonProperty(PropertyName = "box")]
        public int? Box { get; set; }

        [JsonProperty(PropertyName = "modem")]
        public short? Modem { get; set; }

        [JsonProperty(PropertyName = "wifi")]
        public short? Wifi { get; set; }

        //[JsonProperty(PropertyName = "ported")]
        //public short? Ported { get; set; }

        //[JsonProperty(PropertyName = "portednumber")]
        //public string? PortedNumbers { get; set; }

        //[JsonProperty(PropertyName = "native")]
        //public short? Native { get; set; }

        //[JsonProperty(PropertyName = "nativenumber")]
        ////public string? NativeNumbers { get; set; }
        //public List<GeneralPhone<string>> NativeNumbers { get; set; } = new List<GeneralPhone<string>>();

        [JsonProperty(PropertyName = "portedhomephone")]
        public short? PortedHomePhone { get; set; }

        [JsonProperty(PropertyName = "portedhomephonenumbers")]
        //public string? PortedHomePhoneNumbers { get; set; }
        public List<GeneralPhone<string>> PortedHomePhoneNumbers { get; set; } = new List<GeneralPhone<string>>();

        [JsonProperty(PropertyName = "nativehomephone")]
         public short? NativeHomePhone { get; set; }

        [JsonProperty(PropertyName = "nativehomephonenumbers")]
        //public string? NativeHomePhoneNumbers { get; set; }

        public List<GeneralPhone<string>> NativeHomePhoneNumbers { get; set; } = new List<GeneralPhone<string>>();

        [JsonProperty(PropertyName = "portedmobile")]
        public short? PortedMobile { get; set; }

        [JsonProperty(PropertyName = "portedmobilenumbers")]
       // public string? PortedMobileNumbers { get; set; }
        public List<GeneralPhone<string>> PortedMobileNumbers { get; set; } = new List<GeneralPhone<string>>();

        [JsonProperty(PropertyName = "nativemobile")]
        public short? NativeMobile { get; set; }

        [JsonProperty(PropertyName = "nativemobilenumbers")]
        //public string? NativeMobileNumbers { get; set; }
        public List<GeneralPhone<string>> NativeMobileNumbers { get; set; } = new List<GeneralPhone<string>>();

        //[JsonProperty(PropertyName = "newdevicedetail")]
        //public string? NewDeviceDetail { get; set; }

        //[JsonProperty(PropertyName = "newimei")]
        //public string? NewImei { get; set; }

        //[JsonProperty(PropertyName = "customerDevice")]
        //public string? CustomerDevice { get; set; }

        //[JsonProperty(PropertyName = "customerImei")]
        //public string? CustomerImei { get; set; }

        //[JsonProperty(PropertyName = "noOfDevices")]
        //public int? NoOfDevices { get; set; }

        //[JsonProperty(PropertyName = "devicePackageName")]
        //public string? DevicePackageName { get; set; }

    }
}
