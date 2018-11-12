using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Credential
    {
        #region Properties
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public bool Active { get; set; }

        #endregion

        #region Methods
        public bool CheckCredentials()
        {
            bool result = false;

            return result;
        }
        #endregion
    }
}
