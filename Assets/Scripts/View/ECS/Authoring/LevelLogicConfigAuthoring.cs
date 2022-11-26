using System.Collections.Generic;
using UnityEngine;

namespace GamesTan.ECS.Game {
    public partial class LevelLogicConfigAuthoring : MonoAuthoring {
        public List<GameObject> PrefabPlayer = new List<GameObject>();
        public List<GameObject> PrefabWall = new List<GameObject>();
        public List<GameObject> PrefabEnemy = new List<GameObject>();
        public List<GameObject> PrefabItem = new List<GameObject>();
        
        
        public uint RndSeed;
        public int EnemyCount;
        public int WallCount;
        public int FoodCount;
    }
    
}