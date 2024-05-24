namespace MiniMart
{
    public class GrabItemController
    {
        public void GrabItem(InventoryComponent entityInventory, IStorage storage)
        {
            if (entityInventory.FreeSpace == 0)
            {
                return;
            }

            if (!storage.TryGetItemFromStorage(out var item))
            {
                return;
            }

            entityInventory.AddItemToInventory(item);
        }
    }
}