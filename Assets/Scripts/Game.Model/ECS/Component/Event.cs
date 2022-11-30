using Unity.Entities;

namespace GamesTan.ECS.Game {
    /// 攻击事件
    public partial struct CdEventTakeDamage : IECSComponent {
        public int Tick;
        public long AttackId;
        public long SufferId;
        public int Damage;
    }
    /// 治疗事件
    public partial struct CdEventTakeHeal : IECSComponent {
        public int Tick;
        public long AttackId;
        public long SufferId;
        public int Damage;
    }
    public partial struct CdEventGameWin : IECSComponent {
    }
    public partial struct CdEventGameFailed : IECSComponent {
    }
    public partial struct CdEventPlayerMoved : IECSComponent {
    }
}