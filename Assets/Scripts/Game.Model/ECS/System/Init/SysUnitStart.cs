using Unity.Entities;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(LogicUpdateGroup))]
    [UpdateAfter(typeof(SysUnitAwake))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysUnitStart : GameSystemBase {
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate() {
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            Entities.ForEach(
                (Entity entity, CdTagStart tag, ref CdUnitRuntime runtimeInfo, in CdUnitConfig configInfo) => {
                    ecb.SetComponentEnabled(entity, typeof(CdTagStart), false);
                    //这里处理 Start 逻辑
                    //...
                }).Run();
        }
    }
}