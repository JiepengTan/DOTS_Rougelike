using Unity.Entities;
using Unity.Scenes;
using UnityEngine;

namespace GamesTan.ECS.Game.Groups {
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

        protected abstract string SceneName { get; }
    }

    public class GameTopGroup : ComponentSystemGroup {
    }

    [UpdateInGroup(typeof(GameTopGroup))]
    public class InitGroup : SceneSelectorGroup {
        protected override string SceneName => "Main";
    }
    
    [UpdateInGroup(typeof(GameTopGroup))]
    [UpdateAfter(typeof(MainThreadGroup))]
    public class MainThreadGroup : SceneSelectorGroup {
        protected override string SceneName => "Main";
    }
}