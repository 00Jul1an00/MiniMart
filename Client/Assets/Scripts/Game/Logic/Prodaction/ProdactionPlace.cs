using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniMart
{
    public class ProdactionPlace : MonoBehaviour, IUpdate, IStorage
    {
        [SerializeField] private ProdactionPlaceConfig _config;

        private List<SerializebleKeyValuePair<ItemConfig, int>> _currentItemsForProduce = new();
        private ItemConfig _itemToProduceConfig;
        private float _prodactionTime;
        private int _maxStorageCount;
        private int _currentStorageCount;
        private List<ItemConfig> _storagebleItems;

        private float _timer;
        private bool _isActive;

        public int CurrentStorageCount => _currentStorageCount;

        public List<ItemConfig> StoragebleItems => _storagebleItems;

        public event Action<List<SerializebleKeyValuePair<ItemConfig, int>>> ItemsForProduceCountChange;
        public event Action<ItemConfig, int> ItemToProduceCountChange;

        public void InitDefault()
        {
            _itemToProduceConfig = _config.Recipt.ItemToMake.Key;
            _prodactionTime = _config.BaseProdactionTime;
            _maxStorageCount = _config.BaseStorageCount;
            _timer = 0;

            foreach (var requaireItem in _config.Recipt.MadeFrom)
            {
                _currentItemsForProduce.Add(new (requaireItem.Key, 0));
                _storagebleItems.Add(requaireItem.Key);
            }

            ItemsForProduceCountChange?.Invoke(_currentItemsForProduce); 
            ItemToProduceCountChange?.Invoke(_itemToProduceConfig, _currentStorageCount);
            _isActive = true;
        }

        public void ManualUpdate()
        {
            if (!_isActive)
            {
                return;
            }

            _timer += Time.deltaTime;

            if (_timer >= _prodactionTime)
            {
                _timer = 0;
                Produce();
            }
        }

        public bool TryPutItemInStorage(ItemConfig itemType)
        {
            foreach (var requaireItem in _currentItemsForProduce)
            {
                if (requaireItem.Key == itemType)
                {
                    int index = _currentItemsForProduce.IndexOf(requaireItem);
                    _currentItemsForProduce[index] = new(requaireItem.Key, requaireItem.Value + 1);
                    ItemsForProduceCountChange?.Invoke(_currentItemsForProduce);
                    return true;
                }
            }

            return false;
        }

        public bool TryGetItemFromStorage(out Item item)
        {
            if (_currentStorageCount == 0)
            {
                Debug.Log("zero items");
                item = null;
                return false;
            }

            _currentStorageCount--;
            ItemToProduceCountChange?.Invoke(_itemToProduceConfig, _currentStorageCount);
            item = new(_itemToProduceConfig);
            return true;
        }

        private void Produce()
        {
            if (_currentStorageCount >= _maxStorageCount)
            {
                return;
            }

            for(int i = 0; i < _currentItemsForProduce.Count; i++)
            {
                if (_currentItemsForProduce[i].Value < _config.Recipt.MadeFrom[i].Value)
                {
                    return;
                }
            }

            for (int i = 0; i < _currentItemsForProduce.Count; i++)
            {
                var pair = _currentItemsForProduce[i];
                _currentItemsForProduce[i] = new(pair.Key, pair.Value - _config.Recipt.MadeFrom[i].Value);
            }

            ItemsForProduceCountChange?.Invoke(_currentItemsForProduce);
            Debug.Log("items in prodaction " + _currentStorageCount);
            _currentStorageCount += _config.Recipt.ItemToMake.Value;
            ItemToProduceCountChange?.Invoke(_itemToProduceConfig, _currentStorageCount);
        }
    }
}