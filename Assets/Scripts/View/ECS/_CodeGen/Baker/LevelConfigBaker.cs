using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class LevelConfigBaker : Baker<LevelConfigAuthoring> {
        public override void Bake(LevelConfigAuthoring authoring) {
            AddComponent(GetEntity(), new ComponentTypeSet(
                new ComponentType[]
                {
                    typeof(CLevelConfig),
                    typeof(CPrefabEnemy),
                    typeof(CPrefabWall),
                    typeof(CPrefabOutWall),
                    typeof(CPrefabFloor),
                    typeof(CPrefabFood),
                }));
            var config = new CLevelConfig() {
                PlayerPrefab = this.GetEntity(authoring.PlayerPrefab),
                ExitPrefab = this.GetEntity(authoring.ExitPrefab),
                MapSize = authoring.MapSize.ToInt2(),
                RandomSeed = authoring.RandomSeed
            };
            SetComponent(GetEntity(), config);
            this.CreateBuffer<CPrefabEnemy>(authoring.EnemyPrefabs);
            this.CreateBuffer<CPrefabWall>(authoring.WallPrefabs);
            this.CreateBuffer<CPrefabOutWall>(authoring.OutWallPrefabs);
            this.CreateBuffer<CPrefabFloor>(authoring.FloorPrefabs);
            this.CreateBuffer<CPrefabFood>(authoring.FoodPrefabs);
        }
    }
}