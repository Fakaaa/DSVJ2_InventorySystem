using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public enum ItemType{
        Weapon,
        Armor,
        Miscellaneous
    }
    public enum SubType
    {
        Spear,
        Shield,
        Sword,
        LongBow,
        ShortBow,
        Maze,
        Axe,
        BattleAxe,
        Knife,
        Hammer,

        Chestplate,
        Boots,
        Helmet,

        Iron,
        Gold,
        Silver,
        Copper,
        Diamond,
        Leather
    }
    public Sprite icon;
    public new string name;
    public ItemType itemType;
    public SubType subType;
    public string description;
    public float weight;
    public float durability;
    public int levelRequirement;
    //public float damage;
    //public float armor;
}
