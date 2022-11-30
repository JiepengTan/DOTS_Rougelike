using Unity.Entities;

namespace GamesTan.ECS.Game.View {
    [UpdateInGroup(typeof(ViewUpdateGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysCheckMoveEvent : GameSystemBase {
        protected override void OnUpdate() {
            Entities.ForEach(
                (Entity entity, CdEventPlayerMoved unit) => {
                    EventUtil.Trigger(EGameEvent.GameEventPlayerMoved);
                }).Run();
        }
    }
}