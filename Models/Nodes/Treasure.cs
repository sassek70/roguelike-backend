namespace DuckGame.Models.Nodes
{
    public class Treasure
    {
        public int? WeaponId {get; set;}
        public int? ArmorId {get; set;}
        public int NumberOfItems {get; set;} = 1;
        public int CoinTotal {get; set;}
    }
}