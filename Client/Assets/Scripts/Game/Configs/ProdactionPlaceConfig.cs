using UnityEngine;

namespace MiniMart
{
    [CreateAssetMenu(fileName = "ProdactionPlaceConfig", menuName = "Configs/ProdactionPlace")]
    public class ProdactionPlaceConfig : ScriptableObject
    {
        [field: SerializeField] public ReciptConfig Recipt { get; private set; }
        [field: SerializeField] public float BaseProdactionTime { get; private set; }
        [field: SerializeField] public int BaseStorageCount { get; private set; }
        [field: SerializeField] public int PriceToBuild { get; private set; }
    }
}