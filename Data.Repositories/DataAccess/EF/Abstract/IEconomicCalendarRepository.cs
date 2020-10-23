using Common.Model.EconomicCalendar.Dto;
using Common.Model.EconomicCalendar.Request;
using Common.Model.EconomicCalendar.Response;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IEconomicCalendarRepository : IEntityRepositoryBase<EconomicCalendar>
    {

        Task<List<DtoEconomicWidget>> GetEconomicCalendarWidget();

        Task<List<DtoEconomicCalendar>> EconomicFilter(List<int> countryId, List<int> important, DateTime startDate, DateTime endDate);
    }
}
