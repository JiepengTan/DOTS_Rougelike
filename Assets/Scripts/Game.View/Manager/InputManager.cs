using GamesTan.ECS.Game;
using UnityEngine;

namespace GamesTan.Game.View {
    public class InputManager : BaseMonoManager<InputManager> {
        void Update() {
            var moveVector = GetInput();
            int horizontal = Mathf.RoundToInt(moveVector.x);
            int vertical = Mathf.RoundToInt(moveVector.y);

            if (horizontal != 0 || vertical != 0) {
                var movement = ToMovement(horizontal, vertical);
                InputLayer.MoveDir = movement;
            }
            else {
                InputLayer.MoveDir = EMoveDir.None;
            }
        }

        Vector2 GetInput() {
            return new Vector2(Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"));
        }

        static EMoveDir ToMovement(int x, int y) {
            // only allow 1 direction, prioritize horizontal over vertical
            if (x != 0) {
                return x > 0 ? EMoveDir.Right : EMoveDir.Left;
            }
            else if (y != 0) {
                return y > 0 ? EMoveDir.Up : EMoveDir.Down;
            }

            return EMoveDir.Up;
        }


    }
}