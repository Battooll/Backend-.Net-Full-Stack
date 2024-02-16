using System;
using System.Collections.Generic;

namespace FirstProject.ModelsDbFirst
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public double? ClientAmount { get; set; }
        public string? City { get; set; }
    }
}
