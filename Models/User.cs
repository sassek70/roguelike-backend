namespace DuckGame.Models.PlayerInfo
{
    public class User
    {
        public int UserId {get; set;}
        public string UserName {get; set;}
        public string Password {get; set;}
        public int SavedHeroId1 {get; set;}
        public int SavedHeroId2 {get; set;}
        public int SavedHeroId3 {get; set;}

        public ICollection<Hero> Heroes {get; set;}

    }
}