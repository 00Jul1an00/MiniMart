using UnityEngine;

namespace MiniMartUI
{
    public class StorageUIView : MonoBehaviour
    {
        [SerializeField] private ItemUIElement _item;

        public void UpdateUIElement(Sprite itemSprite, string text)
        {
            _item.ChangeSprite(itemSprite);
            _item.ChangeText(text);
        }
    }

}