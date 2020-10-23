using System;

namespace Common.Model.EconomicCalendar.Dto
{
    public class DtoEconomicCalendar
    {

        public string Country { get; set; }

        public string Subject { get; set; }

        public int Important { get; set; }

        public string CurrencyCode { get; set; }

        public DateTime SubjectDateTime { get; set; }

        public string CountryFlagCode { get; set; }

        //Açıklanan
        public double Actual { get; set; }
        //Beklenen
        public double Forecast { get; set; }
        //Önceki
        public double Previous { get; set; }

    }
}
