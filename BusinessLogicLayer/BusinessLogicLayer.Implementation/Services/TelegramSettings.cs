namespace BusinessLogicLayer.Implementation.Services
{
    public class TelegramSettings //https://core.telegram.org/bots/api
    {
        public static string Url { get; set; }  = "http://telegram.me/ExchangeGoBot";

        public static string Name { get; set; } = "ExchangeGoBot";

        public static string Key { get; set; }  = "1098322872:AAG4J-iuIF0K9cSiObVjbPelHKshePX0CXo";
    }
}