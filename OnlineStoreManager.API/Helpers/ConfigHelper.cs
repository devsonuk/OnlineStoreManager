using System.Configuration;

namespace OnlineStoreManager.API.Helpers
{
    public class ConfigHelper
    {
        public static double GetTaxRate()
        {
            string rateText = ConfigurationManager.AppSettings["taxRate"];

            bool isValidTax = double.TryParse(rateText, out double rate);

            return isValidTax == false ? throw new ConfigurationErrorsException("The tax rate is not set up properly.") : rate;
        }
    }
}