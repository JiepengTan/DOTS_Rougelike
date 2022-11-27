using Unity.Entities;
using UnityEngine;

namespace GamesTan.ECS {
    public interface IECSPrefabBufferElement : IBufferElementData {
        public Entity Prefab { get; set; }
    }

    /// <summary> ECS Component </summary>
    public interface IECSComponent : IComponentData{
    }
    /// <summary>ECS Enableable Component </summary>
    public interface IECSEnableableComponent : IECSComponent,IEnableableComponent{
    }
    /// <summary>ECS Component 自动生成Baker和Authoring 代码 </summary>
    public interface IECSAutoGenComponent: IECSComponent{
    }
    /// <summary>ECS Clean Up Component 拥有额外清理机会的  </summary>
    public interface IECSCleanupComponent: IECSComponent,ICleanupComponentData{
    }


    public  abstract partial class GameSystemBase : SystemBase {

        public void Log(object msg) => Debug.Log( msg);
        public void LogWarning(object msg)  => Debug.LogWarning( msg);
        public void LogError(object msg)  => Debug.LogError( msg);
    }
}