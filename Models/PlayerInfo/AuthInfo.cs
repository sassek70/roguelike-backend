using System.Text.Json.Serialization;

namespace DuckGame.Models.PlayerInfo
{
    public class AuthInfo
    {
        [JsonPropertyName("token")]
        public required string Token {get; set;}

        [JsonPropertyName("userId")]
        public int UserId {get; set;}

        [JsonPropertyName("username")]
        public required string UserName {get; set;}
    }
}