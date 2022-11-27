namespace GamesTan.ECS.Game {
    public partial struct TickData : IContext {
        public int Tick;
    }

    public partial struct IdGenerator : IContext {
        public long sId;
        public void Reset() {
            sId = 0;
        }
        public long GenId() {
            return ++sId;
        }
    }
}