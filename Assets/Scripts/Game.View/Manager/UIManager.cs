using System;
using GamesTan.ECS.Game;
using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.Game.View {
    public class UIManager : BaseMonoManager<UIManager> {
        public Image levelImage;
        public Text levelText;

        public Text label;
        public float hideDelay = 2f;
        int food;

        public void Start() {
            ShowLevelImage(Contexts.GameData.Level);
            // TODO auto register 
            EventUtil.AddListener(EGameEvent.CtxGameDataFood,OnEvent_CtxGameDataFood);
            EventUtil.AddListener(EGameEvent.CtxGameDataLevel,OnEvent_CtxGameDataLevel);
        }

        private void OnEvent_CtxGameDataFood(object value) {
            UpdateFood(Contexts.GameData.Food);
        }
        private void OnEvent_CtxGameDataLevel(object level) {
            ShowLevelImage(Contexts.GameData.Level);
        }

        public void UpdateFood(int newFood) {
            var diff = newFood - food;
            var symbol = diff > 0 ? "+" : "";
            var prefix = Mathf.Abs(diff) > 1 ? symbol + diff + " " : "";
            label.text = prefix + "Food: " + newFood;
            food = newFood;
        }


        public void ShowLevelImage(uint level) {
            levelImage.enabled = true;
            levelText.text = "Day " + (level);
            levelText.enabled = true;
            Invoke("HideLevelImage", hideDelay);
        }

        public void ShowGameOver(int level) {
            levelImage.enabled = true;
            levelText.text = "After " + level + " days, you starved.";
            levelText.enabled = true;
        }

        void HideLevelImage() {
            levelText.enabled = false;
            levelImage.enabled = false;
        }
    }
}