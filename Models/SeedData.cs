using Microsoft.EntityFrameworkCore;
using DuckGame.Data;
using DuckGame.Models.PlayerInfo;
using DuckGame.Models.Nodes;
using DuckGame.Models.Equipment;

namespace DuckGame.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContextEntity(serviceProvider.GetRequiredService<DbContextOptions<DataContextEntity>>()))
            {
                if (context == null || context.Users == null || context.Heroes == null || context.Shops == null || context.Treasures == null || context.Enemies == null || context.Weapons == null || context.Armors == null)
                {
                    throw new ArgumentNullException("Null Context");
                }

                if (context.Users.Any() || context.Heroes.Any() || context.Shops.Any() || context.Treasures.Any() || context.Enemies.Any() || context.Weapons.Any() || context.Armors.Any())
                {
                    return; // exists seed process if existing data is found.
                }

                context.Users.AddRange(
                    new User 
                    {
                        // UserId = 1,
                        UserName = "Kevin",
                        // SavedHeroId1 = 0,
                    },
                    
                    new User 
                    {
                        // UserId = 2,
                        UserName = "Test",
                        // SavedHeroId1 = 1,
                    }
                );

                context.Weapons.AddRange(
                    new Weapon
                    {
                        // WeaponId = 1,
                        WeaponName = "Fresh Reed",
                        Size = 1,
                        Attack = 1,
                        WeaponType = "Melee"
                    },
                    
                    new Weapon
                    {
                        // WeaponId = 2,
                        WeaponName = "Stone",
                        Size = 2,
                        Attack = 3,
                        WeaponType = "Ranged"
                    },
                    
                    new Weapon
                    {
                        // WeaponId = 3,
                        WeaponName = "Duck Bill",
                        Size = 1,
                        Attack = 1,
                        WeaponType = "Melee"
                    }
                );

                context.Armors.AddRange(
                    new Armor
                    {
                        // ArmorId = 1,
                        ArmorName = "Lillipad Hat",
                        Size = 1,
                        Defense = 1,
                        ArmorType = "Helmet"
                    },

                    new Armor
                    {
                        // ArmorId = 2,
                        ArmorName = "Grass Feathers",
                        Size = 1, 
                        Defense = 1,
                        ArmorType = "Gloves",
                    },

                    new Armor
                    {
                        // ArmorId = 3,
                        ArmorName = "Mud Boots",
                        Size = 1,
                        Defense = 2,
                        ArmorType = "Boots"
                    }
                );

                context.Heroes.AddRange(
                    new Hero
                    {
                        // HeroId = 1,
                        UserId = 1,
                        HeroName = "Jimmy",
                        Class = "Warrior",
                        HeroLevel = 3,
                        TotalHealth = 20,
                        TotalAttack = 1,
                        TotalDefense = 3,
                        TotalBattles = 1,
                        BattlesWon = 0,
                        Deaths = 1,
                        Coins = 56,
                        TotalEquippedWeaponSize = 1,
                        TotalEquippedArmorSize = 3,
                        EquippedWeaponId1 = 1,
                        // EquippedWeaponId1 = null,
                        EquippedArmorId1 = 1,
                        EquippedArmorId2 = 1,
                        EquippedArmorId3 = 2,
                        CurrentZone = 1,
                        CurrentNode = 1,
                        DateLastPlayed = DateTime.Today
                    },

                    new Hero
                    {
                        // HeroId = 2,
                        UserId = 2,
                        HeroName = "Quacks",
                        Class = "Scout",
                        HeroLevel = 5,
                        TotalHealth = 30,
                        TotalAttack = 4,
                        TotalDefense = 3,
                        TotalBattles = 1,
                        BattlesWon = 1,
                        Deaths = 0,
                        Coins = 56,
                        TotalEquippedWeaponSize = 2,
                        TotalEquippedArmorSize = 3,
                        EquippedWeaponId1 = 2,
                        EquippedArmorId1 = 1,
                        EquippedArmorId2 = 2,
                        EquippedArmorId3 = 3,
                        CurrentZone = 1,
                        CurrentNode = 2,
                        DateLastPlayed = DateTime.Today
                    }
                );

                context.Shops.Add(
                    new Shop
                    {
                        // ShopId = 1,
                        ShopLevel = 3,
                        ShopCoinsAvailable = 300
                    }
                );

                context.Treasures.Add(
                    new Treasure 
                    {
                        // TreasureId = 1,
                        WeaponId = 2,
                        ArmorId = 1,
                        NumberOfItems = 2,
                        CoinTotal = 30,
                    }
                );

                context.Enemies.AddRange(
                    new Enemy
                    {
                        // EnemyId = 1,
                        EnemyName = "Fox",
                        EnemyType = "Low",
                        TotalHealth = 10,
                        Attack = 2,
                        Defense = 4,
                        IsFlying = false,
                    },
                    
                    new Enemy
                    {
                        // EnemyId = 2,
                        EnemyName = "Hawk",
                        EnemyType = "High",
                        TotalHealth = 50,
                        Attack = 6,
                        Defense = 8,
                        IsFlying = true,
                    },

                    new Enemy
                    {
                        // EnemyId = 3,
                        EnemyName = "Hunter",
                        EnemyType = "Boss",
                        TotalHealth = 200,
                        Attack = 10,
                        Defense = 15,
                        IsFlying = false,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}