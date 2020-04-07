using System;
using System.Web;

namespace MisskeySharp
{
    public class MiAuthSession
    {
        public Guid Id { get; set; }
        public string Host { get; set; } = "";
        public string Name { get; set; } = "";
        public string IconUrl { get; set; } = "";
        public string Redirect { get; set; } = "";
        public string[] Permissions { get; set; } = new string[0];
        public string Uri => $"{Host}/miauth/{Id.ToString()}?name={HttpUtility.UrlEncode(Name)}&iconUrl={HttpUtility.UrlEncode(IconUrl)}&redirect={HttpUtility.UrlEncode(Redirect)}&permission={string.Join(',', Permissions)}";

        public MiAuthSession(string host, string name, string iconUrl, string redirect, params string[] permissions)
        {
            Id = Guid.NewGuid();
            Host = host;
            Name = name;
            IconUrl = iconUrl;
            Redirect = redirect;
            Permissions = permissions;
        }
    }
}
