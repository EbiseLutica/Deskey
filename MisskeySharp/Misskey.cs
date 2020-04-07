using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MisskeySharp
{
    public sealed class Misskey
    {
        public Credential Credential { get; private set; }

        public Misskey(Credential credential)
        {
            Credential = credential;
        }

        public static async ValueTask<(App, Session)> CreateAppAndSessionAsync(string host, string name, string description, string callbackUrl, params string[] permissions)
        {
            var app = await PostAsync<App>($"{host}/app/create", new Dictionary<string, object>
            {
                { "name", name },
                { "description", description },
                { "callbackUrl", callbackUrl },
                { "name", name },
                { "permission", permissions },
            });

            return (app, await PostAsync<Session>($"{host}/session/generate", new Dictionary<string, object>
            {
                { "appSecret", app.Secret }
            }));
        }

        public static async ValueTask<Misskey> AuthorizeAsync(string host, App app, Session session)
        {
            var userKey = await PostAsync<UserKey>($"{host}/session/userkey", new Dictionary<string, object>
            {
                { "appSecret", app.Secret },
                { "token", session.Token },
            });

            using var sha256 = SHA256.Create();

            var token = string.Concat(sha256
                    .ComputeHash(Encoding.UTF8.GetBytes(session.Token + app.Secret))
                    .Select(i => i.ToString("x2")));

            var cred = new Credential
            {
                Host = host,
                Token = token,
                UserCache = userKey.User,
            };

            return new Misskey(cred);
        }

        public ValueTask<T> CallApiAsync<T>(string path, Dictionary<string, object>? options = null)
        {
            options ??= new Dictionary<string, object>();
a
            if (this.Credential != null)
            {
                options["i"] = this.Credential.Token;
            }

            return PostAsync<T>(BuildPath(path), options);
        }

        public static async ValueTask<T> PostAsync<T>(string url, Dictionary<string, object>? options = null)
        {
            var opts = JsonSerializer.SerializeToUtf8Bytes(options);
            var res = await http.PostAsync(url, new ByteArrayContent(opts));
            return await JsonSerializer.DeserializeAsync<T>(await res.Content.ReadAsStreamAsync(), new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        public static async ValueTask<T> GetAsync<T>(string url)
        {
            var res = await http.GetAsync(url);
            return await JsonSerializer.DeserializeAsync<T>(await res.Content.ReadAsStreamAsync(), new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        /// <summary>
        /// 指定した URI を各プラットフォームの既定のプログラムで開きます。
        /// </summary>
        /// <param name="uri"></param>
        /// <exception cref="NotSupportedException">お使いのプラットフォームに対応していない場合にスローされます。</exception>
        public static void OpenUri(string uri)
        {
            // from: https://github.com/dotnet/corefx/issues/10361
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo("cmd", $"/c start {uri.Replace("&", "^&")}") { CreateNoWindow = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", uri);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", uri);
            }
            else
            {
                throw new NotSupportedException("このプラットフォームはサポートされていません。");
            }
        }

        /// <summary>
        /// API のパスを生成します。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string BuildPath(string path) => $"{Credential.Host}/{path}";

        private static readonly HttpClient http = new HttpClient();
    }
}
