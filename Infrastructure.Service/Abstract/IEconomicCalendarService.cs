using Common.Model.EconomicCalendar.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IEconomicCalendarService
    {

        Task<List<DtoEconomicCalendar>> EconomicFilter(List<int> countryId, List<int> important, DateTime startDate, DateTime endDate);

        Task<List<DtoEconomicWidget>> GetEconomicCalendarWidget();

        Task<int> AddEconomicCalendar(DtoEconomicCalendar economicCalendar);

       

    }
}
