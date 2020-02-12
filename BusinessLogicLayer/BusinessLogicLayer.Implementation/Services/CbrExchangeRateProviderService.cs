using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos.Cbr;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Implementation.Services
{
    public class CbrExchangeRateProviderService: ICurrencyProvider
    {
        private IMapper _mapper;
        private IConfiguration _configuration;

        public CbrExchangeRateProviderService(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;

            _configuration = configuration;
        }
        
        public IEnumerable<CurrencyExchangeRate> GetExchangeRate()
        {
            /*CbrResponse cbrResponse = _configuration["Config:LinqCbr"].GetJsonAsync<CbrResponse>();

            return _mapper.Map<IEnumerable<CurrencyExchangeRate>>;*/

            return null;
        }
    }
}