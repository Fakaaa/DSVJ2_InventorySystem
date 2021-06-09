using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] EquipmentManager equipment;
    [SerializeField] ContentManager content;

    void Start(){
        content.returnedItem += CatchItem;
    }

    public void ReciveItemToInventory(Item _item){
        SetItem(_item);
    }

    void SetItem(Item _item){
        content.SetItemToList(_item);
    }

    void CatchItem(ref Item _itemIn){
        equipment.ReciveItem(ref _itemIn);
    }
}
