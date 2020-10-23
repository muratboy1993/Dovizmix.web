using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model.EconomicCalendar.Request
{
    public class ResCountryManager
    {
        public DateTime SubjectDateTime { get; set; }
        public string CountryName { get; set; }
        public string CountryFlagCode { get; set; }
        public int Important { get; set; }
        public string Subject { get; set; }
        public string CurrencyCode { get; set; }
        //Açıklanan
        public double Actual { get; set; }
        //Beklenen
        public double Forecast { get; set; }
        //Önceki
        public double Previous { get; set; }


    }
}
