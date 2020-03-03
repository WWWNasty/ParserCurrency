using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces.Commands;
using Telegram.Bot;

namespace BusinessLogicLayer.Abstraction.Interfaces
{
    public interface IBotService
    {
        IReadOnlyList<IBaseCommand> Commands();

        Task<TelegramBotClient> Get();
    }
}