using System.Net; //For webclient
using System.Collections.Specialized; //For NameValueCollection

namespace ExternalBrowser
{
    public class DisHook // Origianlly written by: https://github.com/KyeOnDiscord
    {
        public static void SendDiscordWebhook(string URL, string profile, string username, string message)
        {
            NameValueCollection discordValues = new NameValueCollection
            {
                { "username", username },
                { "avatar_url", profile },
                { "content", message }
            };
            new WebClient().UploadValues(URL, discordValues);
        }
    }
}