namespace MisskeySharp
{
    public class UserKey
    {
        public string Token { get; set; } = "";

        #pragma warning disable CS8618
        public User User { get; set; }
    }
}
