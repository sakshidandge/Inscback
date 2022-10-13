using System;
using System.Collections.Generic;

namespace Working.Models
{
    public partial class Insurance
    {
        public int Insuranceid { get; set; }
        public int? Empid { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Insurancefor { get; set; }
        public string Instatus { get; set; }
        public string History { get; set; }

        public Login Emp { get; set; }
    }
}
