using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class User
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Credential Credential { get; set; }
    }
}
