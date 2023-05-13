using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputTools
{
    public class OverworldActionMap
    {
        public InputAction movement;
        PlayerControls controls;
        public OverworldActionMap()
        {
            controls = new PlayerControls();
            movement = InputData.SetupAction(controls.OverworldInputMaps.Movement);
        }
        public void Disable()
        {
            controls.Disable();
            movement.Disable();
        }
    }


    public static class InputData
    {
        public static InputAction SetupAction(InputAction action)
        {
            action.Enable();
            return action;
        }
    }
}
