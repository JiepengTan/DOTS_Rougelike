using GamesTan.Game.View;
using Unity.Entities;

namespace GamesTan.ECS.Game {

    [UpdateInGroup(typeof(FrameCleanUpGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysCheckGameFailedEvent : GameSystemBase {  
        protected override void OnUpdate() {
            Entities.ForEach(
                (Entity entity, CdEventGameFailed unit) => {
                    EventUtil.Trigger(EGameEvent.GameEventFailed);
                }).Run();
        }

    }
}