using Unity.Entities;

namespace GamesTan.ECS.Game {
    public interface IECSPrefabBufferElement : IBufferElementData {
        public Entity Prefab { get; set; }
    }

    /// <summary> ECS Component </summary>
    public interface IECSComponent : IComponentData{
    }
    /// <summary>ECS Enableable Component </summary>
    public interface IECSEnableableComponent : IECSComponent,IEnableableComponent{
    }
    /// <summary>ECS Component  自动生成Baker和Authoring 代码 </summary>
    public interface IECSAutoGenComponent: IECSComponent{
    }
    
}