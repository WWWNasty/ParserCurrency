namespace BusinessLogicLayer.Implementation.Services
{
    public static class TelegramSettings //https://pursercurrancy.herokuapp.com/
    {
        public static string UrlFormat { get; set; }  = "https://pursercurrancy.herokuapp.com/{0}";

        public static string Name { get; set; } = "ExchangeGoBot";

        public static string Key { get; set; }  = "1098322872:AAG4J-iuIF0K9cSiObVjbPelHKshePX0CXo";
    }
}