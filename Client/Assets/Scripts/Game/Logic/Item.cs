
public class Item
{
    public ItemConfig Config { get; private set; }

    public Item(ItemConfig itemConfig)
    {
        Config = itemConfig;
    }
}
