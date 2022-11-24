using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace GamesTan.ECS.Game {
    public class FarmConfigAuthoring : MonoBehaviour {
        public GameObject FarmerPrefab;
        public GameObject RockPrefab;

        public GameObject DronePrefab;
        public GameObject FarmPrefab;
        public GameObject PlantPrefab;
        public GameObject Plant2Prefab;

        public int InitFarmerCount;
        public Vector2Int MapSize;
        public uint RandomSeed;
    }

    public class FarmConfigBaker : Baker<FarmConfigAuthoring> {
        public override void Bake(FarmConfigAuthoring authoring) {
            AddComponent(new FarmConfig {
                FarmerPrefab = GetEntity(authoring.FarmerPrefab),
                RockPrefab = GetEntity(authoring.RockPrefab),
                DronePrefab = GetEntity(authoring.DronePrefab),
                FarmPrefab = GetEntity(authoring.FarmPrefab),
                PlantPrefab = GetEntity(authoring.PlantPrefab),
                Plant2Prefab = GetEntity(authoring.Plant2Prefab),

                InitFarmerCount = authoring.InitFarmerCount,
                MapSize = new int2(authoring.MapSize.x, authoring.MapSize.y),
                RandomSeed = authoring.RandomSeed,
            });
        }
    }
}