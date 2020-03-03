using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Abstraction.Interfaces.Commands;
using BusinessLogicLayer.Implementation.Services.Commands;
using Telegram.Bot;

namespace BusinessLogicLayer.Implementation.Services
{
    public class TelegramBotService
    {
        private readonly IGetRateCommand _getRateCommand;
        
        public TelegramBotService(IGetRateCommand getRateCommand)
        {
            _getRateCommand = getRateCommand;
        }
        private  TelegramBotClient _client;
        private  List<IBaseCommand> _commandsList;

        public  IReadOnlyList<IBaseCommand> Commands => _commandsList.AsReadOnly();

        public  async Task<TelegramBotClient> Get()
        {
            if (_client != null)
            {
                return _client;
            }

            _commandsList = new List<IBaseCommand> {_getRateCommand};
            //TODO: Add more commands

            _client = new TelegramBotClient(TelegramSettings.Key);
            var hook = string.Format(TelegramSettings.Url, "api/message/update");
            await _client.SetWebhookAsync(hook);

            return _client;
        }
    }
}