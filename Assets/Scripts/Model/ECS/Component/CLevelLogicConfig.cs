using Unity.Entities;
using Unity.Mathematics;

namespace GamesTan.ECS.Game {

    public partial struct CAssetInfo : IComponentData {
        public long AssetId;
        public long ConfigId;
    }

    public partial struct CBaseUnit : IComponentData { 
        public long EntityId;
        public int2 Pos;
    }
    public partial struct CEntityView : IComponentData { 
        public int ViewId;
    }
    public partial struct CEnableView :IComponentData, IEnableableComponent {
    }
    
    public partial struct CUnitPlayer : IComponentData {
        public int Health;
        public float MoveInterval;
        public int Damage;
    }
    public partial struct CUnitEnemy : IComponentData {
        public int Health;
        public float MoveInterval;
        public int Damage;
        public int AI;
    }

    public partial struct CUnitWall : IComponentData {
        public int Health;
    }

    public partial struct CUnitItem : IComponentData {
        public int Health;
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

    public partial struct CTagLoadLevel : IComponentData,IEnableableComponent { }

    public static class ECSExt {
        public static int GetEnemyType(this CLevelLogicConfig self,Random rnd) {
            return 0;
        }
        public static int GetFoodType(this CLevelLogicConfig self,Random rnd) {
            return 0;
        }
    }
}