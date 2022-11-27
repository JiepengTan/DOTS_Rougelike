// TODO 这部分代码是自动生成的
using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class BkUnitPlayer : Baker<AuUnitPlayer> {
        public override void Bake(AuUnitPlayer authoring) {
            AddComponent(GetEntity(), new CdUnitPlayer() {
                Damage = authoring.Damage,
                MoveInterval = authoring.MoveInterval,
            });
        }
    }
}