// TODO 这部分代码是自动生成的
using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class BkUnitPlayer : Baker<AuUnitPlayer> {
        public override void Bake(AuUnitPlayer authoring) {
            AddComponent(GetEntity(), new CdUnitPlayer() {
                Health = authoring.Health,
                Damage = authoring.Damage,
                MoveInterval = authoring.MoveInterval,
            });
        }
    }
    public partial class BkUnitItem : Baker<AuUnitItem> {
        public override void Bake(AuUnitItem authoring) {
            AddComponent(GetEntity(), new CdUnitItem(){
                Health = authoring.Health,});
        }
    }
    public partial class BkUnitWall : Baker<AuUnitWall> {
        public override void Bake(AuUnitWall authoring) {
            AddComponent(GetEntity(), new CdUnitWall(){
                Health = authoring.Health,
            });
        }
    }
    public partial class BkUnitEnemy : Baker<AuUnitEnemyg> {
        public override void Bake(AuUnitEnemyg authoring) {
            AddComponent(GetEntity(), new CdUnitEnemy(){
                Health = authoring.Health,
                Damage = authoring.Damage,
                MoveInterval = authoring.MoveInterval,
                AI = authoring.AI,
                
            });
        }
    }
}