using Unity.Entities;
using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(LogicUpdateGroup))]
    [UpdateAfter(typeof(SysMovePlayer))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysCheckItem : GameSystemBase {
        protected override void OnUpdate() {
            Entities.ForEach(
                (Entity entity, ref CdUnitRuntime runtimeInfo, in CdUnitItem unit) => {
                    var playerPos = Contexts.InputData.CurPos;
                    if (math.all(runtimeInfo.Pos == playerPos)) {
                        Contexts.GameData.Food += runtimeInfo.Health;
                        runtimeInfo.Health = 0;
                    }
                }).Run();
        }
    }
}