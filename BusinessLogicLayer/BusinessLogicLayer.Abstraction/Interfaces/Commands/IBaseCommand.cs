using Telegram.Bot;
using Telegram.Bot.Types;

namespace BusinessLogicLayer.Abstraction.Interfaces.Commands
{
    public interface IBaseCommand
    {
        string Name { get; }
        
        void Execute(Message message, TelegramBotClient client);
        
        bool Contains(string command);
    }
}