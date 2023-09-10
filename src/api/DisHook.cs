using System.Net; //For webclient
using System.Collections.Specialized; //For NameValueCollection

namespace ExternalBrowser
{
    public class DisHook
    {
        public static void SendDiscordWebhook(string URL, string profilepic, string username, string message)
        {
            NameValueCollection discordValues = new NameValueCollection
            {
                { "username", username },
                { "avatar_url", profilepic },
                { "content", message }
            };
            new WebClient().UploadValues(URL, discordValues);
        }
    }
}