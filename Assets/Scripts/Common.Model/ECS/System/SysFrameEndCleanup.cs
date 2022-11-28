using Unity.Entities;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(FrameCleanUpGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysFrameEndCleanup : GameSystemBase {
        private EndSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate() {
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            Entities.ForEach(
                (Entity entity, CdTagCleanupInFrameEnd tag) => {
                    ecb.DestroyEntity(entity);
                }).Run();
        }
    }
}