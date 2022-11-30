using GamesTan.Game.View;
using Unity.Entities;

namespace GamesTan.ECS.Game.View {
    [UpdateInGroup(typeof(ViewUpdateGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysEventTakeDamage : GameSystemBase {
        protected override void OnUpdate() {
            var em = EntityManager;
            Entities.ForEach((Entity entity, CdEventTakeDamage info) => {
                EntityViewManager.Instance.GetEntityView(info.AttackId)?.ShowAttack(info.Tick);
                EntityViewManager.Instance.GetEntityView(info.SufferId)?.ShowHited(info.Tick);
            }).Run();
        }
    }
}