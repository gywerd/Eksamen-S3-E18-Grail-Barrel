using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Supplyer
    {
        public string SupplierId { get; set; }
        public string Cvr { get; set; } //CVR-nummer, Company Reference Number, Reference Identification number...
        public string Name { get; set; }
        public Address Address { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}
