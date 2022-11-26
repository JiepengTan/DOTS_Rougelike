using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class LevelViewConfigBaker : Baker<LevelConfigAuthoring> {
        public override void Bake(LevelConfigAuthoring authoring) {
            AddComponent(GetEntity(), new ComponentTypeSet(
                new ComponentType[] {
                    typeof(CLevelViewConfig),
                    typeof(CPrefabFloor),
                    typeof(CPrefabOutWall),
                }));
            var config = new CLevelViewConfig() {
                ExitPrefab = this.GetEntity(authoring.ExitPrefab),
                RndSeed = authoring.RandomSeed
            };
            SetComponent(GetEntity(), config);
            this.CreateBuffer<CPrefabOutWall >(authoring.OutWallPrefabs);
            this.CreateBuffer<CPrefabFloor>(authoring.FloorPrefabs);
        }
    }
}