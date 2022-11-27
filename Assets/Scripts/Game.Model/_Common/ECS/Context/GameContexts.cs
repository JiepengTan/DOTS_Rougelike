
using Unity.Mathematics;

namespace GamesTan.ECS.Game {

    public partial class GameContexts {
        public IdGenerator IdGenerator = new IdGenerator();
        public Random Random = new Random();
        public TickData TickData = new TickData();
    }

}