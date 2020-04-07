namespace MisskeySharp
{
    public class Credential
    {
        public string Host { get; set; } = "";
        public string Token { get; set; } = "";
        public User? UserCache { get; set; }
    }
}
