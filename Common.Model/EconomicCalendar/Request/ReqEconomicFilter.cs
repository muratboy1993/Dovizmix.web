using System;
using System.Collections.Generic;

namespace Common.Model.EconomicCalendar.Request
{
    public class ReqEconomicFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> CountryId { get; set; }
        public List<int> Important { get; set; }
    }
}
