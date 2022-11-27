using System;
using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.Game.View {
    public class UIManager : BaseMonoManager<UIManager> {
        public Image levelImage;
        public Text levelText;

        public Text label;

        public float displayDelay = 1f;
        public float hideDelay = 2f;
        int currentLevel;
        int food;

        public void Start() {
            ShowLevelImage(1);
        }

        public void UpdateFood(int newFood) {
            var diff = newFood - food;
            var symbol = diff > 0 ? "+" : "";
            var prefix = Mathf.Abs(diff) > 1 ? symbol + diff + " " : "";
            label.text = prefix + "Food: " + newFood;
            food = newFood;
        }

        public void ShowLevelImage(int level) {
            currentLevel = level;
            levelImage.enabled = true;
            levelText.text = "Day " + currentLevel;
            levelText.enabled = true;
            Invoke("HideLevelImage", hideDelay);
        }

        public void ShowGameOver() {
            levelImage.enabled = true;
            levelText.text = "After " + currentLevel + " days, you starved.";
            levelText.enabled = true;
        }

        void HideLevelImage() {
            levelText.enabled = false;
            levelImage.enabled = false;
        }
    }
}