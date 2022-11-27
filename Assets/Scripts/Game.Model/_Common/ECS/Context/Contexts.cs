using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public partial class Contexts {
        private static GameContexts _curContexts = new GameContexts();

        public static void SetContexts(GameContexts contexts) {
            _curContexts = contexts;
        }
        public static long GenId() => IdGenerator.GenId();
        public static void ResetId() => IdGenerator.Reset();
        public static void ResetRandom(uint seed) { Random = new Random(seed); }
    }
    public partial class Contexts {
        private static ref IdGenerator IdGenerator => ref _curContexts.IdGenerator;
        public static ref Random Random=> ref _curContexts.Random;
    }

}