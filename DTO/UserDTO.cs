using System.Text.Json.Serialization;

namespace DuckGame.DTO
{
    public class UserDTO
    {
        public int Id {get; set;}

        [JsonPropertyName("userName")]
        public string UserName {get; set;}

        [JsonPropertyName("password")]
        [JsonIgnore]
        public string Password {get; set;} = "";
        public List<HeroDTO>? Heroes {get; set;}
    }
}