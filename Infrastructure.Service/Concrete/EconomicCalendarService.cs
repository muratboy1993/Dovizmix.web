using AutoMapper;
using Common.Model.EconomicCalendar.Dto;
using Common.Model.EconomicCalendar.Request;
using Common.Model.EconomicCalendar.Response;
using Data.Entities;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
    public class EconomicCalendarService : IEconomicCalendarService
    {

        private readonly IEconomicCalendarRepository _economicCalendarRepository;
        private readonly IMapper _mapper;

        public EconomicCalendarService(IEconomicCalendarRepository economicCalendarRepository, IMapper mapper)
        {

            _economicCalendarRepository = economicCalendarRepository;
            _mapper = mapper;

        }
       
        public async Task<int> AddEconomicCalendar(DtoEconomicCalendar economicCalendar)
        {

            return await _economicCalendarRepository.Add(new EconomicCalendar
            {

                Subject = economicCalendar.Subject,

                Importance = economicCalendar.Important,

                SubjectDateTime = DateTime.Now,

                Actual = economicCalendar.Actual,

                Forecast = economicCalendar.Forecast,

                Previous = economicCalendar.Previous,



            });
        }

        public async Task<List<DtoEconomicCalendar>> EconomicFilter(List<int> countryId, List<int> important, DateTime startDate, DateTime endDate)
        {
            return await _economicCalendarRepository.EconomicFilter(countryId, important, startDate, endDate);
        }


        public async Task<List<DtoEconomicWidget>> GetEconomicCalendarWidget()
        {
            return await _economicCalendarRepository.GetEconomicCalendarWidget();
        }
    }
}