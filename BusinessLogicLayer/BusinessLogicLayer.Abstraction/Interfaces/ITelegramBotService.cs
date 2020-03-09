using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces.Commands;
using Telegram.Bot;

namespace BusinessLogicLayer.Abstraction.Interfaces
{
    public interface ITelegramBotService
    {
        IReadOnlyList<IBaseCommand> Commands { get; }

        Task<TelegramBotClient> Get();
    }
}