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
        public InputAction interact;
        PlayerControls controls;
        public OverworldActionMap()
        {
            controls = new PlayerControls();
            movement = InputData.SetupAction(controls.OverworldInputMaps.Movement);
            interact = InputData.SetupAction(controls.OverworldInputMaps.Interact);
        }
        public void Disable()
        {
            controls.Disable();
            movement.Disable();
            interact.Disable();
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
