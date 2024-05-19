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
            _playerMoveComponent = player.GetComponent<MoveComponent>();
        }

        public void FixUpdate()
        {
            _playerMoveComponent.MoveByRigidbodyVelocityAndRotate(_currentInput.CurrentInput);
        }
    }
}