namespace MiniMart
{
    public class PutItemController
    {
        public void PutItem(InventoryComponent entityInventory, IStorage storage)
        {
            foreach (var item in storage.StoragebleItems)
            {
                if (entityInventory.TryRemoveItemFromInventory(item))
                {
                    storage.TryPutItemInStorage(item);
                }
            }
        }
    }
}