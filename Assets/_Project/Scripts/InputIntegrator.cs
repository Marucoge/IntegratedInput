﻿using System.Collections.Generic;
using UnityEngine.UI;
//using UnityEditor;
using UnityEngine;
using System;
using VirtualStick;


namespace IntegratedInput{
    public class InputIntegrator : MonoBehaviour{
        [SerializeField] private IntegratedButton IntegratedCircleButton;
        //[SerializeField] private IntegratedButton IntegratedCrossButton;
        [SerializeField] private VirtualStick.VirtualStick LeftStick;       // 本当はインターフェイスで扱いたいが、インスペクタにはインターフェイスを表示できないので。
        [SerializeField] private VirtualStick.VirtualStick RightStick;

        public static ButtonState CircleButton { get; private set; }
        public static ButtonState CrossButton { get; private set; }
        public static Vector2 LeftStickInput { get; private set; }
        public static Vector2 RightStickInput { get; private set; }


        // フレーム内での処理順についてはまだ考慮していない。すべてのIntegratedButton の処理が終わった直後がベストか。
        private void Update() {
            CircleButton = IntegratedCircleButton.Status;
            LeftStickInput = LeftStick.StickInput;
            RightStickInput = RightStick.StickInput;
        }
    }
}