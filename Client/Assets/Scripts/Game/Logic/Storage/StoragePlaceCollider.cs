using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using Zenject;

namespace MiniMart
{
    [RequireComponent(typeof(Collider))]
    public class StoragePlaceCollider : MonoBehaviour
    {
        [SerializeField] private float _interactDelay;
        [SerializeField] private StoragePlace _storage;

        private GrabItemController _grabItemController;
        private PutItemController _putItemController;
        private CancellationTokenSource _cancellationTokenSource;

        [Inject]
        private void Contract(GrabItemController grabItemController, PutItemController putItemController)
        {
            _grabItemController = grabItemController;
            _putItemController = putItemController;
        }

        private void OnTriggerEnter(Collider other)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            if (other.TryGetComponent<Player>(out var player))
            {
                PutItem(player.InventoryComponent).Forget();
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            _cancellationTokenSource.Cancel();
        }

        private async UniTaskVoid GrabItem(InventoryComponent inventory)
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                await UniTask.WaitForSeconds(_interactDelay, cancellationToken: _cancellationTokenSource.Token);
                _grabItemController.GrabItem(inventory, _storage);
            }
        }

        private async UniTaskVoid PutItem(InventoryComponent inventory)
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                await UniTask.WaitForSeconds(_interactDelay, cancellationToken: _cancellationTokenSource.Token);
                _putItemController.PutItem(inventory, _storage);
            }
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }}