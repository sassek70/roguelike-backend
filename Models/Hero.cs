namespace Models.Hero
{
    public class Hero
    {
        public int HeroId {get; set;}
        public int HeroUserId {get; set;}
        public string Name {get; set;}
        public string Class {get; set;}
        public int HeroLevel {get; set;}
        public int TotalHealth {get; set;}
        public int TotalAttack {get; set;}
        public int TotalDefense {get; set;}
        public int TotalBattles {get; set;}
        public int BattlesWon {get; set;}
        public int Deaths {get; set;}
        public int Coins {get; set;}
        public int TotalEquippedWeaponSize {get; set;}
        public int EquippedWeaponId1 {get; set;}
        public int EquippedWeaponId2 {get; set;}
        public int EquippedArmorId1 {get; set;}
        public int EquippedArmorId2 {get; set;}
        public int EquippedArmorId3 {get; set;}
        public int CurrentZone {get; set;}
        public int CurrentNode {get; set;}
    }
}