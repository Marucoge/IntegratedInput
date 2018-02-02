using System.Collections.Generic;
using UnityEngine;
using System;


namespace IntegratedInput {
    /// <summary>
    /// 
    /// </summary>
    public enum ButtonState { BeingReleased, JustPressed, BeingPressed }
    public enum InputType { AxisInput, GUIInput}


    public interface IIntegratedButton {
        ButtonState Status { get; }
    }


    public interface IIntegratedStick {
        Vector2 StickInput { get; }
    }
   
}