using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class LevelViewConfigBaker : Baker<LevelViewConfigAuthoring> {
        public override void Bake(LevelViewConfigAuthoring authoring) {
            AddComponent(GetEntity(), new ComponentTypeSet(
                new ComponentType[] {
                    typeof(CLevelViewConfig),
                    typeof(CPrefabFloor),
                    typeof(CPrefabOutWall),
                }));
            var config = new CLevelViewConfig() {
                ExitPrefab = this.GetEntity(authoring.PrefabExit),
                RndSeed = authoring.RandomSeed
            };
            SetComponent(GetEntity(), config);
            this.CreateBuffer<CPrefabOutWall >(authoring.PrefabOutWall);
            this.CreateBuffer<CPrefabFloor>(authoring.PrefabFloor);
        }
    }
}