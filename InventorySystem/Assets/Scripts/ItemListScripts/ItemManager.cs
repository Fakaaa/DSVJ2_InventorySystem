using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemManager : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    [HideInInspector] public bool isGetItem = false;
    [HideInInspector] public bool imSetItem = false;
    [HideInInspector] public bool isReturnData = false;
    [SerializeField] Text itemName;
    [SerializeField] Image itemImage;

    public delegate void ReturnItem();
    public ReturnItem returnItem;

    public void OnPointerClick(PointerEventData pointerEventData){
        if (pointerEventData.button == PointerEventData.InputButton.Left) {
            isReturnData = true;
            returnItem?.Invoke();
        }
    }

    public void UpdateData(){
        itemName.text = item.name;
        itemImage.sprite = item.icon;
        isGetItem = false;
    }
}
