using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] InventoryManager inventory;
    [SerializeField] Button helmet;
    Item helmetItem;
    [SerializeField] Button chestplate;
    Item chestplateItem;
    [SerializeField] Button boots;
    Item bootsItem;
    [SerializeField] Button weapon;
    Item weaponItem;

    public void ReciveItem(ref Item _itemIn){
        switch (_itemIn.itemType) {
            case Item.ItemType.Weapon:
                weaponItem = _itemIn;
                weapon.image.sprite = _itemIn.icon;
            break;
            case Item.ItemType.Helmet:
                helmetItem = _itemIn;
                helmet.image.sprite = _itemIn.icon;
            break;
            case Item.ItemType.Chestplate:
                chestplateItem = _itemIn;
                chestplate.image.sprite = _itemIn.icon;
            break;
            case Item.ItemType.Boots:
                bootsItem = _itemIn;
                boots.image.sprite = _itemIn.icon;
            break;
        }
    }

}
