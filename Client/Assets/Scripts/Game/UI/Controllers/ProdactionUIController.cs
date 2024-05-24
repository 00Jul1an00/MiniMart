using MiniMart;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniMartUI
{
    public class ProdactionUIController : IDisposable
    {
        private ProdactionUIView _view;
        private ProdactionPlace _prodactionPlace;

        public ProdactionUIController(ProdactionUIView view, ProdactionPlace prodactionPlace)
        {
            _view = view;
            _prodactionPlace = prodactionPlace;
            Subcribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void Subcribe()
        {
            _prodactionPlace.ItemsForProduceCountChange += OnItemsForProduceCountChange;
            _prodactionPlace.ItemToProduceCountChange += OnItemToProduceCountChange;
        }

        private void Unsubscribe()
        {
            _prodactionPlace.ItemsForProduceCountChange -= OnItemsForProduceCountChange;
            _prodactionPlace.ItemToProduceCountChange -= OnItemToProduceCountChange;
        }

        private void OnItemsForProduceCountChange(List<SerializebleKeyValuePair<ItemConfig, int>> pairs)
        {
            List<KeyValuePair<Sprite, string>> pairsForView = new();

            foreach(var pair in pairs)
            {
                pairsForView.Add(new(pair.Key.ItemSprite, pair.Value.ToString()));
            }

            _view.UpdateItemsUIProduceFrom(pairsForView);
        }

        private void OnItemToProduceCountChange(ItemConfig config, int count)
        {
            _view.UpdateProduceItemUI(config.ItemSprite, count.ToString());
        }
    }
}