using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class UnitPlayerBaker : Baker<UnitPlayerAuthoring> {
        public override void Bake(UnitPlayerAuthoring authoring) {
            AddComponent(GetEntity(), new CUnitPlayer() {
                Health = authoring.Health,
                Damage = authoring.Damage,
                MoveInterval = authoring.MoveInterval,
            });
        }
    }
    public partial class UnitItemBaker : Baker<UnitItemAuthoring> {
        public override void Bake(UnitItemAuthoring authoring) {
            AddComponent(GetEntity(), new CUnitItem(){
                Health = authoring.Health,});
        }
    }
    public partial class UnitWallBaker : Baker<UnitWallAuthoring> {
        public override void Bake(UnitWallAuthoring authoring) {
            AddComponent(GetEntity(), new CUnitWall(){
                Health = authoring.Health,
            });
        }
    }
    public partial class UnitEnemyBaker : Baker<UnitEnemyAuthoring> {
        public override void Bake(UnitEnemyAuthoring authoring) {
            AddComponent(GetEntity(), new CUnitEnemy(){
                Health = authoring.Health,
                Damage = authoring.Damage,
                MoveInterval = authoring.MoveInterval,
                AI = authoring.AI,
                
            });
        }
    }
}