using Unity.Collections;
using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public partial class InputData : IContext {
        public bool HasMovement;
        public int2 LastPos;
        public int2 CurPos;
    }
    
    [System.Serializable]
    public partial struct LevelConfigData : IContext {
        public int EnemyCount;
        public int WallCount;
        public int FoodCount;
    }
    
    public partial class GameData : IContext {
        public enum EState {
            None,
            Playing,
            Win,
            Failed
        }

        public bool IsPlaying => State == EState.Playing;
        public bool IsNeedLoadLevel;
        public long PlayerEntityId;
        private int _Food;
        public EState State = EState.None;
        public int Food {
            get => _Food;
            set {
                _Food = value;
                EventUtil.Trigger(EGameEvent.CtxGameDataFood,value);
            }
        }
        
        private uint _Level;
        public uint Level {
            get => _Level;
            set {
                _Level = value;
                EventUtil.Trigger(EGameEvent.CtxGameDataLevel,value);
            }
        }
        
        
    }
}