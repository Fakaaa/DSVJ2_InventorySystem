using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] EquipmentManager equipment;
    [SerializeField] ContentManager content;
    [SerializeField] List<Item> itemsList;

    void Start(){
        content.returnedItem += CatchItem;
    }

    void Update()
    {
        ActivateSetItem();
    }

    void ActivateSetItem(){
        if(Input.GetKeyDown(KeyCode.F)){
            GenerateItem();
        }
    }

    void GenerateItem(){
        int random = Random.Range(0, itemsList.Count);
        SetItem(itemsList[random]);
    }

    void SetItem(Item _item){
        content.SetItemToList(ref _item);
    }

    void CatchItem(ref Item _itemIn){
        equipment.ReciveItem(ref _itemIn);
    }
}
