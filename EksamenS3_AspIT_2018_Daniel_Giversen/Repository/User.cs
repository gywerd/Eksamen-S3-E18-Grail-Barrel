using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class User : Person
    {
        public string Role { get; set; }
        public Credential Credential { get; set; }
    }
}
