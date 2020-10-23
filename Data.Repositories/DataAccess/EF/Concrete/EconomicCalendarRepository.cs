using Common.Model.EconomicCalendar.Dto;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Common.Model.EconomicCalendar.Request;
using Common.Model.EconomicCalendar.Response;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class EconomicCalendarRepository : EntityRepositoryBase<EconomicCalendar>, IEconomicCalendarRepository
    {
        private readonly EFDBContext _context;

        public EconomicCalendarRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Ekonomik takvimin widgeti bugün tarihli olanları getirir.
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoEconomicWidget>> GetEconomicCalendarWidget()
        {

            var query = await (from economicCalendar in _context.EconomicCalendar
                               join country in _context.Countries on economicCalendar.CountryId equals country.Id
                               where (economicCalendar.SubjectDateTime >= DateTime.Today && economicCalendar.SubjectDateTime <= DateTime.Today.AddDays(1).AddTicks(-1))
                               select new DtoEconomicWidget
                               {
                                   CountryName = country.Name,
                                   Important = economicCalendar.Importance,
                                   Subject = economicCalendar.Subject,
                                   SubjectDateTime = economicCalendar.SubjectDateTime,
                                   CountryFlagCode = country.FlagCode,
                               }).ToListAsync();
            return query;

        }


    public async Task<List<DtoEconomicCalendar>> EconomicFilter(List<int> countryId, List<int> important, DateTime startDate, DateTime endDate)
{
    var query = await (from economicCalendar in _context.EconomicCalendar
                       join country in _context.Countries on economicCalendar.CountryId equals country.Id
                       where countryId.Contains(country.Id) && important.Contains(economicCalendar.Importance) && (economicCalendar.SubjectDateTime <= endDate && economicCalendar.SubjectDateTime >= startDate)
                       select new DtoEconomicCalendar
                       {
                           Actual = economicCalendar.Actual,
                           Subject = economicCalendar.Subject,
                           Previous = economicCalendar.Previous,
                           Important = economicCalendar.Importance,
                           Forecast = economicCalendar.Forecast,
                           //CurrencyCode = country.Code,
                           Country = country.Name,
                           CountryFlagCode = country.FlagCode,
                           SubjectDateTime = economicCalendar.SubjectDateTime
                       }).ToListAsync();
    return query;
}
    }
}
