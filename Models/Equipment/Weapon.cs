namespace DuckGame.Models.Equipment
{
    public class Weapon
    {
        public int WeaponId {get; set;}
        public required string WeaponName {get; set;}
        // public int Size {get; set;}
        public int Attack {get; set;}
        public required string WeaponType {get; set;}
    }
}