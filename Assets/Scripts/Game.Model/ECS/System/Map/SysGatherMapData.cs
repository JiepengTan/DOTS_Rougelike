using Unity.Entities;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(LogicUpdateGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysGatherMapData : GameSystemBase {
        protected override void OnUpdate() {
            float dt = SystemAPI.Time.DeltaTime;
            var inputVal = InputLayer.MoveDir;
            var em = EntityManager;
            // 重置地图数据
            Contexts.MapData.ResetMap();
            if (Contexts.InputData.HasMovement) return;
            // 更新内部地图数据
            Entities.ForEach((in CdUnitRuntime runtimeInfo) => {
                    Contexts.MapData.SetTile(runtimeInfo.Pos, runtimeInfo.EntityType);
                })
                .Run();
        }
    }
}