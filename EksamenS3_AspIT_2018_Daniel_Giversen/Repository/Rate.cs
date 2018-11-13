using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Rate
    {
        #region Fields
        private static List<BaseRate> BaseRateList = new List<BaseRate>() { new BaseRate("DKK", "Danske Kroner"), new BaseRate("EUR", "Euro"), new BaseRate("GBP", "Britiske Pund"), new BaseRate("USD", "Amerikanske Dollars") };

        #endregion

        #region Constructors
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Rate() { }

        /// <summary>
        /// Constructor,that accepts an existing Rate
        /// </summary>
        /// <param name="rate">Rate</param>
        public Rate(Rate rate)
        {
            CurrencyCode = rate.CurrencyCode;
            Value = rate.Value;
        }

        /// <summary>
        /// Constructor used, when receiving data as string from ServerSide
        /// </summary>
        /// <param name="currencyCode">string - abbreviation of currency - 3 character string</param>
        /// <param name="value">string</param>
        public Rate(string currencyCode, string value)
        {
            CurrencyCode = currencyCode;
            Value = Convert.ToDecimal(value);
        }

        /// <summary>
        /// Constructor to create a new rate with data
        /// </summary>
        /// <param name="currencyCode">string - abbreviation of currency - 3 character string</param>
        /// <param name="value">double</param>
        public Rate(string currencyCode, decimal value)
        {
            CurrencyCode = currencyCode;
            Value = value;
        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return CurrencyCode + ": " + Math.Round(Value, 2).ToString("0.##");
        }

        #endregion

        #region Properties
        public string CurrencyCode { get; set; }

        public decimal Value { get; set; }
        #endregion

    }
}
