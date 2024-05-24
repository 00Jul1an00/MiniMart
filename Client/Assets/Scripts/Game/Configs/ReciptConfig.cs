using System.Collections.Generic;
using UnityEngine;

namespace MiniMart
{
    [CreateAssetMenu(fileName = "ReciptConfig", menuName = "Configs/Recipt")]
    public class ReciptConfig : ScriptableObject
    {
        [field: SerializeField] public List<SerializebleKeyValuePair<ItemConfig, int>> MadeFrom { get; private set; }
        [field: SerializeField] public SerializebleKeyValuePair<ItemConfig, int> ItemToMake { get; private set; }
    }
}