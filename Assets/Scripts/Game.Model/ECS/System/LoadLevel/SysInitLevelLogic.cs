using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Random = Unity.Mathematics.Random;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(LogicInitGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysInitLevelLogic : GameSystemBase {
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate() {
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            var min = GameDefine.MinMapPos;
            var max = GameDefine.MaxMapPos;
            var em = EntityManager;
            var gameConfig = Contexts.LevelConfigData;
            
            Entities.ForEach((Entity entity
                    , CdLevelLogicConfig config //标记是否需要加载场景
                    , DynamicBuffer<CdPrefabPlayer> players
                    , DynamicBuffer<CdPrefabWall> walls
                    , DynamicBuffer<CdPrefabEnemy> enemies
                    , DynamicBuffer<CdPrefabItem> items
                ) => {
                    Contexts.GameData.State = GameData.EState.Playing;
                    ref var rnd =ref Contexts.Random;
                    var allPos = GetFreeSlotList( min, max, ref rnd);
                    //var allPos = new NativeList<int2>();
                    var freeSlotCount = allPos.Length;
                    // create player
                    var id = CreateEntity(em, ecb, players,ref rnd, GameDefine.PlayerInitPos, MapData.ETypePlayer);
                    Contexts.GameData.PlayerEntityId = id;
                    Contexts.InputData.CurPos = GameDefine.PlayerInitPos;
                    Contexts.InputData.LastPos = GameDefine.PlayerInitPos;
                    // create exit
                    CreateEntity(ecb, config.ExitPrefab,  GameDefine.PlayerExitPos, MapData.ETypeExit);
                    // create enemy
                    for (int i = 0; i < gameConfig.EnemyCount; i++) {
                        CreateEntity(em, ecb, enemies,ref rnd, allPos[--freeSlotCount], MapData.ETypeEnemy);
                    }

                    // create wall
                    for (int i = 0; i < gameConfig.WallCount; i++) {
                        CreateEntity(em, ecb, walls,ref rnd, allPos[--freeSlotCount], MapData.ETypeWall);
                    }

                    // create item
                    for (int i = 0; i < gameConfig.FoodCount; i++) {
                        CreateEntity(em, ecb, items,ref rnd, allPos[--freeSlotCount], MapData.ETypeItem);
                    }

                    ecb.DestroyEntity(entity);
                    allPos.Dispose();
                }
            ).Run();
            m_BeginSimECBSystem.AddJobHandleForProducer(Dependency);
        }

        private static NativeList<int2> GetFreeSlotList( int2 min, int2 max, ref Random rnd) {
            var allPos = new NativeList<int2>(GameDefine.FreeSlotSize, Allocator.Temp);
            int idx = 0;
            for (int x = min.x; x <= max.x; x++) {
                for (int y = min.y; y <= max.y; y++) {
                    var pos = new int2(x, y);
                    if (!(pos.IsEquals(max) || pos.IsEquals(min))) {
                        allPos.Add(pos);
                    }
                }
            }

            var count = allPos.Length;
            for (int i = 0; i < count; i++) {
                // swap
                var slotIdx = rnd.NextInt(i, count);
                var temp = allPos[slotIdx];
                allPos[slotIdx] = allPos[i];
                allPos[i] = temp;
            }

            return allPos;
        }


        private static long CreateEntity<T>(EntityManager em, EntityCommandBuffer ecb, DynamicBuffer<T> buffer,
            ref Random rnd, int2 pos, int entityType)
            where T : unmanaged, IECSPrefabBufferElement {
            var prefab = buffer[rnd.NextInt(buffer.Length)].Prefab;
            return CreateEntity(ecb,prefab, pos, entityType);
        }

        private static long CreateEntity(EntityCommandBuffer ecb,Entity prefab, int2 pos, int entityType ) {
            var entity = ecb.Instantiate(prefab);
            var id = Contexts.GenId();
            ecb.SetComponent(entity, new CdUnitRuntime() {EntityId = id, Pos = pos, EntityType = entityType});
            return id;
        }
    }
}