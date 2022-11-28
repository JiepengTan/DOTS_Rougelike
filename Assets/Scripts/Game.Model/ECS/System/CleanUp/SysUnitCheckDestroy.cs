using Unity.Entities;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(LogicCleanUpGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysUnitCheckDestroy : GameSystemBase {
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate() {
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            var em = EntityManager;
            //绑定view层，需要运行再主线程上，方便各种
            Entities.ForEach((Entity entity,CdUnitRuntime unit) => {
                if (unit.Health <= 0) {
                    ecb.DestroyEntity(entity);
                    var instance =ecb.CreateEntity();
                    ecb.AddComponent(instance,new CdDestroyView(){EntityId =  unit.EntityId});
                }
            }).Run();
        }
    }
}