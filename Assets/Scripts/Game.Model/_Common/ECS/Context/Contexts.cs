using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public partial class Contexts {
        private static GameContexts _curContexts = new GameContexts();

        public static void SetContexts(GameContexts contexts) {
            _curContexts = contexts;
        }
        public static long GenId() => _curContexts.IdGenerator.GenId();
        public static void ResetId() => _curContexts.IdGenerator.Reset();
        public static void ResetRandom(uint seed) { Random = new Random(seed); }
        
        public static ref Random Random => ref _curContexts.Random;
        public static int Tick {
            get => _curContexts.TickData.Tick;
            set => _curContexts.TickData.Tick = value;
        }
    }


}