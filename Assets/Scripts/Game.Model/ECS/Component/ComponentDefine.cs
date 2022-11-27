using Unity.Mathematics;
using Entity = Unity.Entities.Entity;
using RangeAttribute = UnityEngine.RangeAttribute;

namespace GamesTan.ECS.Game {
   
    // 基础配置，不会变动的
    public partial struct CdUnitConfig : IECSComponent {
        public long AssetId;
        public long ConfigId;
        public int Health;
    }
    // 运行时候数据
    public partial struct CdUnitRuntime : IECSComponent {
        public long EntityId;
        public int2 Pos;
        public int Health;
    }



    public partial struct CdUnitPlayer : IECSAutoGenComponent {
        public float MoveInterval;
        public int Damage;
    }

    public partial struct CdUnitEnemy : IECSAutoGenComponent {
        [Range(0,1.0f)]
        public float MoveInterval;
        public int Damage;
        public int AI;
    }

    public partial struct CdUnitWall : IECSAutoGenComponent {
    }

    public partial struct CdUnitItem : IECSAutoGenComponent {
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