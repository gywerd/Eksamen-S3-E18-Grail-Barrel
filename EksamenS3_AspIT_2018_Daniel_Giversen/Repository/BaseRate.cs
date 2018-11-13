using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRate
    {
        #region Constructors
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public BaseRate() { }

        /// <summary>
        /// Constructor, that creates a new Base Rate with data
        /// </summary>
        /// <param name="currencyCode">string - abbreviation of currency - 3 character string</param>
        /// <param name="currencyName">string</param>
        public BaseRate(string currencyCode, string currencyName)
        {
            CurrencyCode = currencyCode;
            CurrencyName = currencyName;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Method, that returns main content as a string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return CurrencyName + " (" + CurrencyCode + ")";
        }

        #endregion

        #region Properties
        public string CurrencyCode { get; set; }

        public string CurrencyName { get; set; }
 
        #endregion

    }
}
