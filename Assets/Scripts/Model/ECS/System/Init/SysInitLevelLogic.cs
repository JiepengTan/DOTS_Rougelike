using GamesTan.ECS.Game.Groups;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(InitGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysInitLevelLogic : SystemBase {
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate() {
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            var seed = Contexts.GameData.RndSeed;
            var min = GameDefine.MinMapPos;
            var max = GameDefine.MaxMapPos;
            var m_Archetype = World.EntityManager.CreateArchetype(
                typeof(CPosition),
                typeof(CEntityId),
                typeof(CTagDynamic),
                // view component
                typeof(CEnableView),
                typeof(CEntityView)
            );

            Entities.ForEach((Entity entity, CLevelLogicConfig config) => {
                    var allPos = new NativeList<int2>(GameDefine.FreeSlotSize, Allocator.Temp);
                    var rnd = new Random(seed);
                    int idx = 0;
                    for (int x = min.x; x <= max.x; x++) {
                        for (int y = min.y; y <= max.y; y++) {
                            var pos = new int2(x, y);
                            if (((pos.x != max.x) || (pos.y != max.y))
                                || ((pos.x != min.x) || (pos.y != min.y))
                            ) {
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

                    InitMap(config, allPos, rnd, ecb, m_Archetype);
                    ecb.DestroyEntity(entity);
                    allPos.Dispose();
                }
            ).Run();
            m_BeginSimECBSystem.AddJobHandleForProducer(Dependency);
        }

        private static void InitMap(CLevelLogicConfig config, NativeList<int2> allPos, Random rnd,
            EntityCommandBuffer ecb,
            EntityArchetype archetype) {
            var freeSlotCount = allPos.Length;
            {
                // create player
                CreateEntity(ecb, archetype, GameDefine.PlayerInitPos, new CUnitPlayer());
            }
            {
                // create enemy
                for (int i = 0; i < config.EnemyCount; i++) {
                    var pos = allPos[--freeSlotCount];
                    CreateEntity(ecb, archetype, pos,
                        new CUnitEnemy() {Type = rnd.NextInt(0, config.GetEnemyType(rnd))});
                }
            }
            {
                // create wall
                for (int i = 0; i < config.WallCount; i++) {
                    var pos = allPos[--freeSlotCount];
                    CreateEntity(ecb, archetype, pos, new CUnitWall());
                }
            }
            {
                // create Food
                for (int i = 0; i < config.FoodCount; i++) {
                    var pos = allPos[--freeSlotCount];
                    CreateEntity(ecb, archetype, pos, new CUnitFood() {Type = rnd.NextInt(0, config.GetFoodType(rnd))});
                }
            }
        }


        private static Entity CreateEntity<T>(EntityCommandBuffer ecb, EntityArchetype type, int2 pos, T comp)
            where T : unmanaged, IComponentData {
            var instance = ecb.CreateEntity(type);
            ecb.AddComponent(instance, comp);
            ecb.SetComponent(instance, new CPosition() {Value = pos});
            ecb.SetComponent(instance, new CEntityId() {Value = Contexts.GameData.GenId()});
            return instance;
        }
    }
}