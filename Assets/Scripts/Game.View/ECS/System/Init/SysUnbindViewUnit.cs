using GamesTan.Game.View;
using Unity.Entities;

namespace GamesTan.ECS.Game.View {
    [UpdateInGroup(typeof(ViewInitGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysUnbindViewUnit : GameSystemBase {
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate() {
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            Entities.ForEach((Entity entity,CdUnbindDestroyView view) => {
                ecb.DestroyEntity(entity);
                // 销毁的逻辑
                EntityViewManager.Instance.OnDestroyEntity(view.EntityId);
            }).Run();
        }
    }
}