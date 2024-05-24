using System.Collections.Generic;
using UnityEngine;

namespace MiniMartUI
{
    public class ProdactionUIView : MonoBehaviour
    {
        [SerializeField] private ItemUIElement _itemPrefab;
        [SerializeField] private Transform _container;
        [Space(20)]
        [SerializeField] private ItemUIElement _itemProducedTo;
        [SerializeField] private GameObject _itemsProducedFromStoragePanel;

        private List<ItemUIElement> _itemsProducedFrom = new();

        public void UpdateProduceItemUI(Sprite sprite, string text)
        {
            _itemProducedTo.ChangeSprite(sprite);
            _itemProducedTo.ChangeText(text);
        }

        public void InstantiateItemsUIProduceFrom(List<Sprite> sprites)
        {
            if (sprites.Count == 0)
            {
                _itemsProducedFromStoragePanel.SetActive(false);
            }

            foreach (var sprite in sprites)
            {
                var item = Instantiate(_itemPrefab, _container);
                item.ChangeSprite(sprite);
                item.ChangeText("0");
                _itemsProducedFrom.Add(item);
            }
        }

        public void UpdateItemsUIProduceFrom(List<KeyValuePair<Sprite, string>> pairs)
        {
            for (int i = 0; i < _itemsProducedFrom.Count; i++)
            {
                var item = _itemsProducedFrom[i];
                item.ChangeSprite(pairs[i].Key);
                item.ChangeText(pairs[i].Value);
            }
        }
    }
}