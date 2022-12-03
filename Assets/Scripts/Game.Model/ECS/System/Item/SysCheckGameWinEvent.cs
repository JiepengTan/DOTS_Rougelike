using GamesTan.Game.View;
using Unity.Entities;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(FrameCleanUpGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysCheckGameWinEvent : GameSystemBase {              
        protected override void OnUpdate() {
            Entities.ForEach(
                (Entity entity, CdEventGameWin unit) => {
                    EventUtil.Trigger(EGameEvent.GameEventPassLevel);
                }).Run();
        }

    }
}