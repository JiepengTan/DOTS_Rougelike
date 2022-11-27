using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public partial struct GameDefine {
        
        public static int2 MapSize = new int2(10,10);
        public static int MapSizeX = MapSize.x;
        public static int MapSizeY = MapSize.y;
        
        public static int2 MinMapPos = new int2(1,1);
        public static int2 MaxMapPos = MapSize -new int2(2,2);
        public static int FreeSlotSize => (MapSize.x - 2) * (MapSize.y - 2) ;
        public static int2 PlayerInitPos => MinMapPos;
        public static int2 PlayerExitPos => MaxMapPos;
    }
} 