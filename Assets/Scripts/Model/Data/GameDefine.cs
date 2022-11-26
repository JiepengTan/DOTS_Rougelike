using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public partial class GameDefine {
        
        public static int2 MapSize = new int2(10,10);
        public static int2 MinMapPos = new int2(1,1);
        public static int2 MaxMapPos = MapSize -new int2(2,2);
        public static int2 PlayerInitPos => MinMapPos;
        public static int2 PlayerExitPos => MaxMapPos;
    }
}