using System.Net.Http;
using System.Threading.Tasks;

namespace Slack.Api {
    public static class SlackClient {
        static HttpClient client = new HttpClient ();

        public static async Task SlashCommandReply (SlashCommandData data, SlashCommandResponse response) {
            await client.PostAsync (data.response_url, new StringContent (response.ToJson ()));
        }
    }
}