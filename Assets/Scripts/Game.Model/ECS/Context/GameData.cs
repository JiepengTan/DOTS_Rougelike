using Unity.Collections;
using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public partial class GameData : IContext {
        private int _Food;
        public int Food {
            get => _Food;
            set {
                _Food = value;
                EventUtil.Trigger(EGameEvent.CtxGameDataFood,value);
            }
        }
        
        private int _Level;
        public int Level {
            get => _Level;
            set {
                _Level = value;
                EventUtil.Trigger(EGameEvent.CtxGameDataLevel,value);
            }
        }
    }
}