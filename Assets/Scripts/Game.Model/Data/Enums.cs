using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public enum EMoveDir {
        None,
        Up,Right,Down,Left
    }

    public static class MoveDirExt {
        private static int2[] _dir2Vec = {
            new int2(0, 0),
            new int2(0, 1),
            new int2(1, 0),
            new int2(0, -1),
            new int2(-1, 0),
        };

        public static int2 ToInt2(this EMoveDir dir) {
            return _dir2Vec[(int) dir];
        }
    }
}