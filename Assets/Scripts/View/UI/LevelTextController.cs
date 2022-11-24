using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.ECS.Game.View {
    public class LevelTextController : MonoBehaviour {
        // Delay time in seconds to display level text.
        public float displayDelay = 1f;

        // Time to wait before hiding level text, in seconds.
        public float hideDelay = 2f;
        public Text levelText;

        int currentLevel;
        Image levelImage;

        // Use awake to ensure that this fires before the systems boot
        // otherwise it misses the initial level set
        void Awake() {
            levelImage = GetComponent<Image>();

        }

        void ShowLevelImage() {
            levelImage.enabled = true;
            levelText.text = "Day " + currentLevel;
            levelText.enabled = true;
            Invoke("HideLevelImage", hideDelay);
        }

        void HideLevelImage() {
            levelText.enabled = false;
            levelImage.enabled = false;
        }

        void GameOver() {
            levelImage.enabled = true;
            levelText.text = "After " + currentLevel + " days, you starved.";
            levelText.enabled = true;
        }
    }
}