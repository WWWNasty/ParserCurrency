using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Abstraction.Interfaces.Commands;
using DataAccessLayer.Models.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BusinessLogicLayer.Implementation.Services.Commands
{
    public class GetRateCommand : BaseCommand, IGetRateCommand
    {
        private readonly ICurrencyProvider _currencyProviderService;

        public GetRateCommand(ICurrencyProvider currencyProviderService)
        {
            _currencyProviderService = currencyProviderService;

        }

        public override string Name => "hell";
        
        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

//            IEnumerable<CurrencyExchangeRate> exchangeRates = await _currencyProviderService.GetExchangeRateAsync();
//
//            string sendMessage = string.Empty;
//            
//            foreach (var exchangeRate in exchangeRates)
//            {
//                sendMessage += $"{exchangeRate.Name} {exchangeRate.Value}";
//            }
            
            await client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId);

        }
    }
}