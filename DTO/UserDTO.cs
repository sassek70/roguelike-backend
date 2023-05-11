using System.Text.Json.Serialization;

namespace DuckGame.DTO
{
    public class UserDTO
    {
        [JsonPropertyName("userName")]
        public string UserName {get; set;}

        [JsonPropertyName("password")]
        public string Password {get; set;} = "";
        public List<HeroDTO>? Heroes {get; set;}
    }
}