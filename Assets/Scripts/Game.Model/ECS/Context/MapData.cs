using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;

namespace GamesTan.ECS.Game {
    public partial class MapData : IContext {
        
        public NativeHashMap<int2, int> pos2Type = new NativeHashMap<int2, int>();

        public const int ETypeNone = 0;
        public const int ETypeRock = 1;
        public const int ETypeFarm = 2;
        public const int ETypePlant = 3;
        public const int ETypeStore = 4;


        public bool IsNone(int2 pos) => pos2Type[pos] == ETypeNone;
        public bool IsRock(int2 pos) => pos2Type[pos] == ETypeRock;
        public bool IsFarm(int2 pos) => pos2Type[pos] == ETypeFarm;
        public bool IsPlant(int2 pos) => pos2Type[pos] == ETypePlant;
        public bool IsStore(int2 pos) => pos2Type[pos] == ETypeStore;

        public bool IsNone(int val) => val == ETypeNone;
        public bool IsRock(int val) => val == ETypeRock;
        public bool IsFarm(int val) => val == ETypeFarm;
        public bool IsPlant(int val) => val == ETypePlant;
        public bool IsStore(int val) => val == ETypeStore;

        public int GetTile(int2 pos) => pos2Type[pos];

        public void SetTile(int2 pos, int type) {
            pos2Type[pos] = type;
        }

        public void SetTile(int x, int y, int type) {
            pos2Type[new int2(x, y)] = type;
        }

      
    }
}