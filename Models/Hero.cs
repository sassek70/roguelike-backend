using System.ComponentModel.DataAnnotations;

namespace DuckGame.Models.PlayerInfo
{
    public class Hero
    {
        public int HeroId {get; set;}
        public int UserId {get; set;}
        public string Name {get; set;}
        public string Class {get; set;}
        public int HeroLevel {get; set;} = 1;
        public int TotalHealth {get; set;} = 50;
        public int TotalAttack {get; set;} = 1;
        public int TotalDefense {get; set;} = 1;
        public int TotalBattles {get; set;} = 0;
        public int BattlesWon {get; set;} = 0;
        public int Deaths {get; set;}  = 0;
        public int Coins {get; set;} = 0;
        public int TotalEquippedWeaponSize {get; set;} = 0;

        [DisplayFormat(NullDisplayText = "Empty Slot")]
        public int EquippedWeaponId1 {get; set;}

        [DisplayFormat(NullDisplayText = "Empty Slot")]
        public int EquippedWeaponId2 {get; set;}

        [DisplayFormat(NullDisplayText = "Empty Slot")]
        public int EquippedArmorId1 {get; set;}

        [DisplayFormat(NullDisplayText = "Empty Slot")]
        public int EquippedArmorId2 {get; set;}

        [DisplayFormat(NullDisplayText = "Empty Slot")]
        public int EquippedArmorId3 {get; set;}

        [DisplayFormat(NullDisplayText = "Empty Slot")]
        public int CurrentZone {get; set;} = 1;
        public int CurrentNode {get; set;} = 1;
        public DateTime DateLastPlayed {get; set;}

        public User User{get; set;}
    }
}