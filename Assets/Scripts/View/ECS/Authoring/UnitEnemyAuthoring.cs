using UnityEngine;

namespace GamesTan.ECS.Game {
    public partial class UnitEnemyAuthoring : MonoAuthoring { 
        public int Health;
        [Range(0,1.0f)]
        public float MoveInterval;
        public int Damage;
        public int AI;
        
    }
}