using GamesTan.Game.View;
using Unity.Entities;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(LogicUpdateGroup))]
    [UpdateAfter(typeof(SysGatherMapData))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysMovePlayer : GameSystemBase {  
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate() {
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            float dt = SystemAPI.Time.DeltaTime;
            var inputVal = InputLayer.MoveDir;
            var em = EntityManager;
            Contexts.InputData.HasMovement = false;
            Entities.ForEach(
                (Entity entity, ref CdUnitRuntime runtimeInfo, ref CdUnitPlayer player) => {
                    player.MoveTimer += dt;
                    if (inputVal != EMoveDir.None) {
                        if (player.MoveTimer > player.MoveInterval) {
                            var srcPos = runtimeInfo.Pos;
                            var dstPos = runtimeInfo.Pos + inputVal.ToInt2();
                            if (!Contexts.MapData.CanMove(dstPos)) {
                                return;
                            }

                            Contexts.MapData.MoveTo(runtimeInfo.EntityType, srcPos,dstPos);
                            runtimeInfo.Pos = dstPos;
                            player.MoveTimer = 0;
                            Contexts.InputData.HasMovement = true;
                            Contexts.InputData.LastPos = srcPos;
                            Contexts.InputData.CurPos = dstPos;
                            Contexts.GameData.Food--;
                            var instance = ecb.CreateEntity();
                            ecb.AddComponent(instance, new CdTagCleanupInFrameEnd() { } );
                            ecb.AddComponent(instance, new CdEventPlayerMoved() { } );
                        }
                    }
                }).Run();
        }
    }
}