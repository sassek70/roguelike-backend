using System.ComponentModel.DataAnnotations;

namespace DuckGame.Models.PlayerInfo
{
    public class User
    {
        public int UserId {get; set;}
        public string UserName {get; set;}
        // public string Password {get; set;}

        [DisplayFormat(NullDisplayText = "Empty Hero Slot")]
        public int SavedHeroId1 {get; set;}

        [DisplayFormat(NullDisplayText = "Empty Hero Slot")]
        public int SavedHeroId2 {get; set;}

        [DisplayFormat(NullDisplayText = "Empty Hero Slot")]
        public int SavedHeroId3 {get; set;}

        public ICollection<Hero> Heroes {get; set;}

    }
}