namespace GamesTan.ECS {
    public partial struct CdNeedAwake: IECSEnableableComponent {
    }
    public partial struct CdNeedStart: IECSEnableableComponent {
    }
    public partial struct CdNeedBindEntityView : IECSEnableableComponent {
    }
    public partial struct CdEntityView : IECSComponent {
        public long ViewId;
    }

}