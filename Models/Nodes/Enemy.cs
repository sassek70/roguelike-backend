namespace DuckGame.Models.Nodes
{
    public class Enemy
    {
        public int EnemyId {get; set;}
        public string Name {get; set;}
        public string TotalHealth {get; set;}
        public int Attack {get; set;}
        public int Defense {get; set;}
        public string EnemyType {get; set;}
        public bool IsFlying {get; set;}
    }

}