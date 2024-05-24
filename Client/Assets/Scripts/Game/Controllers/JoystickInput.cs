using System;
using UnityEngine;
using Zenject;

namespace MiniMart
{
    public class JoystickInput : IInput, IUpdate
    {
        public Vector3 CurrentInput => _currentInput;

        public bool CanMove { get ; set; }

        private Joystick _joystick;
        private Vector3 _currentInput;

        [Inject]
        private void Construct(Joystick joystick)
        {
            _joystick = joystick;
            CanMove = true;
        }

        public void ManualUpdate()
        {
            if (!CanMove) 
            {
                return;
            }

            _currentInput = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        }
    }
}