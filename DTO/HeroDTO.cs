using AutoMapper.Configuration.Annotations;

namespace DuckGame.DTO
{
    public partial class HeroDTO
    {
        [Ignore]
        public int UserId {get; set;} //Foreign Key
        [Ignore]
        public string HeroName {get; set;}
        [Ignore]
        public string Class {get; set;}
        public int HeroLevel {get; set;} = 1;
        public int TotalHealth {get; set;} = 50;
        public int CurrentHealth {get; set;} = 50;
        public int TotalAttack {get; set;} = 1;
        public int TotalDefense {get; set;} = 1;
        public int TotalBattles {get; set;} = 0;
        public int BattlesWon {get; set;} = 0;
        public int Deaths {get; set;}  = 0;
        public int Coins {get; set;} = 0;
        public int TotalEquippedWeaponSize {get; set;} = 0;
        public int TotalEquippedArmorSize {get; set;} = 0;
        public int EquippedWeaponId1 {get; set;}
        public int EquippedWeaponId2 {get; set;}
        public int EquippedArmorId1 {get; set;}
        public int EquippedArmorId2 {get; set;}
        public int EquippedArmorId3 {get; set;}
        public int CurrentZone {get; set;} = 1;
        public int CurrentNode {get; set;} = 1;
        [Ignore]
        public DateTime DateLastPlayed {get; set;}
        // [Ignore]
        // public string DateLastPlayed {get; set;} = "";


    }
}