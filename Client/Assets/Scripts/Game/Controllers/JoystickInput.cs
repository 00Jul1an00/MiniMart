using System;
using UnityEngine;
using Zenject;

namespace MiniMart
{
    public class JoystickInput : IInput, IUpdate
    {
        public Vector3 CurrentInput { get; set; }

        private Joystick _joystick;

        [Inject]
        private void Construct(Joystick joystick)
        {
            _joystick = joystick;
        }

        public void Update()
        {
            CurrentInput = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        }
    }
}