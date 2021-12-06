using System;
using System.Collections.Generic;

namespace DigitalOmega.api.DTOs
{
    public partial class User
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public short? Active { get; set; }
        public DateTime? DeactivatedAt { get; set; }
        public string? DeactivatedBy { get; set; }

        public Guid GId { get; set; }
    }
}
