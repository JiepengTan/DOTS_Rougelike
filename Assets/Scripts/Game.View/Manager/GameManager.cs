using System;
using GamesTan.ECS.Game;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;

namespace GamesTan.Game.View {
    public class GameManager : BaseMonoManager<GameManager> {
        public bool useSeed = false;
        public uint randomSeed = 42;
        public int InitFood = 100;
        public LevelConfigData LevelConfigData;
        public bool IsNeedLoadLevel => Contexts.GameData.IsNeedLoadLevel;
        
        public override void DoAwake() {
            base.DoAwake();
            EventUtil.RemoveAllListener();
            Debug.Log("Starting GameController using seed " + randomSeed);
            Contexts.ResetId();
            Contexts.LevelConfigData = LevelConfigData;
            Contexts.ResetRandom(randomSeed);
            Contexts.GameData.Food = InitFood;
            Contexts.GameData.IsNeedLoadLevel = true;
        }

        public void Update() {
            if (IsNeedLoadLevel) {
                LoadLevel();
            }
        }

        public void LoadLevel() {
            Contexts.GameData.IsNeedLoadLevel = false;
            // TODO LoadScene to create a new level
        }
    }
}