using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

namespace WebApplication.Api.Controllers
{
    [ApiController]
    public class CurrencyBotController : ControllerBase
    {
       

        private readonly ITelegramBotService _telegramBotService;

        private readonly ILogger<CurrencyBotController> _logger;

        public CurrencyBotController(ILogger<CurrencyBotController> logger, ITelegramBotService telegramBotService)
        {
            _logger = logger;
            _telegramBotService = telegramBotService;
        }

        [Route(@"api/message/update")] //webhook uri part
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = _telegramBotService.Commands;
            var message  = update.Message;
            var client   = await _telegramBotService.Get();

            foreach(var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    break;
                }
            }
            
            return Ok();
        }
        
    }
}