using System;
using UnityEngine;
using Zenject;

namespace MiniMart
{
    public class InputController : IFixUpdate
    {
        private IInput _currentInput;
        private MoveComponent _playerMoveComponent;

        [Inject]
        private void Construct(IInput input, Player player)
        {
            _currentInput = input;
            _playerMoveComponent = player.MoveComponent;
        }

        public void ManualFixUpdate()
        {
            _playerMoveComponent.MoveByRigidbodyVelocityAndRotate(_currentInput.CurrentInput);
        }
    }
}