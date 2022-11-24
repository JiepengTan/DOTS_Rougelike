using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.ECS.Game.View {
    public class FoodTextController : MonoBehaviour {
        Text label;
        int? food;

        void Start() {
            label = GetComponent<Text>();

        }

        void UpdateFood(int newFood) {
            if (!food.HasValue) {
                food = newFood;
            }

            var diff = newFood - food.Value;
            var symbol = diff > 0 ? "+" : "";
            var prefix = Mathf.Abs(diff) > 1 ? symbol + diff + " " : "";
            label.text = prefix + "Food: " + newFood;
            food = newFood;
        }
    }
}