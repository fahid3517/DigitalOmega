using DigitalOmega.api.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreateOrderRequest 
    {


        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        //[JsonProperty(PropertyName = "customerId")]
        //public int? CustomerId { get; set; }

        //[JsonProperty(PropertyName = "mso")]
        //public string? Mso { get; set; }

        [JsonProperty(PropertyName = "agnetid")]
        public string? AgentId { get; set; }

        [JsonProperty(PropertyName = "agent")]
        public string? Agent { get; set; }

        //[JsonProperty(PropertyName = "saletechcode")]
        //public string? SaleTechCode { get; set; }

        [JsonProperty(PropertyName = "provider")]
        public string? Provider { get; set; }

        [JsonProperty(PropertyName = "affiliate")]
        public string? Affiliate { get; set; }

        [JsonProperty(PropertyName = "accountnumber")]
        public string? AccountNumber { get; set; }

        [JsonProperty(PropertyName = "btn")]
        public string? Btn { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string? WorkOrderNumber { get; set; }

        [JsonProperty(PropertyName = "orderconfirmayionnumber")]
        public string? OrderConfirmationNumber { get; set; }

        [JsonProperty(PropertyName = "paymenttype")]
        public string? PaymentType { get; set; }

        [JsonProperty(PropertyName = "saledate")]
        public DateTime? SaleDate { get; set; }

        [JsonProperty(PropertyName = "installationtype")]
        public string? InstallationType { get; set; }

        [JsonProperty(PropertyName = "orderinstallationdate")]
        public DateTime? OrderInstallationDate { get; set; }

        [JsonProperty(PropertyName = "orderinstallationtime")]
        public string? OrderInstallationTime { get; set; }

        //[JsonProperty(PropertyName = "actualinstallationdate")]
        //public DateTime? ActualInstallationDate { get; set; }

        //[JsonProperty(PropertyName = "fiscalmonth")]
        //public string? FiscalMonth { get; set; }

        //[JsonProperty(PropertyName = "disconnectdate")]
        //public DateTime? DisconnectDate { get; set; }

        [JsonProperty(PropertyName = "salesource")]
        public string? SaleSource { get; set; }

        //[JsonProperty(PropertyName = "orderstatus")]
        //public string? OrderStatus { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public string? Comments { get; set; }

        //[JsonProperty(PropertyName = "create")]
        //public DateTime? CreatedAt { get; set; }

        //[JsonProperty(PropertyName = "createby")]
        //public string? CreatedBy { get; set; }

        //[JsonProperty(PropertyName = "orderid")]
        //public Guid? OrderId { get; set; }

        //[JsonProperty(PropertyName = "custid")]
        //public Guid? CustId { get; set; }

       
        public CreatePackageDetailRequest? PackageDetail { get; set; }
        



    }
}
