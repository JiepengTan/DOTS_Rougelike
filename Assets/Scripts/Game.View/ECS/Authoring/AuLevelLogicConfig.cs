using System.Collections.Generic;
using Unity.Entities;
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
    
    public partial class BkLevelLogicConfig : Baker<LevelLogicConfigAuthoring> {
        public override void Bake(LevelLogicConfigAuthoring authoring) {
            AddComponent(GetEntity(), new ComponentTypeSet(
                new ComponentType[] {
                    typeof(CdTagLoadLevel),
                    typeof(CdLevelLogicConfig),
                    typeof(CdPrefabPlayer),
                    typeof(CdPrefabWall),
                    typeof(CdPrefabEnemy),
                    typeof(CdPrefabItem),
                }));
            var config = new CdLevelLogicConfig() {
                RndSeed = authoring.RndSeed,
                EnemyCount = authoring.EnemyCount,
                WallCount = authoring.WallCount,
                FoodCount = authoring.FoodCount,
            };
            SetComponent(GetEntity(), config);
            this.CreateBuffer<CdPrefabPlayer>(authoring.PrefabPlayer);
            this.CreateBuffer<CdPrefabWall>(authoring.PrefabWall);
            this.CreateBuffer<CdPrefabEnemy>(authoring.PrefabEnemy);
            this.CreateBuffer<CdPrefabItem>(authoring.PrefabItem);
        }
    }
}