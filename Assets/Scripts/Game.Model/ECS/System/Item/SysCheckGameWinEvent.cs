using GamesTan.Game.View;
using Unity.Entities;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(FrameCleanUpGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysCheckGameWinEvent : GameSystemBase {               
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
        }
        protected override void OnUpdate() {
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            Entities.ForEach(
                (Entity entity, CdEventGameWin unit) => {
                    ecb.DestroyEntity(entity);
                    EventUtil.Trigger(EGameEvent.GameEventWin);
                }).Run();
        }

    }
}