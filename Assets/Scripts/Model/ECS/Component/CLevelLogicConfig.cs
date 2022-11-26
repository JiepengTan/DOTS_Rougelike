using Unity.Entities;
using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public partial struct CPrefabOutWall : IPrefabBufferElement { public Entity Value; public Entity Prefab { set => Value = value; } }
    public partial struct CPrefabFloor : IPrefabBufferElement { public Entity Value; public Entity Prefab { set => Value = value; } }

    public partial struct CTagDynamic : IComponentData { 
    }
    public partial struct CEntityView : IComponentData { 
        public int ViewId;
    }
    public partial struct CEnableView :IComponentData, IEnableableComponent {
    }
    public partial struct CUnitPlayer : IComponentData { }
    
    public partial struct CUnitEnemy : IComponentData {
        public int Type;
    }
    public partial struct CUnitWall : IComponentData {
        public int Type;
    }
    public partial struct CUnitFood : IComponentData { 
        public int Type;
    }
    public partial struct CPosition : IComponentData {
        public int2 Value;
    }
    public partial struct CEntityId : IComponentData {
        public long Value;
    }
    
    public partial struct CViewFloor : IComponentData { }
    public partial struct CViewOutWall : IComponentData { }
    
    [System.Serializable]
    public partial struct CLevelLogicConfig : IComponentData {
        public uint RndSeed;
        public int EnemyCount;
        public int WallCount;
        public int FoodCount;


    }

    public static class ECSExt {
        public static int GetEnemyType(this CLevelLogicConfig self,Random rnd) {
            return 0;
        }
        public static int GetFoodType(this CLevelLogicConfig self,Random rnd) {
            return 0;
        }
    }
}