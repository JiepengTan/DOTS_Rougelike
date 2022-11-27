using Unity.Entities;
using Unity.Scenes;
using UnityEngine;

namespace GamesTan.ECS {
    public abstract class SceneSelectorGroup : ComponentSystemGroup {
        protected override void OnCreate() {
            base.OnCreate();
            var subScene = Object.FindObjectOfType<SubScene>();
            if (subScene != null) {
                Enabled = SceneName == subScene.gameObject.scene.name;
            }
            else {
                Enabled = false;
            }
        }

        protected virtual string SceneName { get; } = "Main";
    }

    public partial class GameLogicGroup : ComponentSystemGroup {
    }
    [UpdateAfter(typeof(GameLogicGroup))]
    public partial class GameViewGroup : ComponentSystemGroup {
    }
    [UpdateAfter(typeof(GameViewGroup))]
    public partial class GameCleanupGroup : ComponentSystemGroup {
    }

    
    // Logic 
    [UpdateInGroup(typeof(GameLogicGroup))]
    public partial class LogicInitGroup : SceneSelectorGroup {
    }
    [UpdateInGroup(typeof(GameLogicGroup))]
    [UpdateAfter(typeof(LogicInitGroup))]
    public partial class LogicUpdateGroup : SceneSelectorGroup {
    }
    [UpdateInGroup(typeof(GameLogicGroup))]
    [UpdateAfter(typeof(LogicUpdateGroup))]
    public partial class LogicCleanUpGroup : SceneSelectorGroup {
    }    
    
    
    
    // View
    [UpdateInGroup(typeof(GameViewGroup))]
    [UpdateAfter(typeof(LogicCleanUpGroup))]
    public partial class ViewInitGroup : SceneSelectorGroup {
    }
    [UpdateInGroup(typeof(GameViewGroup))]
    [UpdateAfter(typeof(ViewInitGroup))]
    public partial class ViewUpdateGroup : SceneSelectorGroup {
    }
    [UpdateInGroup(typeof(GameViewGroup))]
    [UpdateAfter(typeof(ViewUpdateGroup))]
    public partial class ViewCleanUpGroup : SceneSelectorGroup {
    }
    
    
    [UpdateInGroup(typeof(GameCleanupGroup))]
    [UpdateAfter(typeof(ViewCleanUpGroup))]
    public partial class FrameCleanUpGroup : SceneSelectorGroup {
    }
}