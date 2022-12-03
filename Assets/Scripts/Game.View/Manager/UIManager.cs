using System;
using GamesTan.ECS.Game;
using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.Game.View {
    public class UIManager : BaseMonoManager<UIManager> {
        public Image ImageLevel;
        public Text TextLevel;

        public Text TextFood;
        public float HideDelay = 0.8f;
        private int _food;

        public override void DoAwake() {
            base.DoAwake();
            // TODO auto register 
            EventUtil.AddListener(EGameEvent.CtxGameDataFood,OnEvent_CtxGameDataFood);
            EventUtil.AddListener(EGameEvent.GameEventFailed,OnEvent_GameEventFailed);
            EventUtil.AddListener(EGameEvent.GameEventStart,OnEvent_GameEventStart);
            EventUtil.AddListener(EGameEvent.GameEventLoadLevel,OnEvent_GameEventLoadLevel);
        }
        private void OnEvent_GameEventStart(object _) {
            _food = Contexts.GameData.Food;
            ShowLevelImage(Contexts.GameData.Level);
            UpdateFood(Contexts.GameData.Food);
        }
        private void OnEvent_GameEventLoadLevel(object _) {
            ShowLevelImage(Contexts.GameData.Level);
        }
        
        private void OnEvent_GameEventFailed(object _) {
            Invoke("ShowGameOver",1);
        }

        private void OnEvent_CtxGameDataFood(object value) {
            UpdateFood(Contexts.GameData.Food);
        }
        
        private void ShowGameOver() {
            ShowGameOver(Contexts.GameData.Level);
        }

        private void UpdateFood(int newFood) {
            var diff = newFood - _food;
            var symbol = diff > 0 ? "+" : "";
            var prefix = Mathf.Abs(diff) > 1 ? symbol + diff + " " : "";
            TextFood.text = prefix + "Food: " + newFood;
            _food = newFood;
        }


        private void ShowLevelImage(uint level) {
            ImageLevel.enabled = true;
            TextLevel.text = "Day " + (level);
            TextLevel.enabled = true;
            Invoke("HideLevelImage", HideDelay);
        }

        private void ShowGameOver(uint level) {
            ImageLevel.enabled = true;
            TextLevel.text = "After " + level + " days, you starved.";
            TextLevel.enabled = true;
        }

        private void HideLevelImage() {
            TextLevel.enabled = false;
            ImageLevel.enabled = false;
        }
    }
}