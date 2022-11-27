using Unity.Entities;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(LogicUpdateGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysUnitAwake : GameSystemBase {
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate() {
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            Entities.ForEach(
                (Entity entity, CdTagAwake tag, ref CdUnitRuntime runtimeInfo, in CdUnitConfig configInfo) => {
                    ecb.SetComponentEnabled(entity, typeof(CdTagAwake), false);
                    runtimeInfo.Health = configInfo.Health;
                    //这里处理 Awake 逻辑
                    //...
                }).Run();
        }
    }
}