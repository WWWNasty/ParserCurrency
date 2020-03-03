using BusinessLogicLayer.Abstraction.Interfaces.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BusinessLogicLayer.Implementation.Services.Commands
{
    public abstract class BaseCommand : IBaseCommand
    {
        public abstract string Name { get; }

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command)
        {
            return command.Contains(this.Name) && command.Contains(TelegramSettings.Name);
        }
    }
}