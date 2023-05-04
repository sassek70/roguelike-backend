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
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Hero>().ToTable("Hero");
            modelBuilder.Entity<Enemy>().ToTable("Enemy");
            modelBuilder.Entity<Shop>().ToTable("Shop");
            modelBuilder.Entity<Treasure>().ToTable("Treasure");
            modelBuilder.Entity<Armor>().ToTable("Armor");
            modelBuilder.Entity<Weapon>().ToTable("Weapon");
        }
    }
}