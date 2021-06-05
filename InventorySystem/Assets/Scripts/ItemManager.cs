using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Item item;
    [HideInInspector] public bool isGetItem = false;
    [HideInInspector] public bool imSetItem = false;
    [SerializeField] Text itemName;
    [SerializeField] Image itemImage;

    void Update()
    {
        UpdateData();
    }

    void UpdateData(){
        if(isGetItem){
            itemName.text = item.name;
            itemImage.sprite = item.icon;
            isGetItem = false;
        }
    }
}
