using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Model.Investment.Dto;
using Data.Entities;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;

namespace Infrastructure.Service.Concrete
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IMapper _mapper;
        private readonly IInvestmentRepository _investmentRepository;

        public InvestmentService(IInvestmentRepository investmentRepository, IMapper mapper)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
        }

        public async Task<int> AddInvestment(DtoAddInvestment model)
        {
            return await _investmentRepository.Add(new Investments
            {
                MarketId = model.MarketId,
                CreatedDateTime = DateTime.Now,
                Amount = model.Amount,
                Note = model.Note,
                UserId = model.UserId,
                Price = model.Price,
                PurchaseDateTime = model.PurchaseDateTime
            });
        }

        public async Task<bool> DeleteInvestment(int investmentId)
        {
            return await _investmentRepository.Delete(investmentId);
        }

        public async Task<List<DtoGetGroupInvestment>> GetAllInvestment(int userId)
        {
            return await _investmentRepository.GetAllInvestment(userId);
        }

        public async Task<DtoGetAllInvestment> GetInvestment(int investmentId)
        {
            return await _investmentRepository.GetInvestment(investmentId);
        }

        public async Task<int> UpdateInvestment(DtoUpdateInvestment model)
        {
            var mapModel = _mapper.Map<Investments>(model);
            return await _investmentRepository.Update(mapModel);
        }
    }
}
