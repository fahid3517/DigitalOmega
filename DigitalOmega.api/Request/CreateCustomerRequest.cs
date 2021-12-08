using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace DigitalOmega.api.Request
{
    public class CreateCustomerRequest
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

       
        [JsonProperty(PropertyName = "title")]
        public string? Title { get; set; }

       
        [JsonProperty(PropertyName = "firstname")]
        public string? FirstName { get; set; }


        [JsonProperty(PropertyName = "middleinitial")]
        public string? MiddleInitial { get; set; }

     
        [JsonProperty(PropertyName = "lastname")]
        public string? LastName { get; set; }


        //[JsonProperty(PropertyName = "gender")]
        //public string? Gender { get; set; }

       
        [JsonProperty(PropertyName = "phonecode")]
        public string? PhoneCode { get; set; }

       
        [JsonProperty(PropertyName = "phonenumber")]
        public string? PhoneNumber { get; set; }

        
        [JsonProperty(PropertyName = "agent")]
        public string? Agent { get; set; }

       
        [JsonProperty(PropertyName = "provider")]
        public string? Provider { get; set; }

       
        [JsonProperty(PropertyName = "previousprovider")]
        public string? PreviousProvider { get; set; }


        //[JsonProperty(PropertyName = "custDateTime")]
        //public DateTime? CustDateTime { get; set; }

        //[JsonProperty(PropertyName = "campaign")]
        //public string? Campaign { get; set; }

        //[JsonProperty(PropertyName = "quegroup")]
        //public string? QueGroup { get; set; }

        //[JsonProperty(PropertyName = "phonelogin")]
        //public string? PhoneLogin { get; set; }

        //[JsonProperty(PropertyName = "dialedlabel")]
        //public string? DialedLabel { get; set; }

        //[JsonProperty(PropertyName = "callId")]
        //public string? CallId { get; set; }

        //[JsonProperty(PropertyName = "leadId")]
        //public string? LeadId { get; set; }

        //[JsonProperty(PropertyName = "listId")]
        //public string? ListId { get; set; }

        //[JsonProperty(PropertyName = "usergroup")]
        //public string? UserGroup { get; set; }

        //[JsonProperty(PropertyName = "channel")]
        //public string? Channel { get; set; }

        //[JsonProperty(PropertyName = "dispostatus")]
        //public string? DispoStatus { get; set; }

        //[JsonProperty(PropertyName = "callbackDatetime")]
        //public DateTime? CallbackDatetime { get; set; }

        //[JsonProperty(PropertyName = "callbackType")]
        //public string? CallbackType { get; set; }

        //[JsonProperty(PropertyName = "callbackComments")]
        //public string? CallbackComments { get; set; }

        //[JsonProperty(PropertyName = "callChannel")]
        //public string? CallChannel { get; set; }

       
        [JsonProperty(PropertyName = "altPhone")]
        public string? AltPhone { get; set; }


        //[JsonProperty(PropertyName = "street")]
        //public string? Street { get; set; }

        //[JsonProperty(PropertyName = "appartment")]
        //public string? Appartment { get; set; }

       
        [JsonProperty(PropertyName = "address1")]
        public string? Address1 { get; set; }

     
        [JsonProperty(PropertyName = "postalCode")]
        public string? PostalCode { get; set; }

       
        [JsonProperty(PropertyName = "address2")]
        public string? Address2 { get; set; }

        [JsonProperty(PropertyName = "accountNumber")]
        public string? AccountNumber { get; set; }

       
        [JsonProperty(PropertyName = "city")]
        public string? City { get; set; }

     
        [JsonProperty(PropertyName = "state")]
        public string? State { get; set; }

   
        [JsonProperty(PropertyName = "email")]
        public string? Email { get; set; }

        //[JsonProperty(PropertyName = "vendorLeadCode")]
        //public string? VendorLeadCode { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public string? Comments { get; set; }

        //[JsonProperty(PropertyName = "createdAt")]
        //public DateTime? CreatedAt { get; set; }

        //[JsonProperty(PropertyName = "createdBy")]
        //public string? CreatedBy { get; set; }

        //[JsonProperty(PropertyName = "customerId")]
        //public Guid? CusId { get; set; }

        public CreateOrderRequest? order { get; set; }
    }
}
