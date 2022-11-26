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
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            var dt = SystemAPI.Time.DeltaTime;
            var mapSize = GameDefine.MapSize;
            Entities.ForEach((Entity entity, CLevelConfig config,
                DynamicBuffer<CPrefabFloor> floors
                ,DynamicBuffer<CPrefabWall> walls
                ,DynamicBuffer<CPrefabOutWall> outwalls
                ,DynamicBuffer<CPrefabFood> foods
                ,DynamicBuffer<CPrefabEnemy> enemies
                ) => {
                var rnd = new Random(config.RandomSeed);
                {
                    // create floor
                    var prefabCount = floors.Length;
                    for (int x = 1; x < mapSize.x-1; x++) {
                        for (int y = 1; y < mapSize.y-1; y++) {
                            var prefab = floors[rnd.NextInt(prefabCount)].Value;
                            var instance = ecb.Instantiate( prefab);
                            ecb.SetComponent( instance, new LocalToWorldTransform {Value = UniformScaleTransform.FromPosition(new float3(x, y, 0))});
                            ecb.AddComponent(instance,new CTagFloor());
                        }
                    }
                }
                {
                    // create walls 
                    var prefabCount = outwalls.Length;
                    {
                        // 上下两行
                        int min = 0;
                        int max = mapSize.y - 1;
                        for (int x = 0; x < mapSize.x; x++) {
                            var instance1 = ecb.Instantiate( outwalls[rnd.NextInt(prefabCount)].Value);
                            ecb.SetComponent( instance1, new LocalToWorldTransform {Value = UniformScaleTransform.FromPosition(new float3(x, min, 0))});
                            ecb.AddComponent(instance1,new CTagOutWall());
                            var instance2 = ecb.Instantiate( outwalls[rnd.NextInt(prefabCount)].Value);
                            ecb.SetComponent( instance2, new LocalToWorldTransform {Value = UniformScaleTransform.FromPosition(new float3(x, max, 0))});
                            ecb.AddComponent(instance1,new CTagOutWall());
                        }
                    }
                    {
                        // 左右两列
                        int min = 0;
                        int max = mapSize.x - 1;
                        for (int y = 1; y < mapSize.y-1; y++) {
                            var instance1 = ecb.Instantiate( outwalls[rnd.NextInt(prefabCount)].Value);
                            ecb.SetComponent( instance1, new LocalToWorldTransform {Value = UniformScaleTransform.FromPosition(new float3(min, y, 0))});
                            ecb.AddComponent(instance1,new CTagOutWall());
                            var instance2 = ecb.Instantiate( outwalls[rnd.NextInt(prefabCount)].Value);
                            ecb.SetComponent( instance2, new LocalToWorldTransform {Value = UniformScaleTransform.FromPosition(new float3(max, y, 0))});
                            ecb.AddComponent(instance1,new CTagOutWall());
                        }
                    }
                }

                {
                    // create player
                    var instance = ecb.Instantiate( config.PlayerPrefab);
                    ecb.SetComponent( instance, new LocalToWorldTransform {Value = UniformScaleTransform.FromPosition(new float3(GameDefine.PlayerInitPos, 0))});
                    ecb.AddComponent(instance,new CTagPlayer());
                }
                {
                    // create exit
                    var instance = ecb.Instantiate( config.ExitPrefab);
                    ecb.SetComponent( instance, new LocalToWorldTransform {Value = UniformScaleTransform.FromPosition(new float3(GameDefine.PlayerExitPos, 0))});
                    ecb.AddComponent(instance,new CTagExit());
                }

                
                ecb.DestroyEntity(entity);
            }).Run();
            m_BeginSimECBSystem.AddJobHandleForProducer(Dependency);
        }
    }
}