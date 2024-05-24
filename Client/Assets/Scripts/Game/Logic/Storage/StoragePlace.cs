using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniMart
{
    public class StoragePlace : MonoBehaviour, IStorage
    {
        [SerializeField] private ItemConfig _storageItemConfig;

        private List<ItemConfig> _storagebleItems = new();

        public List<ItemConfig> StoragebleItems => _storagebleItems;

        public event Action<ItemConfig, int> _storageCountChanged;

        private int _storageCount;

        public void Init()
        {
            _storagebleItems.Add(_storageItemConfig);
        }

        public bool TryPutItemInStorage(ItemConfig itemType)
        {
            if (itemType != _storageItemConfig)
            {
                return false;
            }

            _storageCount++;
            _storageCountChanged?.Invoke(_storageItemConfig, _storageCount);
            Debug.Log("items in storage " + _storageCount);
            return true;
        }

        public bool TryGetItemFromStorage(out Item item)
        {
            if (_storageCount == 0)
            {
                item = null;
                return false;
            }

            _storageCount--;
            _storageCountChanged?.Invoke(_storageItemConfig, _storageCount);
            item = new(_storageItemConfig);
            return true;
        }
    }
}