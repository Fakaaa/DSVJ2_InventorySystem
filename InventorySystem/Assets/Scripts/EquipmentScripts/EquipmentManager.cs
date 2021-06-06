using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] InventoryManager inventory;
    [SerializeField] Button helmetButton;
    Item helmetItem;
    [SerializeField] Button chestplateButton;
    Item chestplateItem;
    [SerializeField] Button bootsButton;
    Item bootsItem;
    [SerializeField] Button weaponButton;
    Item weaponItem;

    public void ReciveItem(ref Item _itemIn){
        switch (_itemIn.itemType) {
            case Item.ItemType.Weapon:

                ChangeData(ref _itemIn, ref weaponItem, ref weaponButton);

            break;
            case Item.ItemType.Helmet:

                ChangeData(ref _itemIn, ref helmetItem, ref helmetButton);

            break;
            case Item.ItemType.Chestplate:

                ChangeData(ref _itemIn, ref chestplateItem, ref chestplateButton);

            break;
            case Item.ItemType.Boots:

                ChangeData(ref _itemIn, ref bootsItem, ref bootsButton);

            break;
        }
    }

    void ChangeData(ref Item _itemIn, ref Item _localItem, ref Button _button){
        if(_localItem == null){
            _localItem = _itemIn;
            _button.image.sprite = _itemIn.icon;
        }
        else if(_localItem == _itemIn){
            inventory.SetItem(_itemIn);
        }
        else{
            inventory.SetItem(_localItem);
            _localItem = _itemIn;
            _button.image.sprite = _itemIn.icon;
        }
    }
}
