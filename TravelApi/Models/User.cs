using System;
using System.Collections.Generic;

namespace TravelApi.Models
{
    public partial class User
    {
        public string UserId { get; set; } = null!;
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
