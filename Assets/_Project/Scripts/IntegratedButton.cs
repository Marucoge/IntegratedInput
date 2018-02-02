using System.Collections.Generic;
using UnityEngine;
using System;


namespace IntegratedInput{
    public class IntegratedButton : MonoBehaviour {
        public ButtonState Status { get; private set; }
        public InputType InputType = InputType.AxisInput;

        [SerializeField] private string ButtonAxisName = string.Empty;
        private bool isGUIButtonJustDown = false;


       IntegratedButton() {
            Status = ButtonState.BeingReleased;
        }


        private void LateUpdate() {
            UpdateGUIInput();
            UpdateAxisInput();
        }
        

        private void UpdateAxisInput() {
            if (InputType != InputType.AxisInput) { return; }
            if (string.IsNullOrEmpty(ButtonAxisName)) { return; }

            // 状態が何であろうと、ButtonUp なら BeingReleased に。
            if (Input.GetButtonUp(ButtonAxisName)) {
                Status = ButtonState.BeingReleased;
            }

            // 前のフレームで JustPressed になり、そのままだったら BeingPressed
            if (Status == ButtonState.JustPressed) {
                Status = ButtonState.BeingPressed;
            }

            // ButtonDown なら、次のチェックまでは JustPressed
            if (Input.GetButtonDown(ButtonAxisName)) {
                Status = ButtonState.JustPressed;
            }
        }


        private void UpdateGUIInput() {
            if (InputType != InputType.GUIInput) { return; }

            // ButtonUp なら BeingReleased に。これはイベント側でやっている。

            // 前のフレームで JustPressed になり、そのままだったら BeingPressed
            if (Status == ButtonState.JustPressed) {
                Status = ButtonState.BeingPressed;
                isGUIButtonJustDown = false;
            }

            // ButtonDown なら、次のチェックまでは JustPressed
            if (isGUIButtonJustDown == true) {
                Status = ButtonState.JustPressed;
            }
        }


        // GUIのボタンが押された最初のフレームに呼ばれる。(EventTrigger に登録)
        public void GUIButtonDown() {
            isGUIButtonJustDown = true;
        }


        // GUI のボタンから指が離れたときに呼ばれる。(EventTrigger に登録)
        public void GUIButtonUp() {
            isGUIButtonJustDown = false;
            Status = ButtonState.BeingReleased;
        }


        // ポインターがGUI ボタンの範囲外に出た時に呼ばれる (EventTrigger に登録)
        public void GUIButtonExit() {
            isGUIButtonJustDown = false;
            Status = ButtonState.BeingReleased;
        }
    }
}