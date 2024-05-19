using UnityEngine;
using Zenject;

namespace MiniMart
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;
        [SerializeField] private Joystick _inputJoystick;

        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(_player).AsSingle();
            BindInput();
            BindFlow();
        }

        private void BindInput()
        {
            Container.Bind<Joystick>().FromInstance(_inputJoystick).AsSingle();
            Container.BindInterfacesAndSelfTo<JoystickInput>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
        }

        private void BindFlow()
        {
            Container.BindInterfacesAndSelfTo<GameFlowManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}