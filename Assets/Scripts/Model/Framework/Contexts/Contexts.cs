namespace GamesTan.ECS.Game {
    public partial class Contexts {
        private static GameContexts _curContexts = new GameContexts();

        public static void SetContexts(GameContexts contexts) {
            _curContexts = contexts;
        }
    }
}