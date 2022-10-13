using System;
using System.Collections.Generic;

namespace Working.Models
{
    public partial class Login
    {
        public Login()
        {
            Insurance = new HashSet<Insurance>();
        }

        public int Empid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Insurance> Insurance { get; set; }
    }
}
