namespace MisskeySharp
{
    public class App
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string CallbackUrl { get; set; } = "";
        public string[] Permission { get; set; } = new string[0];
        public string Secret { get; set; } = ""; 
    }
}
