using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MiniMart
{
    public abstract class Holder<T> : MonoBehaviour
    {
        protected List<T> _itemsInHolder = new();
        protected GameFlowManager _gameFlowManager;

        protected virtual void Constract(GameFlowManager gameFlowManager)
        {
            _gameFlowManager = gameFlowManager;
            FillupLists(transform);
        }

        private void FillupLists(Transform transform)
        {
            foreach (Transform child in transform)
            {
                if (child.TryGetComponent<T>(out var items))
                {
                    _itemsInHolder.Add(items);
                }

                if (child.childCount > 0)
                {
                    FillupLists(child);
                }
            }
        }
    }
}