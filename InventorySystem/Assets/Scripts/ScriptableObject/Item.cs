using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public enum ItemType{
        Weapon,
        Chestplate,
        Boots,
        Helmet
    }
    public new string name;
    public ItemType itemType;
    public string description;
    public Sprite icon;
    public float damage;
    public float armor;
}
