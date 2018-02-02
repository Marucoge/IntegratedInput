using System.Collections.Generic;
//using UnityEngine.UI;
//using UnityEditor;
using UnityEngine;
using System;


namespace IntegratedInput{
    public class InputIntegrator : MonoBehaviour{
        [SerializeField] private IntegratedButton IntegratedCircleButton;
        [SerializeField] private IntegratedButton IntegratedCrossButton;


        public static ButtonState CircleButton { get; private set; }
        public static ButtonState CrossButton { get; private set; }


        // フレーム内での処理順についてはまだ考慮していない。すべてのIntegratedButton の処理が終わった直後がベストか。
        private void Update() {
            CircleButton = IntegratedCircleButton.Status;
        }
    }
}