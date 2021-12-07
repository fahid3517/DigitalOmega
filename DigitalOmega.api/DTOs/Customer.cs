using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? PhoneCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Agent { get; set; }
        public string? Provider { get; set; }
        public string? PreviousProvider { get; set; }
        public DateTime? CustDateTime { get; set; }
        public string? Campaign { get; set; }
        public string? QueGroup { get; set; }
        public string? PhoneLogin { get; set; }
        public string? DialedLabel { get; set; }
        public string? CallId { get; set; }
        public string? LeadId { get; set; }
        public string? ListId { get; set; }
        public string? UserGroup { get; set; }
        public string? Channel { get; set; }
        public string? DispoStatus { get; set; }
        public DateTime? CallbackDatetime { get; set; }
        public string? CallbackType { get; set; }
        public string? CallbackComments { get; set; }
        public string? CallChannel { get; set; }
        public string? AltPhone { get; set; }
        public string? Street { get; set; }
        public string? Appartment { get; set; }
        public string? Address1 { get; set; }
        public string? PostalCode { get; set; }
        public string? Address2 { get; set; }
        public string? AccountNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Email { get; set; }
        public string? VendorLeadCode { get; set; }
        public string? Comments { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public Guid? CusId { get; set; }
    }
}
