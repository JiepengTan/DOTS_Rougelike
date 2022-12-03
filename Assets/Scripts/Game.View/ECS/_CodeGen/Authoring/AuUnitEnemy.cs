using UnityEngine;

namespace GamesTan.ECS.Game {
    public partial class AuUnitEnemy : MonoAuthoring { 
        [Range(0,1.0f)]
        public float MoveProbability =0.5f;
        [Range(0,1.0f)]
        public float AttackProbability = 0.5f;
        
        public int Damage;
        public int AI;
        
    }
}