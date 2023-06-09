using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DuckGame.Models.PlayerInfo
{
    public class User
    {
        public int Id {get; set;}
        
        [JsonPropertyName("userName")]
        public required string UserName {get; set;}

        public string PasswordHash {get; set;} = "";

        // [DisplayFormat(NullDisplayText = "Empty Hero Slot")]
        // public int SavedHeroId1 {get; set;} = 0;

        // [DisplayFormat(NullDisplayText = "Empty Hero Slot")]
        // public int SavedHeroId2 {get; set;} = 0;

        // [DisplayFormat(NullDisplayText = "Empty Hero Slot")]
        // public int SavedHeroId3 {get; set;} = 0;

        public List<Hero>? Heroes {get; set;} // defines a many relationship with Heroes
        // public int HeroId {get; set;} //Foreign Key
        // public Hero Hero {get; set;} = null!; //defines a one relationship with a Hero.
    }
}