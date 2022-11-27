using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class BkLevelViewConfig : Baker<LevelViewConfigAuthoring> {
        public override void Bake(LevelViewConfigAuthoring authoring) {
            AddComponent(GetEntity(), new ComponentTypeSet(
                new ComponentType[] {
                    typeof(CdLevelViewConfig),
                    typeof(CdPrefabFloor),
                    typeof(CdPrefabOutWall),
                }));
            var config = new CdLevelViewConfig() {
                ExitPrefab = this.GetEntity(authoring.PrefabExit),
                RndSeed = authoring.RandomSeed
            };
            SetComponent(GetEntity(), config);
            this.CreateBuffer<CdPrefabOutWall >(authoring.PrefabOutWall);
            this.CreateBuffer<CdPrefabFloor>(authoring.PrefabFloor);
        }
    }
}