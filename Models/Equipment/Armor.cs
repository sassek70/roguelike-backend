namespace DuckGame.Models.Equipment
{
    public class Armor
    {
        public int ArmorId {get; set;}
        public required string ArmorName {get; set;}
        // public int Size {get; set;}
        public int Defense {get; set;}
        public required string ArmorType {get; set;}
    }
}