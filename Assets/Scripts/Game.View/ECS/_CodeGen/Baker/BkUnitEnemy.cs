using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class BkUnitEnemy : Baker<AuUnitEnemy> {
        public override void Bake(AuUnitEnemy authoring) {
            AddComponent(GetEntity(), new CdUnitEnemy(){
                Damage = authoring.Damage,
                MoveProbability = authoring.MoveProbability,
                AttackProbability = authoring.AttackProbability,
                AI = authoring.AI,
            });
        }
    }
}