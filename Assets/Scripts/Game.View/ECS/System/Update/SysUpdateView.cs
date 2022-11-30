using GamesTan.Game.View;
using Unity.Entities;

namespace GamesTan.ECS.Game.View {
    [UpdateInGroup(typeof(ViewUpdateGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysUpdateView : GameSystemBase {
        protected override void OnUpdate() {
            var em = EntityManager;
            Entities.ForEach((Entity entity, CdUnitRuntime runtimeInfo) => {
                var entityId = runtimeInfo.EntityId;
                var entityView = EntityViewManager.Instance.GetEntityView(entityId);
                if (entityView != null) entityView.UpdatePos(runtimeInfo.Pos.ToVec3());
            }).Run();
        }
    }
}