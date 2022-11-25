using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class LevelConfigBaker : Baker<LevelConfigAuthoring> {
        public override void Bake(LevelConfigAuthoring authoring) {
            var config = new LevelConfigComponent {
                EnemyPrefabs = this.GetEntity(authoring.EnemyPrefabs),
                WallPrefabs = this.GetEntity(authoring.WallPrefabs),
                OutWallPrefabs = this.GetEntity(authoring.OutWallPrefabs),
                FloorPrefabs = this.GetEntity(authoring.FloorPrefabs),
                FoodPrefabs = this.GetEntity(authoring.FoodPrefabs),
                PlayerPrefab = this.GetEntity(authoring.PlayerPrefab),
                ExitPrefab = this.GetEntity(authoring.ExitPrefab),
                MapSize = authoring.MapSize.ToInt2(),
                RandomSeed = authoring.RandomSeed
            };
            AddComponent(config);
        }
    }
}