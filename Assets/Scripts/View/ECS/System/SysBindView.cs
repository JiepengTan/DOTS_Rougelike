using GamesTan.ECS.Game.Groups;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace GamesTan.ECS.Game.View {
    [UpdateInGroup(typeof(InitGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysBindView : SystemBase {
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
        }

        protected override void OnUpdate() {
            var em = EntityManager;
            //绑定view层，需要运行再主线程上，方便各种
            Entities.ForEach((Entity entity, CBaseUnit unit, CEnableView enableView, ref CEntityView entityView) => {
                em.SetComponentEnabled(entity, typeof(CEnableView), false);
                var go = ResourceManager.Instance.CreateInstantiate(unit.AssetId, unit.Pos);
                var comp = go.AddComponent<EntityViewBinder>();
                comp.Entity = entity;
                comp.EntityId = unit.AssetId;
            }).Run();
        }
    }
}