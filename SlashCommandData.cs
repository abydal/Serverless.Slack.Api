using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Slack.Api {
    public class SlashCommandData {
        public string token { get; set; }
        public string team_id { get; set; }
        public string team_domain { get; set; }
        public string channel_id { get; set; }
        public string channel_name { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string command { get; set; }
        public string text { get; set; }
        public string response_url { get; set; }

        public string ToJson () {
            return Newtonsoft.Json.JsonConvert.SerializeObject (this);
        }
    }

    public static class SlashCommandDataExtensions {
        public static async Task<SlashCommandData> GetSlackData (this HttpRequest req) {
            string requestBody = await new StreamReader (req.Body).ReadToEndAsync ();
            NameValueCollection coll = HttpUtility.ParseQueryString (requestBody);

            return new SlashCommandData {
                token = coll["token"],
                    team_id = coll["team_id"],
                    team_domain = coll["team_domain"],
                    channel_id = coll["channel_id"],
                    channel_name = coll["channel_name"],
                    user_id = coll["user_id"],
                    user_name = coll["user_name"],
                    command = coll["command"],
                    text = coll["text"],
                    response_url = coll["response_url"]
            };
        }
    }
}