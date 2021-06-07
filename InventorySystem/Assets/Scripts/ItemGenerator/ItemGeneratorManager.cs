using System.Collections.Generic;
using UnityEngine;

public class ItemGeneratorManager : MonoBehaviour
{
    [SerializeField] InventoryManager inventory;
    [SerializeField] List<Item> itemsList;

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
        SendItem(itemsList[random]);
    }

    void SendItem(Item _item){
        inventory.ReciveItemToInventory(_item);
    }
}
