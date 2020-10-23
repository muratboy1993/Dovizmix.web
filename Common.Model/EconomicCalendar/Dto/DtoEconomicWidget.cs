using System;

namespace Common.Model.EconomicCalendar.Dto
{
   public class DtoEconomicWidget
    {
        public string CountryName { get; set; }

        public string CountryFlagCode { get; set; }

        public string CountryCurrencyCode { get; set; }

        public string CurrencyName { get; set; }

        public string Subject { get; set; }

        public int Important { get; set; }

        public DateTime SubjectDateTime { get; set; }
    }
}
