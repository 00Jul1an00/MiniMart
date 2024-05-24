using UnityEngine;

namespace MiniMart
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/Item")]
    public class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public ItemEnum ItemType { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public Sprite ItemSprite { get; private set; }
    }
}