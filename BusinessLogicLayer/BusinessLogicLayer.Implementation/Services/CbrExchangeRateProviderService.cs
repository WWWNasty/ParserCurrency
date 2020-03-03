using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos.Cbr;
using DataAccessLayer.Models.Entities;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

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
        
        public async Task<IEnumerable<CurrencyExchangeRate>> GetExchangeRateAsync()
        {
            CbrResponse cbrResponse = await _configuration["Config:LinqCbr"].GetJsonAsync<CbrResponse>();

            Currency[] currencies =
            {

                cbrResponse.Currencies.EUR,
                cbrResponse.Currencies.UAH,
                cbrResponse.Currencies.USD
                
            };

            return _mapper.Map<IEnumerable<CurrencyExchangeRate>>(cbrResponse.Currencies);
        }
        
    }
}