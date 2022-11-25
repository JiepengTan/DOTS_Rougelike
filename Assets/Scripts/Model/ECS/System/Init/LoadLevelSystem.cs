using GamesTan.ECS.Game.Groups;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(InitGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class LoadLevelSystem : SystemBase {
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate() {
            if(!Contexts.GameData.isNeedSpawn) return;
            Contexts.GameData.isNeedSpawn = false;
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            var dt = SystemAPI.Time.DeltaTime;
            Entities.ForEach((Entity entity, int entityInQueryIndex, in LevelConfigComponent config) => {
                //var rnd = new Random(Contexts.GameData.RndSeed);
                var rnd = new Random(config.RandomSeed);
                var mapSize = config.MapSize;
                var tileCount = config.FloorPrefabs.Length;
                int sortKey = entityInQueryIndex;
                for (int x = 0; x < mapSize.x; x++) {
                    for (int y = 0; y < mapSize.y; y++) {
                        // TODO 使用 DynamicBuffer 来实现Prefab 的动态获取
                        //var prefab = config. FloorPrefabs[rnd.NextInt(tileCount)];
                        var prefab = config.PlayerPrefab;
                        var instance = ecb.Instantiate( prefab);
                        ecb.SetComponent( instance, new LocalToWorldTransform {Value = UniformScaleTransform.FromPosition(new float3(x, y, 0))});
                    }
                }
            }).Run();
            m_BeginSimECBSystem.AddJobHandleForProducer(Dependency);
        }
    }
}