using GamesTan.Game.View;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(LogicCleanUpGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysCheckGameState : GameSystemBase {
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate() {
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            if (Contexts.GameData.State != GameData.EState.Playing) return;
            Entities.ForEach(
                (Entity entity, ref CdUnitRuntime runtimeInfo, in CdUnitExit unit) => {
                    var playerPos = Contexts.InputData.CurPos;
                    if (math.all(runtimeInfo.Pos == playerPos)) {
                        Contexts.GameData.State = GameData.EState.Win;
                        var instance = ecb.CreateEntity();
                        ecb.AddComponent(instance, new CdEventGameWin() { });
                        ecb.AddComponent(instance, new CdTagCleanupInFrameEnd() { } );
                        return;
                    }
                    if (Contexts.GameData.Food < 0) {
                        Contexts.GameData.State = GameData.EState.Failed;
                        var instance = ecb.CreateEntity();
                        ecb.AddComponent(instance, new CdEventGameFailed());
                        ecb.AddComponent(instance, new CdTagCleanupInFrameEnd() { } );
                        return;
                    }
                }).Run();
        }
    }
}