using Unity.Entities;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(FrameCleanUpGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysAddTick : GameSystemBase {
        protected override void OnUpdate() {
            // 重置地图数据
            Contexts.Tick++;
        }
    }
}