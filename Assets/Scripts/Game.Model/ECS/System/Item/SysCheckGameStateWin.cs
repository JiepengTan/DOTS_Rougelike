using Unity.Entities;
using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    [UpdateInGroup(typeof(LogicCleanUpGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysCheckGameStateWin : GameSystemBase {        
        private BeginSimulationEntityCommandBufferSystem m_BeginSimECBSystem;

        protected override void OnCreate() {
            m_BeginSimECBSystem = World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
        }
        protected override void OnUpdate() {
            var ecb = m_BeginSimECBSystem.CreateCommandBuffer();
            Entities.ForEach((Entity entity, ref CdUnitRuntime runtimeInfo, in CdUnitPlayer unit) => {
                if (math.all(runtimeInfo.Pos == GameDefine.PlayerExitPos)) {
                    LoadNextLevel();
                }
            }).Run();
        }

        void LoadNextLevel() {
            Contexts.GameData.IsNeedLoadLevel = true;
            Contexts.GameData.Level += 1;
            var level = Contexts.GameData.Level;
            Contexts.LevelConfigData = new LevelConfigData() {
                EnemyCount = 1, 
                FoodCount = 2,
                RndSeed = level + 37,
                WallCount = 3
            };
            
        }
    }
}