using Newtonsoft.Json;

namespace Slack.Api {
    public class SlashCommandResponse {
        public string response_type { get; set; }

        public string text { get; set; }

        public string ToJson () {
            return Newtonsoft.Json.JsonConvert.SerializeObject (this);
        }
    }
}