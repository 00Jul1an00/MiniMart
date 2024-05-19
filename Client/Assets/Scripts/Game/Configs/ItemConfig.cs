using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/Item")]
public class ItemConfig : ScriptableObject
{
    [field: SerializeField] public string ID { get; private set; }
    [field: SerializeField] public ItemConfig MadeFrom { get; private set; }
    [field: SerializeField] public ItemConfig NeedFor {  get; private set; }
    [field: SerializeField] public int Price { get; private set; }
}