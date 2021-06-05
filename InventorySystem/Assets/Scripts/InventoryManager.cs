using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] ContentManager content;
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
        SetItem(itemsList[random]);
    }

    void SetItem(Item _item){
        content.randomItem = _item;
        content.getItem = true;
    }
}
