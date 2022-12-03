using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Mathematics;
using static Unity.Mathematics.math;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(FrameCleanUpGroup))]
    [UpdateAfter(typeof(SysMovePlayer))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysMoveEnemy : GameSystemBase {
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate() {
            float dt = SystemAPI.Time.DeltaTime;
            var inputVal = InputLayer.MoveDir;
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            var playerPos = Contexts.InputData.CurPos;
            var tick = Contexts.Tick;
            var playerEntityId = Contexts.GameData.PlayerEntityId;
            if (!Contexts.InputData.HasMovement) return;
            Entities.ForEach(
                    (ref CdUnitRuntime runtimeInfo, ref CdUnitEnemy unit) => {
                        var srcPos = runtimeInfo.Pos;
                        var diff = playerPos - srcPos;
                        var absDiff = math.abs(diff);
                        // 攻击检测
                        if (absDiff.ManhattanDist() == 1) {
                            // 检测是否想攻击
                            if (Contexts.Random.NextFloat() > unit.AttackProbability) return;
                            Contexts.GameData.Food -= unit.Damage;
                            var instance = ecb.CreateEntity();
                            ecb.AddComponent(instance, new CdTagCleanupInFrameEnd());
                            ecb.AddComponent(instance, new CdEventTakeDamage() {
                                Tick = tick,
                                Damage = unit.Damage,
                                AttackId = runtimeInfo.EntityId,
                                SufferId = playerEntityId
                            });
                            return;
                        }

                        // 检测是否想移动
                        if (Contexts.Random.NextFloat() > unit.MoveProbability) return;
                        
                        // 移动检测,默认移动x轴
                        var dstPos1 = srcPos + new int2(diff.x > 0 ? 1 : -1, 0);
                        if (srcPos.x == playerPos.x) dstPos1 = srcPos;
                        var dstPos2 = srcPos + new int2(0, diff.y > 0 ? 1 : -1);
                        if (srcPos.y == playerPos.y) dstPos2 = srcPos;
                        
                        var diff1 =  length(dstPos1 - playerPos);
                        var diff2 =  length(dstPos2 - playerPos);
                        // 选择近一点的
                        if (diff1 < diff2) {
                            // swap
                            var temp = dstPos1;
                            dstPos1 = dstPos2;
                            dstPos2 = temp;
                        }


                        if (Contexts.MapData.CanMove(dstPos1)) {
                            Contexts.MapData.MoveTo(runtimeInfo.EntityType, srcPos, dstPos1);
                            runtimeInfo.Pos = dstPos1;
                            return;
                        }

                        // 检测另外的轴是否能运行
                        if (Contexts.MapData.CanMove(dstPos2)) {
                            Contexts.MapData.MoveTo(runtimeInfo.EntityType, srcPos, dstPos2);
                            runtimeInfo.Pos = dstPos2;
                        }
                    })
                .Run();
        }
    }
}