using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ParserСurrency
{
    public class Program
    {
        public static void Main()
        {
            Message[] messages = SearchMessage();

            var selectedMessage = from message in messages
                where message.Text.ToLower().Contains("курс валют")
                select message;
            foreach (var massage in selectedMessage)
                Console.WriteLine("{0}", massage);
            
            //CreateHostBuilder(args).Build().Run();


            foreach (var i in messages)
            {
                if (i.Text.ToLower().Contains("курс валют"))
                {
                    Console.WriteLine("{0} ", i);
                }
                
            }
        }

        
        public class Message
        {
            public string Text { get; set; }

            public string Sender { get; set; }
            
            public DateTime Date { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public static Message[] SearchMessage()
        {
        
            Message[] massage = {
                new Message
                {
                    Text = "Курс валюты",
                    Sender = "sender",
                    Date = DateTime.UtcNow
                },
                
                new Message
                {
                    Text = "курс валюточек",
                    Sender = "sender",
                    Date = DateTime.UtcNow
                },
                new Message
                {
                    Text = "text",
                    Sender = "sender",
                    Date = DateTime.UtcNow
                }
            };
            return massage;

        }
    
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}