using DuckGame.Models.Equipment;
using DuckGame.Models.Nodes;
using DuckGame.Models.PlayerInfo;
using Microsoft.EntityFrameworkCore;

namespace DuckGame.Data
{
    public class DataContextEntity : DbContext
    {
        public DataContextEntity (DbContextOptions<DataContextEntity> options) : base(options)
        {

        }

        public DbSet<User> Users {get; set;}
        public DbSet<Hero> Heroes {get; set;}
        public DbSet<Enemy> Enemies {get; set;}
        public DbSet<Shop> Shops {get; set;}
        public DbSet<Treasure> Treasures {get; set;}
        public DbSet<Armor> Armors {get; set;}
        public DbSet<Weapon> Weapons {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<User>().ToTable("User");
            // modelBuilder.Entity<Hero>().ToTable("Hero");
            // modelBuilder.Entity<Enemy>().ToTable("Enemy");
            // modelBuilder.Entity<Shop>().ToTable("Shop");
            // modelBuilder.Entity<Treasure>().ToTable("Treasure");
            // modelBuilder.Entity<Armor>().ToTable("Armor");
            // modelBuilder.Entity<Weapon>().ToTable("Weapon");

            // modelBuilder.Entity<Weapon>().HasData(
            //     new Weapon { WeaponId = 1, WeaponName = "Fresh Reed"}
            // )

            modelBuilder.Entity<Hero>(e => 
            {
                e.HasOne<User>(u => u.User).WithMany(h => h.Heroes).HasForeignKey(fk => fk.UserId);
            });
            
            modelBuilder.Entity<Weapon>().HasData(           
                new Weapon {WeaponId = 1, WeaponName = "Fresh Reed", Attack = 2, WeaponType = "Melee"},
                new Weapon {WeaponId = 2, WeaponName = "Decayed Reed", Attack = 1, WeaponType = "Melee"},
                new Weapon {WeaponId = 3, WeaponName = "Stick", Attack = 2, WeaponType = "Melee"},
                new Weapon {WeaponId = 4, WeaponName = "Stone Slinger", Attack = 1, WeaponType = "Ranged"},
                new Weapon {WeaponId = 5, WeaponName = "Sharp Stick", Attack = 2, WeaponType = "Melee"}
            );

            modelBuilder.Entity<Armor>().HasData(
                new Armor {ArmorId = 1, ArmorName = "Fresh Lilipad Helmet", Defense = 2, ArmorType = "Helmet"},
                new Armor {ArmorId = 2, ArmorName = "Fresh Lilipad Breastplate", Defense = 2, ArmorType = "Chest"},
                new Armor {ArmorId = 3, ArmorName = "Fresh Lilipad Shins", Defense = 2, ArmorType = "Legs"},
                new Armor {ArmorId = 4, ArmorName = "Decayed Lilipad Helmet", Defense = 1, ArmorType = "Helmet"},
                new Armor {ArmorId = 5, ArmorName = "Decayed Lilipad Breastplate", Defense = 1, ArmorType = "Chest"},
                new Armor {ArmorId = 6, ArmorName = "Decayed Lilipad Shins", Defense = 1, ArmorType = "Legs"},
                new Armor {ArmorId = 7, ArmorName = "Wood Helmet", Defense = 3, ArmorType = "Helmet"},
                new Armor {ArmorId = 8, ArmorName = "Wood Breatplaste", Defense = 3, ArmorType = "Chest"},
                new Armor {ArmorId = 9, ArmorName = "Wood Shins", Defense = 3, ArmorType = "Legs"}
            );

            modelBuilder.Entity<Enemy>().HasData(
                new Enemy {EnemyId = 1, EnemyName = "Tadpole", TotalHealth = 20, EnemyAttack = 1, EnemyDefense = 1, EnemyType = "Low-tier", IsFlying = false},
                new Enemy {EnemyId = 2, EnemyName = "Turtle", TotalHealth = 35, EnemyAttack = 2, EnemyDefense = 4, EnemyType = "Low-tier", IsFlying = false},
                new Enemy {EnemyId = 3, EnemyName = "Gosling", TotalHealth = 25, EnemyAttack = 2, EnemyDefense = 2, EnemyType = "Low-tier", IsFlying = false},
                new Enemy {EnemyId = 4, EnemyName = "Snail", TotalHealth = 45, EnemyAttack = 2, EnemyDefense = 5, EnemyType = "Low-tier", IsFlying = false},
                new Enemy {EnemyId = 5, EnemyName = "Large Snail", TotalHealth = 30, EnemyAttack = 7, EnemyDefense = 8, EnemyType = "High-tier", IsFlying = false},
                new Enemy {EnemyId = 6, EnemyName = "Angry Duck", TotalHealth = 30, EnemyAttack = 2, EnemyDefense = 2, EnemyType = "High-tier", IsFlying = false},
                new Enemy {EnemyId = 7, EnemyName = "Goose", TotalHealth = 55, EnemyAttack = 4, EnemyDefense = 6, EnemyType = "High-tier", IsFlying = true},
                new Enemy {EnemyId = 8, EnemyName = "King Toad", TotalHealth = 60, EnemyAttack = 7, EnemyDefense = 7, EnemyType = "Boss-tier", IsFlying = false},
                new Enemy {EnemyId = 9, EnemyName = "Hawk", TotalHealth = 90, EnemyAttack = 10, EnemyDefense = 15, EnemyType = "Boss-tier", IsFlying = true},
                new Enemy {EnemyId = 10, EnemyName = "Falcon", TotalHealth = 120, EnemyAttack = 15, EnemyDefense = 13, EnemyType = "Boss-tier", IsFlying = true}
            );
        }
    }
}