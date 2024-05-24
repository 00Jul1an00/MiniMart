using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace MiniMart
{
    [RequireComponent(typeof(Collider))]
    public class ProdactionPlaceCollider : MonoBehaviour, IDisposable
    {
        [SerializeField] private float _grabItemDelay;
        [SerializeField] private ProdactionPlace _prodactionPlace;

        private GrabItemController _grabItemcontroller;
        private CancellationTokenSource _cancellationTokenSource;

        [Inject]
        private void Contract(GrabItemController grabItemController)
        {
            _grabItemcontroller = grabItemController;
        }

        private void OnTriggerEnter(Collider other)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            if (other.TryGetComponent<Player>(out var player))
            {
                GrabItem(player.InventoryComponent).Forget();
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            _cancellationTokenSource.Cancel();
        }

        private async UniTaskVoid GrabItem(InventoryComponent inventory)
        {
            while (_cancellationTokenSource.IsCancellationRequested == false)
            {
                await UniTask.WaitForSeconds(_grabItemDelay, cancellationToken: _cancellationTokenSource.Token);
                _grabItemcontroller.GrabItem(inventory, _prodactionPlace);
            }
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }
}