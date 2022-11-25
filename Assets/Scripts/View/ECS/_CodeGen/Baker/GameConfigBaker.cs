using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class GameConfigBaker : Baker<GameConfigAuthoring> {
        public override void Bake(GameConfigAuthoring authoring) {
            var config = new GameConfigComponent {
                EnemyPrefabs = this.GetEntity(authoring.EnemyPrefabs),
                WallPrefabs = this.GetEntity(authoring.WallPrefabs),
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