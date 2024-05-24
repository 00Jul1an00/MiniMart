using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MiniMart
{
    public class InventoryComponent
    {
        private int _inventorySpace;
        private int _currentItemsCountInInventory;
        private List<Item> _inventory = new();

        public int FreeSpace => _inventorySpace - _currentItemsCountInInventory;

        public InventoryComponent(int inventorySpace, List<Item> items)
        {
            _inventorySpace = inventorySpace;
            _inventory = items;
        }

        public void AddItemToInventory(Item item)
        {
            if (FreeSpace == 0)
            {
                Debug.Log("not enought space in inventory");
                return;
            }

            _currentItemsCountInInventory++;
            _inventory.Add(item);
        }

        public bool TryRemoveItemFromInventory(ItemConfig itemType)
        {
            Item itemToReturn = _inventory.FirstOrDefault(item => item.Config == itemType);

            if (itemToReturn == default)
            {
                Debug.Log("Trying remove item witch doesnt contains in inventory");
                return false;
            }

            _currentItemsCountInInventory--;
            _inventory.Remove(itemToReturn);
            return true;
        }

        public void IncreaseBaseInventorySpace(int increaseBy)
        {
            _inventorySpace += increaseBy;
        }

        public List<Item> GetItems()
        {
            return _inventory;
        }
    }
}