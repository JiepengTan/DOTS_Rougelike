﻿using Unity.Entities;

namespace GamesTan.ECS.Game {
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