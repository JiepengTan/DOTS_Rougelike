using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class LevelLogicConfigBaker : Baker<LevelLogicConfigAuthoring> {
        public override void Bake(LevelLogicConfigAuthoring authoring) {
            AddComponent(GetEntity(), new ComponentTypeSet(
                new ComponentType[] {
                    typeof(CTagLoadLevel),
                    typeof(CLevelLogicConfig),
                    typeof(CPrefabPlayer),
                    typeof(CPrefabWall),
                    typeof(CPrefabEnemy),
                    typeof(CPrefabItem),
                }));
            var config = new CLevelLogicConfig() {
                RndSeed = authoring.RndSeed,
                EnemyCount = authoring.EnemyCount,
                WallCount = authoring.WallCount,
                FoodCount = authoring.FoodCount,
            };
            SetComponent(GetEntity(), config);
            this.CreateBuffer<CPrefabPlayer>(authoring.PrefabPlayer);
            this.CreateBuffer<CPrefabWall>(authoring.PrefabWall);
            this.CreateBuffer<CPrefabEnemy>(authoring.PrefabEnemy);
            this.CreateBuffer<CPrefabItem>(authoring.PrefabItem);
        }
    }
}