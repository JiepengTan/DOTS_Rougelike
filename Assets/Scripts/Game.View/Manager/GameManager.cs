using System;
using GamesTan.ECS.Game;
using Unity.Entities;
using Unity.Scenes;
using Unity.VisualScripting;
using UnityEngine;

namespace GamesTan.Game.View {
    public class GameManager : BaseMonoManager<GameManager> {
        public bool useSeed = false;
        public uint randomSeed = 42;
        public int InitFood = 100;
        public LevelConfigData LevelConfigData;


        public string ScenePath = "Assets/Scenes/Main/GameLevel.unity";
        private Entity _sceneEntity;
        public override void DoAwake() {
            base.DoAwake();
            EventUtil.RemoveAllListener();
            EventUtil.AddListener(EGameEvent.GameEventWin,OnEvent_GameEventWin);
            EventUtil.AddListener(EGameEvent.GameEventFailed,OnEvent_GameEventFailed);
            Debug.Log("Starting GameController using seed " + randomSeed);
            StartGame();
        }

        private void Start() {
            SoundManager.Instance.PlayerMusic();
        }

        private void StartGame() {
            Contexts.SetContexts(new GameContexts());
            Contexts.ResetId();
            Contexts.LevelConfigData = LevelConfigData;
            Contexts.ResetRandom(45);
            Contexts.GameData.Food = InitFood;
            TryLoadNextLevel();
            
        }


        private void LateUpdate() {
            if (Contexts.GameData.IsNeedLoadLevel) {
                Contexts.GameData.IsNeedLoadLevel = false;
                LoadLevel();
            }
        }

        private void OnEvent_GameEventWin(object _) {
            Debug.Log("GameFailed");
            TryLoadNextLevel();
        }

        private void OnEvent_GameEventFailed(object _) {
            Debug.Log("GameFailed");
            Invoke("StartGame",3);
            SoundManager.Instance.StopMusic();
        }

        static void TryLoadNextLevel() {
            Contexts.GameData.Level += 1;
            Debug.Log("TryLoadNextLevel " +  Contexts.GameData.Level);
            Contexts.GameData.IsNeedLoadLevel = true;
            var level = Contexts.GameData.Level;
            Contexts.LevelConfigData = new LevelConfigData() {
                EnemyCount = 1,
                FoodCount = 2,
                RndSeed = level + 37,
                WallCount = 3
            };
        }
        private void LoadLevel() {
            Debug.Log("LoadNextLevel " +  Contexts.GameData.Level);
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

        void LoadScene() {
            var world = World.DefaultGameObjectInjectionWorld;
            var sceneGuid = SceneSystem.GetSceneGUID(ref world.Unmanaged.GetExistingSystemState<SceneSystem>(), ScenePath);
            _sceneEntity = SceneSystem.LoadSceneAsync(world.Unmanaged, sceneGuid);
        }
    }
}