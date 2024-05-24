using UnityEngine;
using Zenject;

namespace MiniMart
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _baseMoveSpeed;
        [SerializeField] private int _baseInventorySpace;

        public InventoryComponent InventoryComponent { get; private set; }
        public MoveComponent MoveComponent {  get; private set; }

        [Inject]
        private void Construct()
        {
            InventoryComponent = new(_baseInventorySpace, new());
            MoveComponent = new(_rb, _baseMoveSpeed);
        }
    }
}