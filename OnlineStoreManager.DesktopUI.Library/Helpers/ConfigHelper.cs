using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public double GetTaxRate()
        {
            string rateText = ConfigurationManager.AppSettings["taxRate"];

            bool isValidTax = double.TryParse(rateText, out double rate);

            return isValidTax == false ? throw new ConfigurationErrorsException("The tax rate is not set up properly.") : rate;
        }
    }
}
