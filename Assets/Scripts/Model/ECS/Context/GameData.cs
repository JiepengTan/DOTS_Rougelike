using Unity.Collections;
using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public partial class GameData : IContext {
        public int Score;
        public int Life;
        public int Level;
        public uint RndSeed;
        public long sId;

        public void DoAwake() {
            sId = 0;
        }

        public long GenId() {
            return ++sId;
        }
    }
}