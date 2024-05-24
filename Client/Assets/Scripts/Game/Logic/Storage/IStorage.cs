using System.Collections.Generic;

namespace MiniMart
{
    public interface IStorage
    {
        public List<ItemConfig> StoragebleItems { get; }

        public bool TryPutItemInStorage(ItemConfig itemType);

        public bool TryGetItemFromStorage(out Item item);
    }
}