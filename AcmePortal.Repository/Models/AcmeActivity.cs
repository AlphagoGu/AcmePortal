using System;
using System.Collections.Generic;

namespace AcmePortal.Repository.Models
{
    public partial class AcmeActivity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Activity { get; set; }
        public string Comments { get; set; }
    }
}
