using System.Collections.Generic;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Abstraction.Interfaces
{
    public interface ICurrencyProvider
    {
        IEnumerable<CurrencyExchangeRate> GetExchangeRate();
    }
}