using Unity.Mathematics;
using Entity = Unity.Entities.Entity;
using RangeAttribute = UnityEngine.RangeAttribute;

namespace GamesTan.ECS.Game {
    public partial struct CdAssetInfo : IECSComponent {
        public long AssetId;
        public long ConfigId;
    }
    public partial struct CdBaseUnit : IECSComponent {
        public long EntityId;
        public int2 Pos;
    }
    public partial struct CdEntityView : IECSComponent {
        public int ViewId;
    }

    public partial struct CdEnableView : IECSEnableableComponent {
    }

    public partial struct CdUnitPlayer : IECSAutoGenComponent {
        public int Health;
        public float MoveInterval;
        public int Damage;
    }

    public partial struct CdUnitEnemy : IECSAutoGenComponent {
        public int Health;
        [Range(0,1.0f)]
        public float MoveInterval;
        public int Damage;
        public int AI;
    }

    public partial struct CdUnitWall : IECSAutoGenComponent {
        public int Health;
    }

    public partial struct CdUnitItem : IECSAutoGenComponent {
        public int Health;
    }


    [System.Serializable]
    public partial struct CdLevelLogicConfig : IECSComponent {
        public uint RndSeed;
        public int EnemyCount;
        public int WallCount;
        public int FoodCount;
    }

    public partial struct CdTagLoadLevel : IECSEnableableComponent {
    }
    
    public partial struct CdPrefabPlayer : IECSPrefabBufferElement {  public Entity Prefab { get ;  set ; } }
    public partial struct CdPrefabWall : IECSPrefabBufferElement {   public Entity Prefab { get ;  set ; } }
    public partial struct CdPrefabEnemy : IECSPrefabBufferElement {   public Entity Prefab { get ;  set ; } }
    public partial struct CdPrefabItem : IECSPrefabBufferElement {   public Entity Prefab { get ;  set ; } }

}