using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DuckGame.Models.PlayerInfo
{
    public class Hero
    {
        
        public int Id {get; set;}
        
        [JsonPropertyName("userId")]
        public int UserId {get; set;} //Foreign Key
        
        [JsonIgnore]
        public User User {get; set;} = null!; //defines a one relationship with a User.
        
        [JsonPropertyName("heroName")]
        public required string HeroName {get; set;}
        
        public required string Class {get; set;}
        
        [JsonPropertyName("heroLevel")]
        public int HeroLevel {get; set;} = 1;

        [JsonPropertyName("totalHealth")]
        public int TotalHealth {get; set;} = 50;

        [JsonPropertyName("currentHealth")]
        public int CurrentHealth {get; set;} = 50;

        [JsonPropertyName("totalAttack")]
        public int TotalAttack {get; set;} = 1;

        [JsonPropertyName("totalDefense")]
        public int TotalDefense {get; set;} = 1;

        [JsonPropertyName("totalBattles")]
        public int TotalBattles {get; set;} = 0;

        [JsonPropertyName("battlesWon")]
        public int BattlesWon {get; set;} = 0;
        
        public int Deaths {get; set;}  = 0;
        
        public int Coins {get; set;} = 0;
        
        [JsonPropertyName("totalEquippedWeaponSize")]
        public int TotalEquippedWeaponSize {get; set;} = 0;
        
        [JsonPropertyName("totalEquipedArmorSize")]
        public int TotalEquippedArmorSize {get; set;} = 0;

        [JsonPropertyName("equipedWeaponId")]
        public int EquippedWeaponId {get; set;}

        [JsonPropertyName("equipedWeaponId1")]
        public int EquippedWeaponId1 {get; set;}

        [JsonPropertyName("equipedWeaponId2")]
        public int EquippedWeaponId2 {get; set;}

        [JsonPropertyName("equipedArmorId")]
        public int EquippedArmorId {get; set;}
        
        [JsonPropertyName("equipedArmorId1")]
        public int EquippedArmorId1 {get; set;}

        [JsonPropertyName("equipedArmorId2")]
        public int EquippedArmorId2 {get; set;}

        [JsonPropertyName("equipedArmorId3")]
        public int EquippedArmorId3 {get; set;}

        [JsonPropertyName("currentZone")]
        public int CurrentZone {get; set;} = 1;

        [JsonPropertyName("currentNode")]
        public int CurrentNode {get; set;} = 1;

        [JsonPropertyName("dateLastPlayed")]
        public DateTime DateLastPlayed {get; set;}
        // public required string DateLastPlayed {get; set;} = "";

        // public User User{get; set;} = null!; // Required reference navigation to principal model.
    }
}