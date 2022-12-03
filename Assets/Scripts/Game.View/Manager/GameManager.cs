using System;
using System.Collections.Generic;
using GamesTan.ECS.Game;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Scenes;
using Unity.VisualScripting;
using UnityEngine;

namespace GamesTan.Game.View {
    public class GameManager : BaseMonoManager<GameManager> {
        public uint RandomSeed = 42;
        public int InitFood = 100;

        public string ScenePath = "Assets/Scenes/Main/GameLevel.unity";
        private Entity _sceneEntity;

        [Header("Level Config")]
        public int LevelCountPerConfig=3;
        public List<LevelConfigData> LevelConfigDatas = new List<LevelConfigData>();
        
        
        public override void DoAwake() {
            base.DoAwake();
            EventUtil.AddListener(EGameEvent.GameEventPassLevel,OnEvent_GameEventPassLevel);
            EventUtil.AddListener(EGameEvent.GameEventFailed,OnEvent_GameEventFailed);
        }

        private void Start() {
            StartGame();
        }

        private void StartGame() {
            Debug.Log("StartGame");
            Contexts.SetContexts(new GameContexts());
            Contexts.ResetId();
            Contexts.ResetRandom(45);
            Contexts.GameData.Food = InitFood;
            LoadNextLevel();
            EventUtil.Trigger(EGameEvent.GameEventStart);
        }


        private void LateUpdate() {
            if (Contexts.GameData.IsNeedLoadLevel) {
                Contexts.GameData.IsNeedLoadLevel = false;
                ReLoadScene();
            }
        }

        private void OnEvent_GameEventPassLevel(object _) {
            Debug.Log("GameFailed");
            LoadNextLevel();
        }

        private void OnEvent_GameEventFailed(object _) {
            Debug.Log("GameFailed");
            Invoke("StartGame",3);
        }

        void LoadNextLevel() {
            Contexts.GameData.Level += 1;
            Debug.Log("LoadNextLevel " +  Contexts.GameData.Level);
            Contexts.GameData.IsNeedLoadLevel = true;
            var level = (int)Contexts.GameData.Level-1;
            var idx = (level / LevelCountPerConfig) ;
            idx = math.min(idx, LevelConfigDatas.Count-1);
            Contexts.LevelConfigData = LevelConfigDatas[idx];
            EventUtil.Trigger(EGameEvent.GameEventLoadLevel);
        }
        private void ReLoadScene() {
            Debug.Log("ReLoadScene " +  Contexts.GameData.Level);
            UnloadScene();
            LoadScene();
        }

        private void UnloadScene() {
            var world = World.DefaultGameObjectInjectionWorld;
            if (_sceneEntity != Entity.Null) {
                SceneSystem.UnloadScene(world.Unmanaged, _sceneEntity, SceneSystem.UnloadParameters.DestroySceneProxyEntity
                                                                       | SceneSystem.UnloadParameters
                                                                           .DestroySectionProxyEntities
                                                                       | SceneSystem.UnloadParameters
                                                                           .DestroySubSceneProxyEntities
                                                                       | SceneSystem.UnloadParameters
                                                                           .DontRemoveRequestSceneLoaded);
            }

            EntityViewManager.Instance.DestroyAll();
        }

        private void LoadScene() {
            var world = World.DefaultGameObjectInjectionWorld;
            var sceneGuid = SceneSystem.GetSceneGUID(ref world.Unmanaged.GetExistingSystemState<SceneSystem>(), ScenePath);
            _sceneEntity = SceneSystem.LoadSceneAsync(world.Unmanaged, sceneGuid);
        }
    }
}