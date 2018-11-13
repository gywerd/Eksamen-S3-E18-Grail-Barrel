using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DollarRate
    {
        #region Constructors
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public DollarRate()
        {
        }

        #endregion

        #region Methods
        /// <summary>
        /// Method, that fills Dollar Rate List with data
        /// </summary>
        public void FillListWithDollarRates()
        {
            List<Rate> ld = new List<Rate>();
            foreach (var item in rates)
            {
                Rate cd = new Rate();
                cd.CurrencyCode = item.Key;
                cd.Value = Convert.ToDecimal(item.Value);
                ld.Add(cd);
            }

            RateList = ld;
        }

        /// <summary>
        /// Method, that browses the Rate List to find a specific value
        /// </summary>
        /// <param name="currencyCode">string</param>
        /// <returns>string</returns>
        public string GetRateFromCountryCode(string currencyCode)
        {
            foreach (Rate rate in RateList)
            {
                if (rate.CurrencyCode == currencyCode)
                {
                    return rate.ToString();
                }
            }
            return "The requested currency, " + currencyCode + " is unknown.";
        }

        #endregion

        #region Properties
        public List<Rate> RateList { get;  set; }

        public string disclaimer { get; set; }

        public string licence { get; set; }

        public string timestamp { get; set; }

        public string @base { get; set; }

        public Dictionary<string, decimal> rates
        {
            get
            {
                return rates;
            }
            set
            {
                rates = value;
                FillListWithDollarRates();
            }
        }

        #endregion
    }
}
