using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Abstraction.Interfaces
{
    public interface ICurrencyProvider
    {
        Task<IEnumerable<CurrencyExchangeRate>> GetExchangeRateAsync();
    }
}