using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace GamesTan.ECS.Game {
    public partial class LevelViewConfigAuthoring : MonoAuthoring {
        public List<GameObject> PrefabOutWall = new List<GameObject>();
        public List<GameObject> PrefabFloor = new List<GameObject>();
        public uint RandomSeed;
    }
    
    public partial class BkLevelViewConfig : Baker<LevelViewConfigAuthoring> {
        public override void Bake(LevelViewConfigAuthoring authoring) {
            AddComponent(GetEntity(), new ComponentTypeSet(
                new ComponentType[] {
                    typeof(CdLevelViewConfig),
                    typeof(CdPrefabFloor),
                    typeof(CdPrefabOutWall),
                }));
            var config = new CdLevelViewConfig() {
                RndSeed = authoring.RandomSeed
            };
            SetComponent(GetEntity(), config);
            this.CreateBuffer<CdPrefabOutWall >(authoring.PrefabOutWall);
            this.CreateBuffer<CdPrefabFloor>(authoring.PrefabFloor);
        }
    }
}