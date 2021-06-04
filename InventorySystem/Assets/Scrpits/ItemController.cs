using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemTemplate", menuName = "Items")]
public class ItemController : ScriptableObject
{
    public string itemName;
    public new string description;
    [Tooltip("What is this item?")] public string itemClass;
    public Sprite iconItem;
}
