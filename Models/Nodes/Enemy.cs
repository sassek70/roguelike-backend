namespace DuckGame.Models.Nodes
{
    public class Enemy
    {
        public int EnemyId {get; set;}
        public required string EnemyName {get; set;}
        public int TotalHealth {get; set;}
        public int EnemyAttack {get; set;}
        public int EnemyDefense {get; set;}
        public required string EnemyType {get; set;} // Low-tier, High-tier, Boss-tier
        public bool IsFlying {get; set;}
    }

}