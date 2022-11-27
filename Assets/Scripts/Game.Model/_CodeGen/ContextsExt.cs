// TODO 这部分代码是自动生成的

using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public partial class Contexts {
        public static GameData GameData => _curContexts.GameData;
        public static InputData InputData => _curContexts.InputData;
        public static MapData MapData => _curContexts.MapData;
        public static ref LevelConfigData LevelConfigData => ref _curContexts.LevelConfigData;
    }

    public partial class GameContexts {
        public GameData GameData = new GameData();
        public InputData InputData = new InputData();
        public MapData MapData = new MapData();
        public LevelConfigData LevelConfigData = new LevelConfigData();
    }
}