using System.Text.Json.Serialization;

namespace DuckGame.Models.PlayerInfo
{
    public class AuthInfo
    {
        [JsonPropertyName("token")]
        public string Token {get; set;}

        [JsonPropertyName("userId")]
        public int UserId {get; set;}

        [JsonPropertyName("username")]
        public string UserName {get; set;}
    }
}