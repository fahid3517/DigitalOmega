using System;
using System.Collections.Generic;

namespace DigitalOmega.api.Models​
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public bool IsEnable { get; set; }
    }
}
