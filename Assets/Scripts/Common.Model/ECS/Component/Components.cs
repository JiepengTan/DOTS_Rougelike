﻿namespace GamesTan.ECS {
    public partial struct CdTagAwake: IECSEnableableComponent {
    }
    public partial struct CdTagStart: IECSEnableableComponent {
    }
    public partial struct CdTagBindEntityView : IECSEnableableComponent {
    }
    public partial struct CdEntityView : IECSComponent {
        public long ViewId;
    }
    public partial struct CdTagCleanupInFrameEnd : IECSEnableableComponent {
    }
}