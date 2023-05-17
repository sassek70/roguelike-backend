using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

namespace DuckGame.DTO
{
    public class UserDTO
    {
        public int Id {get; set;}

        [JsonPropertyName("userName")]
        public string UserName {get; set;}

        [Ignore]
        [JsonIgnore]
        [JsonPropertyName("password")]
        public string Password {get; set;} = "";
        public List<HeroDTO>? Heroes {get; set;}
    }
}