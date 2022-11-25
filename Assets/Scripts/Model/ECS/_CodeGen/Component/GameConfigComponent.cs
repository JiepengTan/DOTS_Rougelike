using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public struct GameConfigComponent : IComponentData {
        public NativeArray<Entity> EnemyPrefabs;
        public NativeArray<Entity> WallPrefabs;
        public NativeArray<Entity> FloorPrefabs;
        public NativeArray<Entity> FoodPrefabs;

        public Entity PlayerPrefab;
        public Entity ExitPrefab;

        public int2 MapSize;
        public uint RandomSeed;
    }
}